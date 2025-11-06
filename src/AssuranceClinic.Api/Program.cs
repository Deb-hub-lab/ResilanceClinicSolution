//using AssuranceClinic.Api.Extensions;
using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Application.Services;
using AssuranceClinic.Domain.Interfaces;
using AssuranceClinic.Infrastructure.Persistence;
using Microsoft.OpenApi.Models;
using Npgsql;
using System.Data;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using AssuranceClinic.Infrastructure; // ✅ add this at the top
using AssuranceClinic.Application;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------------------------------------
// 🔹 Configure Services (DI container)
// -----------------------------------------------------------
builder.Services.AddControllers();

// Swagger Configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ResilanceClinic API",
        Version = "v1",
        Description = "API documentation for ResilanceClinic using Dapper + PostgreSQL"
    });
});

// Register Dapper connection factory
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<Func<IDbConnection>>(_ =>
{
    return () => new NpgsqlConnection(connectionString);
});

//// Application Services
//builder.Services.AddScoped<IPatientService, PatientService>();
//builder.Services.AddScoped<IDoctorService, DoctorService>();

//// Register Repositories
//builder.Services.AddScoped<IPatientRepository, DapperPatientRepository>();
//builder.Services.AddScoped<IDoctorRepository, DapperDoctorRepository>();
// 🔹 Add layer dependencies
builder.Services.AddApplicationServices();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddInfrastructureServices(builder.Configuration);

// Add Memory Cache
builder.Services.AddMemoryCache();

var app = builder.Build();

// -----------------------------------------------------------
//  Configure Middleware
// -----------------------------------------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AssuranceClinic API v1");
        c.RoutePrefix = string.Empty; // Swagger opens at root
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// -----------------------------------------------------------
//  Auto Open Swagger Page (Optional)
// -----------------------------------------------------------
var swaggerUrl = "https://localhost:51780/swagger/index.html";
try
{
    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
    {
        FileName = swaggerUrl,
        UseShellExecute = true
    });
}
catch
{
    Console.WriteLine($"Swagger UI available at: {swaggerUrl}");
}

app.Run();
