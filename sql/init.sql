-- CREATE DATABASE resilienceclinic;
-- \c resilienceclinic

CREATE TABLE IF NOT EXISTS doctor (
    doctor_id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    specialty VARCHAR(100) NOT NULL,
    contact VARCHAR(100)
);

CREATE TABLE IF NOT EXISTS patient (
    patient_id SERIAL PRIMARY KEY,
    doctor_id INT REFERENCES doctor(doctor_id),
    name VARCHAR(100) NOT NULL,
    age INT,
    gender VARCHAR(10),
    diagnosis VARCHAR(200),
    admitted_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Sample data
INSERT INTO doctor (name, specialty,contact) VALUES ('Dr. John Smith', 'Cardiology','8904292294');
INSERT INTO patient (doctor_id, name, age, gender, diagnosis) VALUES (1, 'Alice', 30, 'Female', 'Hypertension');
