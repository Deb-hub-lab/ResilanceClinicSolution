using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssuranceClinic.Api.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        public async Task<IActionResult> GetDoctorsV1()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(doctors);
        }

        [HttpGet]
        [MapToApiVersion("2.0")]
        public async Task<IActionResult> GetDoctorsV2()
        {
            var doctors = await _doctorService.GetAllDoctorsAsync();
            return Ok(new { Total = doctors.Count(), Doctors = doctors });
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Doctor doctor)
        {
            var rows = await _doctorService.CreateAsync(doctor);
            return Ok(new { RowsAffected = rows });
        }
    }
}
