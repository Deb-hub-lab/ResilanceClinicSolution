using AssuranceClinic.Domain.Entities;

namespace AssuranceClinic.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllAsync();
        Task<int> CreateAsync(Doctor doctor);
    }
}
