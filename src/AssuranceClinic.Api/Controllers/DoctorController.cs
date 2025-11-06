using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AssuranceClinic.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorController(IDoctorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Doctor doctor)
        {
            var rows = await _service.CreateAsync(doctor);
            return Ok(new { RowsAffected = rows });
        }
    }
}
