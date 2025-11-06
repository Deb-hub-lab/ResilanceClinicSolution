using AssuranceClinic.Domain.Interfaces;
using AssuranceClinic.Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;
//using AssuranceClinic.Application.Interfaces;
//using AssuranceClinic.Infrastructure.Repositories;

namespace AssuranceClinic.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // ✅ Get connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // ✅ Register Dapper connection factory
            services.AddScoped<Func<IDbConnection>>(_ =>
                () => new NpgsqlConnection(connectionString));

            // ✅ Register repositories
            services.AddScoped<IPatientRepository, DapperPatientRepository>();
            services.AddScoped<IDoctorRepository, DapperDoctorRepository>();

            return services;
        }
    }
}