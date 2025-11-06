using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using AssuranceClinic.Domain.Interfaces;

namespace AssuranceClinic.Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repo;

        public DoctorService(IDoctorRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => await _repo.GetDoctorsAsync();

        public async Task<int> CreateAsync(Doctor doctor) => await _repo.AddDoctorAsync(doctor);
    }
}
