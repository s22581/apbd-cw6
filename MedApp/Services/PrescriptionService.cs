using MedApp.Repositories;
using MedApp.Models.DTOs;
using MedApp.Models;

namespace MedApp.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IMedicamentRepository _medicamentRepository;
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IDoctorRepository _doctorRepository;

        public PrescriptionService(
            IPatientRepository patientRepository,
            IMedicamentRepository medicamentRepository,
            IPrescriptionRepository prescriptionRepository,
            IDoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _medicamentRepository = medicamentRepository;
            _prescriptionRepository = prescriptionRepository;
            _doctorRepository = doctorRepository;
        }

        public void AddPrescription(PrescriptionDto prescriptionDto)
        {
            //doktor zostal dodany do koncowki poniwaz wedlug dostarczonego diagramu bazy danych nie mozna utworzyc recepty bez doktora
            bool doctorExits = _doctorRepository.DoctorExists(prescriptionDto.IdDoctor);
            if (!doctorExits)
            {
                throw new Exception($"Doctor with Id: {prescriptionDto.IdDoctor} does not exist");
            }
            var patient = _patientRepository.GetPatient(prescriptionDto.Patient.IdPatient);
            if (patient == null)
            {
                DateOnly birthDate = DateOnly.Parse(prescriptionDto.Patient.BirthDate);
                patient = new Patient()
                {
                    FirstName = prescriptionDto.Patient.FirstName,
                    LastName = prescriptionDto.Patient.LastName,
                    Birthdate = birthDate
                };
                _patientRepository.addPatient(patient);
            }

            foreach (var m in prescriptionDto.Medicaments)
            {
                bool medicamentExists = _medicamentRepository.MedicamentExists(m.IdMedicament);
                if (!medicamentExists)
                {
                    throw new Exception($"Medicament with id: {m.IdMedicament} does not exist");
                }
            }
            if (prescriptionDto.Medicaments.Count > 10 || prescriptionDto.Medicaments.Count < 1)
            {
                throw new Exception("Medicaments amount cannot be greater then 10 and smaller then 1");
            }
            DateOnly date = DateOnly.Parse(prescriptionDto.Date);
            DateOnly dueDate = DateOnly.Parse(prescriptionDto.DueDate);

            if (dueDate < date)
            {
                throw new Exception("DueDate cannot be smaller then Date");
            }
            var prescription = new Prescription()
            {
                Date = date,
                DueDate = dueDate,
                IdPatient = patient.IdPatient,
                IdDoctor = prescriptionDto.IdDoctor,
                Prescription_Medicaments = prescriptionDto.Medicaments.Select(m => new Prescription_Medicament()
                {
                    IdMedicament = m.IdMedicament,
                    Dose = m.Dose,
                    Details = m.Description

                }).ToList()

            };
            _prescriptionRepository.CreatePrescription(prescription);
            
        }
    }
}
