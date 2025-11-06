using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using AssuranceClinic.Domain.Interfaces;

namespace AssuranceClinic.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => await _repo.GetPatientsAsync();

        public async Task<int> CreateAsync(Patient patient)
        {
            patient.RegisteredOn = DateTime.UtcNow;
            return await _repo.AddPatientAsync(patient);
        }
    }
}
