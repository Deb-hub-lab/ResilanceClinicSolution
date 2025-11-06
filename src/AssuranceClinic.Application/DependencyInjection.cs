using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace AssuranceClinic.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register services
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientService, PatientService>();

            return services;
        }
    }
}
