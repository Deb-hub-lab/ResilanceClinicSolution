using AssuranceClinic.Application;
using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Application.Services;
using AssuranceClinic.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------
// Controllers
// ----------------------------
builder.Services.AddControllers();

// ----------------------------
// API Versioning
// ----------------------------
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
    options.ApiVersionReader = ApiVersionReader.Combine(
        new QueryStringApiVersionReader("api-version"),
        new HeaderApiVersionReader("X-Api-Version")
    );
});

// Versioned API Explorer (required for Swagger)
builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV"; // v1, v2
    options.SubstituteApiVersionInUrl = true;
});

// ----------------------------
// Swagger
// ----------------------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ----------------------------
// DI: Application + Infrastructure
// ----------------------------
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// ----------------------------
// Build app
// ----------------------------
var app = builder.Build();

// ----------------------------
// Swagger UI
// ----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var desc in provider.ApiVersionDescriptions)
        {
            c.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.GroupName.ToUpperInvariant());
        }
        c.RoutePrefix = string.Empty; // Swagger at root
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
