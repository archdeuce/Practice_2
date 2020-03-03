using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    public class Job
    {
        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public int MinSalary { get; set; }
        public int MaxSalary{ get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<JobHistory> JobHistories { get; set; }
    }
}
