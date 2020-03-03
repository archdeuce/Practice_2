using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_08_hw.Models
{
    public class HrDbContext : DbContext
    {
        public DbSet<Region> Regions { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<JobHistory> JobHistories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database = HR_Fluent; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasOne<Region>(country => country.Region)
                .WithMany(region => region.Countries);

            modelBuilder.Entity<Location>()
                .HasOne<Country>(location => location.Country)
                .WithMany(country => country.Locations);

            modelBuilder.Entity<Department>()
                .HasOne<Location>(department => department.Location)
                .WithMany(location => location.Departments);

            modelBuilder.Entity<JobHistory>()
                .HasOne<Department>(jobhistory => jobhistory.Department)
                .WithMany(department => department.JobHistories);

            modelBuilder.Entity<JobHistory>()
                .HasOne<Job>(jobhistory => jobhistory.Job)
                .WithMany(job => job.JobHistories);

            modelBuilder.Entity<JobHistory>()
                .HasOne<Employee>(jobhistory => jobhistory.Employee)
                .WithMany(employee => employee.JobHistories);

            modelBuilder.Entity<Employee>()
                .HasOne<Job>(employee => employee.Job)
                .WithMany(job => job.Employees);

            modelBuilder.Entity<Employee>()
                .HasOne<Department>(employee => employee.Department)
                .WithMany(department => department.Employees);

            modelBuilder.Entity<JobHistory>()
                .HasKey(j => new { j.EmployeeId, j.StartDate });

            modelBuilder.Entity<Region>()
                 .HasKey(region => region.RegionId);

            modelBuilder.Entity<Region>()
                 .Property(region => region.RegionId)
                 .ValueGeneratedOnAdd();

            modelBuilder.Entity<Region>()
                 .Property(region => region.RegionName)
                 .HasMaxLength(25);
        }
    }
}
