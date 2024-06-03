using MedApp.Models.DTOs;

namespace MedApp.Services
{
    public interface IPatientService
    {
        GetPatientDto GetPatient(int idPatient);
    }
}
