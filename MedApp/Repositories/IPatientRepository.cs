using MedApp.Models.DTOs;
using MedApp.Models;

namespace MedApp.Repositories
{
    public interface IPatientRepository
    {
        Patient GetPatient(int idPatient);
        void addPatient(Patient patient);
        Patient GetFullPatient(int idPatient);
    }
}
