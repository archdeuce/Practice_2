using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_11_cw.Models
{
    public class SchoolContext: DbContext
    {
        public DbSet<Course> Cources { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Database = SchoolDB; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
