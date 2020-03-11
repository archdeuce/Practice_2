using DAL.Model;
using System.Collections.Generic;

namespace DAL.Services
{
    public interface IStudentService
    {
        IEnumerable<Student> GetStudents();
        void SaveStudents(IEnumerable<Student> students);
        Student GetStudentById(int studentId);
        void AddStudent(Student student);
        void DeleteStudentById(int studentId);
        void DeleteStudent(Student student);
        void UpdateStudent(Student student);
    }
}