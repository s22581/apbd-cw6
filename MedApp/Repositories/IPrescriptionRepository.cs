using MedApp.Models;

namespace MedApp.Repositories
{
    public interface IPrescriptionRepository
    {
        void CreatePrescription(Prescription prescription);
    }
}
