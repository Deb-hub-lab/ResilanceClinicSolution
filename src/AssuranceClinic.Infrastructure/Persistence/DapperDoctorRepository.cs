using AssuranceClinic.Domain.Entities;
using AssuranceClinic.Domain.Interfaces;
using Dapper;
using System.Data;

namespace AssuranceClinic.Infrastructure.Persistence
{ 
    public class DapperDoctorRepository : IDoctorRepository
    {
        private readonly Func<IDbConnection> _connectionFactory;

        public DapperDoctorRepository(Func<IDbConnection> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            using var conn = _connectionFactory();
            const string sql = "SELECT doctor_id AS Id, name, specialty AS Specialty, contact AS Contact FROM doctor;";
            return await conn.QueryAsync<Doctor>(sql);
        }

        public async Task<int> AddDoctorAsync(Doctor doctor)
        {
            using var conn = _connectionFactory();
            const string sql = "INSERT INTO doctor (name, specialty, contact) VALUES (@Name, @Specialty, @Contact);";
            return await conn.ExecuteAsync(sql, doctor);
        }
    }
}
