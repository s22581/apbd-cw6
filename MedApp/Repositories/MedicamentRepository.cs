using MedApp.Contexts;

namespace MedApp.Repositories
{
    public class MedicamentRepository : IMedicamentRepository
    {
        private readonly MedAppDbContext _context;

        public MedicamentRepository(MedAppDbContext context)
        {
            _context = context;
        }

        public bool MedicamentExists(int idMedicament)
        {
            return _context.Medicaments.Any(m => m.IdMedicament == idMedicament);
        }
    }
}
