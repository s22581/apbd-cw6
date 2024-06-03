using MedApp.Repositories;
using MedApp.Models.DTOs;

namespace MedApp.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientService(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public GetPatientDto GetPatient(int idPatient)
        {
            var p = _patientRepository.GetFullPatient(idPatient);
            if (p == null)
            {
                throw new Exception($"Patient with id: {idPatient}, not found");
            }
            var patientDto = new GetPatientDto()
            {
                IdPatient = idPatient,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Birthdate = p.Birthdate.ToString("yyyy-MM-dd"),
                Prescriptions = p.Prescriptions.Select(p => new GetPrescriptionDto()
                {
                    IdPrescription = p.IdPrescription,
                    Date = p.Date.ToString("yyyy-MM-dd"),
                    DueDate = p.DueDate.ToString("yyyy-MM-dd"),
                    Medicaments = p.Prescription_Medicaments.Select(pm => new GetMedicamentDto()
                    {
                        IdMedicament = pm.IdMedicament,
                        Name = pm.Medicament.Name,
                        Dose = pm.Dose,
                        Description = pm.Medicament.Description,

                    }).ToList(),
                    Doctor = new GetDoctorDto()
                    {
                        IdDoctor = p.IdDoctor,
                        FirstName = p.Doctor.FirstName,
                    }
                }).OrderBy(p => p.DueDate).ToList(),

            };
            return patientDto;
        }
    }
}
