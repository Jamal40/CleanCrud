using CleanCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanCrud.Data;

public class HospitalContext : DbContext
{
    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options) { }

    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Issue> Issues { get; set; }
    public DbSet<Patient> Patients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Seeding Doctors
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Muahmmed",
                PerformanceRate = 95,
                Salary = 50_000,
                Specialization = "Cardiology"
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Ahmed",
                PerformanceRate = 96,
                Salary = 70_000,
                Specialization = "Surgery"
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Yasmeen",
                PerformanceRate = 92,
                Salary = 80_000,
                Specialization = "Pediatrics"
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Salma",
                PerformanceRate = 97,
                Salary = 85_000,
                Specialization = "Pathology"
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Esam",
                PerformanceRate = 92,
                Salary = 77_000,
                Specialization = "Obstetrics"
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Maha",
                PerformanceRate = 99,
                Salary = 100_000,
                Specialization = "Neurosurgery"
            },
            new Doctor
            {
                Id = Guid.NewGuid(),
                Name = "Khalid",
                PerformanceRate = 91,
                Salary = 97_000,
                Specialization = "Radiology"
            });
        #endregion

        #region Seeding Patients
        modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = Guid.NewGuid(), Name = "John" },
            new Patient { Id = Guid.NewGuid(), Name = "James" },
            new Patient { Id = Guid.NewGuid(), Name = "Anderson" }
            );
        #endregion

        #region Seeding Issues
        modelBuilder.Entity<Issue>().HasData(
            new Issue { Id = Guid.NewGuid(), Name = "Cold" },
            new Issue { Id = Guid.NewGuid(), Name = "Stress" },
            new Issue { Id = Guid.NewGuid(), Name = "Headache" }
            );
        #endregion


        base.OnModelCreating(modelBuilder);
    }
}
