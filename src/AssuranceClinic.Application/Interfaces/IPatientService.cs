using AssuranceClinic.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AssuranceClinic.Application.Interfaces
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAllPatientsAsync();   // Add this method
        Task<int> AddPatientAsync(Patient patient);        // Optional if you have insert
        Task<int> CreateAsync(Patient patient);
    }
}
