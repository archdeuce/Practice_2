using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DAL.Services
{
    public class StudentService : IStudentService
    {
        private StudentDbContext context;
        private List<Student> students { get; set; }

        public StudentService()
        {
            this.context = new StudentDbContext();
            this.students = new List<Student>(this.context.Students.Include(s => s.Address).Include(s => s.Books));
        }

        public IEnumerable<Student> GetStudents()
        {
            return this.students;
        }

        public void SaveStudents(IEnumerable<Student> students)
        {
            this.context.SaveChanges();
        }

        public Student GetStudentById(int studentId)
        {
            return this.context.Find<Student>(studentId);
        }

        public void AddStudent(Student Student)
        {
            this.context.Add(Student);
        }

        public void DeleteStudentById(int studentId)
        {
            this.context.Remove(studentId);
        }

        public void DeleteStudent(Student Student)
        {
            this.context.Remove<Student>(Student);
        }

        public void UpdateStudent(Student Student)
        {
            this.context.Update(Student);
        }
    }
}