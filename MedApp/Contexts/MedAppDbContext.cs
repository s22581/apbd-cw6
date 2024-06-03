using MedApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace MedApp.Contexts
{
    public class MedAppDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Prescription_Medicament> Prescription_Medicaments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public MedAppDbContext(DbContextOptions<MedAppDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicament>(m =>
            {
                m.ToTable("Medicament");
                m.HasKey(m => m.IdMedicament);
                m.Property(m => m.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
                m.Property(m => m.Description)
               .HasColumnType("nvarchar")
               .HasMaxLength(100);
                m.Property(m => m.Type)
               .HasColumnType("nvarchar")
               .HasMaxLength(100);
            });
            modelBuilder.Entity<Prescription_Medicament>(pm =>
            {
                pm.ToTable("Prescription_Medicament");
                pm.HasKey(pm => new { IdMedicament = pm.IdMedicament, IdPrescription = pm.IdPrescription });
                pm.Property(pm => pm.Dose)
                .IsRequired(false);
                pm.Property(pm => pm.Details)
                .HasColumnType("nvarchar")
                .HasMaxLength(100);
                pm.HasOne(pm => pm.Medicament)
                .WithMany(m => m.Prescription_Medicaments)
                .HasForeignKey(pm => pm.IdMedicament);
                pm.HasOne(pm => pm.Prescription)
                .WithMany(p => p.Prescription_Medicaments)
                .HasForeignKey(pm => pm.IdPrescription);
            });
            modelBuilder.Entity<Prescription>(p =>
            {
                p.ToTable("Prescription");
                p.HasKey(p => p.IdPrescription);
                p.HasOne(p => p.Doctor)
                .WithMany(d => d.Prescriptions)
                .HasForeignKey(p => p.IdDoctor);
                p.HasOne(p => p.Patient)
                .WithMany(p => p.Prescriptions)
                .HasForeignKey(p => p.IdPatient);
            });
            modelBuilder.Entity<Doctor>(d =>
            {
                d.ToTable("Doctor");
                d.HasKey(d => d.IdDoctor);
                d.Property(d => d.FirstName).
                HasColumnType("nvarchar")
                .HasMaxLength(100);
                d.Property(d => d.LastName).
               HasColumnType("nvarchar")
               .HasMaxLength(100);
                d.Property(d => d.Email).
               HasColumnType("nvarchar")
               .HasMaxLength(100);
            });
            modelBuilder.Entity<Patient>(p =>
            {
                p.ToTable("Patient");
                p.HasKey(d => d.IdPatient);
                p.Property(d => d.FirstName).
                HasColumnType("nvarchar")
                .HasMaxLength(100);
                p.Property(d => d.LastName).
               HasColumnType("nvarchar")
               .HasMaxLength(100);
            });
        }
    }
}
