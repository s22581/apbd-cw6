using MedApp.Contexts;
using MedApp.Models;

namespace MedApp.Repositories
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly MedAppDbContext _context;

        public PrescriptionRepository(MedAppDbContext context)
        {
            _context = context;
        }

        public void CreatePrescription(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
        }
    }
}
