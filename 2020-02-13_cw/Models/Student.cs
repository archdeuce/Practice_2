using System;
using System.Collections.Generic;
using System.Text;

namespace _2020_02_11_cw.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Course CourceId { get; set; }
    }
}
