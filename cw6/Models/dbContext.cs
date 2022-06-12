using Microsoft.EntityFrameworkCore;
using System;
namespace cw6.Models
{
    public class dbContext : DbContext
    {
        public dbContext() { }
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=localhost,1433; Database=CodeFirst; User Id = ShamanBase; Password = password");
        //}
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);

            modelbuilder.Entity<Patient>(p =>
            {
                p.HasKey(e => e.IdPatient);
                p.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                p.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                p.Property(e => e.BirthDate).IsRequired();
                p.HasData(
                    new Patient { IdPatient = 1, FirstName = "Swławe", LastName = "ksks", BirthDate = DateTime.Parse("2000-02-02") },
                    new Patient { IdPatient = 2, FirstName = "Swławqe", LastName = "ksddqks", BirthDate = DateTime.Parse("2005-02-02") },
                    new Patient { IdPatient = 3, FirstName = "Swławqe", LastName = "ksddqks", BirthDate = DateTime.Parse("2005-02-05") }
                    );
            }); 
            modelbuilder.Entity<Doctor>(d =>
            {
                d.HasKey(e => e.IdDoctor);
                d.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                d.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                d.Property(e => e.Email).IsRequired().HasMaxLength(100);

                d.HasData(
                new Doctor { IdDoctor = 1, FirstName = "Swławe", LastName = "ksks", Email = "email" },
                new Doctor { IdDoctor = 2, FirstName = "Swławqe", LastName = "ksddqks", Email = "email" },
                new Doctor { IdDoctor = 3, FirstName = "Swławqe", LastName = "ksddqks", Email = "email" }
                );

            }); 
            modelbuilder.Entity<Prescription>(pr =>
            {
                pr.HasKey(e => e.IdPrescription);
                pr.Property(e => e.Date).IsRequired();
                pr.Property(e => e.DueDate).IsRequired();
                pr.HasOne(e => e.IdPatientNav).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdPatient);
                pr.HasOne(e => e.IdDoctorNav).WithMany(e => e.Prescriptions).HasForeignKey(e => e.IdDoctor);


                pr.HasData(
                    new Prescription { IdPrescription = 1, Date = DateTime.Parse("2000-01-01"), DueDate = DateTime.Parse("2001-01-01"), IdDoctor = 1, IdPatient = 1 },
                    new Prescription { IdPrescription = 2, Date = DateTime.Parse("2000-01-01"), DueDate = DateTime.Parse("2001-01-01"), IdDoctor = 2, IdPatient = 1 }

                    );
                });

        }
    }
}