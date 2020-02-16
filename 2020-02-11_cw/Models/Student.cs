using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_11_cw.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CurrentGradeId { get; set; }
        public Grade Grade { get; set; }

        public StudentAddress Address { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
