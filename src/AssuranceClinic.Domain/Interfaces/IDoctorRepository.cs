using AssuranceClinic.Domain.Entities;

namespace AssuranceClinic.Domain.Interfaces
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<int> AddDoctorAsync(Doctor doctor);
    }
}
