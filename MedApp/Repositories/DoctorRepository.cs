using MedApp.Contexts;

namespace MedApp.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly MedAppDbContext _context;

        public DoctorRepository(MedAppDbContext context)
        {
            _context = context;
        }

        public bool DoctorExists(int idDoctor)
        {
           return _context.Doctors.Any(d => d.IdDoctor == idDoctor);
        }
    }
}
