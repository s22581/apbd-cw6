using MedApp.Contexts;
using MedApp.Models.DTOs;
using MedApp.Models;
using Microsoft.EntityFrameworkCore;

namespace MedApp.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly MedAppDbContext _context;

        public PatientRepository(MedAppDbContext context)
        {
            _context = context;
        }

        public void addPatient(Patient patient)
        {
            _context.Patients.Add(patient);
            _context.SaveChanges();
        }

        public Patient GetFullPatient(int idPatient)
        {
           return _context.Patients
                .Include(p => p.Prescriptions)
                    .ThenInclude(p => p.Prescription_Medicaments)
                        .ThenInclude(pm => pm.Medicament)
                .Include(p =>p.Prescriptions)
                    .ThenInclude(p => p.Doctor)
                    .FirstOrDefault(p => p.IdPatient == idPatient);
        }

        public Patient GetPatient(int idPatient)
        {
           return _context.Patients.FirstOrDefault(p =>  p.IdPatient == idPatient);
        }
    }
}
