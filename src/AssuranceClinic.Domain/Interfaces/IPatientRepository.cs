using AssuranceClinic.Domain.Entities;

namespace AssuranceClinic.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task<int> AddPatientAsync(Patient patient);
    }
}
