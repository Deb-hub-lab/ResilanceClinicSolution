using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssuranceClinic.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET api/v1/patient
        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetPatientsV1()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        // GET api/v2/patient
        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetPatientsV2()
        {
            var patients = await _patientService.GetAllPatientsAsync();

            // Example difference: v2 returns count as well
            return Ok(new { Count = patients.Count(), Data = patients });
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Patient patient)
        {
            var rows = await _patientService.CreateAsync(patient);
            return Ok(new { RowsAffected = rows });
        }
    }
}
