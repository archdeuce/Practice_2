using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_25_cw.Models
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { 
            optionsBuilder.UseSqlServer(@"Database = SchoolDB2; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var allEntiry = modelBuilder.Model.GetEntityTypes();

            foreach (var entity in allEntiry)
            {
                entity.AddProperty("CreatedDate", typeof(DateTime?));
                entity.AddProperty("UpdatedDate", typeof(DateTime?));
            }
        }
    }
}
