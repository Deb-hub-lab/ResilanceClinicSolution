using AssuranceClinic.Application.Interfaces;
using AssuranceClinic.Domain.Entities;
using AssuranceClinic.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssuranceClinic.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
        {
            return await _repo.GetPatientsAsync();
        }

        public async Task<int> AddPatientAsync(Patient patient)
        {
            return await _repo.AddPatientAsync(patient);
        }
        public async Task<int> CreateAsync(Patient patient)
        {
            patient.RegisteredOn = DateTime.UtcNow;
            return await _repo.AddPatientAsync(patient);
        }
    }
}
