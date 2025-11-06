using AssuranceClinic.Domain.Entities;
using AssuranceClinic.Domain.Interfaces;
using Dapper;
using System.Data;

namespace AssuranceClinic.Infrastructure.Persistence
{
    public class DapperPatientRepository : IPatientRepository
    {
        private readonly Func<IDbConnection> _connectionFactory;

        public DapperPatientRepository(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Patient>> GetPatientsAsync()
        {
            using var conn = _connectionFactory();
            const string sql = "SELECT patient_id AS Id, doctor_id AS DoctorId, name, age, gender, diagnosis, admitted_date AS RegisteredOn FROM patient;";
            return await conn.QueryAsync<Patient>(sql);
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            using var conn = _connectionFactory();
            const string sql = "INSERT INTO patient (doctor_id, name, age, gender, diagnosis, admitted_date) VALUES (@DoctorId, @Name, @Age, @Gender, @Diagnosis, @RegisteredOn);";
            return await conn.ExecuteAsync(sql, patient);
        }
    }
}
