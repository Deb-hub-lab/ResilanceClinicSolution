using AssuranceClinic.Domain.Entities;

namespace AssuranceClinic.Application.Interfaces
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsAsync();
        Task<int> AddDoctorAsync(Doctor doctor);
        Task<int> CreateAsync(Doctor doctor);
    }
}
