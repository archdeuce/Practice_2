using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StudentRepository : IStudentRepository, IDisposable
    {
        private UniversityDbContext context;
        private bool disposed = false;

        public StudentRepository(UniversityDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.context.Students.ToList();
        }

        public Student GetStudentById(int studentId)
        {
            return this.context.Students.Find(studentId);
        }

        public void InsertStudent(Student student)
        {
            this.context.Students.Add(student);
        }

        public void DeleteStudent(int studentId)
        {
            Student student = this.context.Students.Find(studentId);
            this.context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            this.context.Entry(student).State = EntityState.Modified;
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
