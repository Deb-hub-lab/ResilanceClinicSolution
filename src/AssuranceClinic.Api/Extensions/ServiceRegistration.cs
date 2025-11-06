using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Application.Services;
using AssuranceClinic.Domain.Interfaces;
using AssuranceClinic.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace AssuranceClinic.Api.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<Func<IDbConnection>>(_ => () => new NpgsqlConnection(connectionString));
            services.AddScoped<IPatientRepository, DapperPatientRepository>();
            services.AddScoped<IDoctorRepository, DapperDoctorRepository>();
            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IDoctorService, DoctorService>();
            return services;
        }
    }
}
