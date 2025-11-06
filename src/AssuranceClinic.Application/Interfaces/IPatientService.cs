using AssuranceClinic.Domain.Entities;

namespace AssuranceClinic.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<int> CreateAsync(Patient patient);
    }
}
