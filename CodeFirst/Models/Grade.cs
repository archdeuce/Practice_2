using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst.Models
{
    public class Grade
    {
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public string Section { get; set; }

        public ICollection<Student> Students { get; set; }

        public Grade(int gradeId, string gradeName, string section)
        {
            this.GradeId = gradeId;
            this.GradeName = gradeName;
            this.Section = section;
        }

        public Grade()
        {
        }
    }
}
