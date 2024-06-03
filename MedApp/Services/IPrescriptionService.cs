using MedApp.Models.DTOs;

namespace MedApp.Services
{
    public interface IPrescriptionService
    {
        void AddPrescription(PrescriptionDto prescriptionDto);
    }
}
