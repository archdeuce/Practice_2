using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public Location Location { get; set; }
        public ICollection<JobHistory> JobHistories { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
