using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class UnitOfWork: IDisposable
    {
        private UniversityDbContext context = new UniversityDbContext();
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Course> courseRepository;
        private bool disposed = false;

        public GenericRepository<Department> DepartmentRepository
        {
            get 
            {
                if (this.departmentRepository == null)
                    this.departmentRepository = new GenericRepository<Department>(context);

                return this.departmentRepository;
            }
        }

        public GenericRepository<Course> CourseRepository
        {
            get
            {
                if (this.departmentRepository == null)
                    this.courseRepository = new GenericRepository<Course>(context);

                return this.courseRepository;
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
                if (disposing)
                    this.context.Dispose();

            this.disposed = true;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
