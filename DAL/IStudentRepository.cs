using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL
{
    public interface IStudentRepository: IDisposable
    {
        IEnumerable<Student> GetStudents();
        Student GetStudentById(int studentId);
        void InsertStudent(Student student);
        void DeleteStudent(int studentId);
        void UpdateStudent(Student student);
        void Save();
    }
}
