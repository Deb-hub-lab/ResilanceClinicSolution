using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssuranceClinic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _service;

        public PatientController(IPatientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Patient patient)
        {
            var rows = await _service.CreateAsync(patient);
            return Ok(new { RowsAffected = rows });
        }
    }
}
