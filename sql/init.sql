-- CREATE DATABASE assuranceclinic;
-- \c assuranceclinic

CREATE TABLE IF NOT EXISTS doctor (
    doctor_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    specialty VARCHAR(100),
    contact VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS patient (
    patient_id SERIAL PRIMARY KEY,
    doctor_id INT REFERENCES doctor(doctor_id),
    name VARCHAR(100) NOT NULL,
    age INT,
    gender VARCHAR(10),
    diagnosis VARCHAR(255),
    admitted_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO doctor (name, specialty, contact) VALUES
('Dr. Priya Mehta', 'Cardiologist', '9876543210'),
('Dr. Arjun Rao', 'Neurologist', '9988776655');

INSERT INTO patient (doctor_id, name, age, gender, diagnosis) VALUES
(1, 'Ravi Sharma', 45, 'Male', 'Hypertension'),
(2, 'Sneha Iyer', 32, 'Female', 'Migraine');
