using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("jobs", Schema = "dbo")]
    public class Job
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("JOB_ID"), StringLength(10)]
        public string JobId { get; set; }

        [Column("JOB_TITLE"), StringLength(35)]
        public string JobTitle { get; set; }

        [Column("MIN_SALARY")]
        public int MinSalary { get; set; }

        [Column("MAX_SALARY")]
        public int MaxSalary{ get; set; }

        public ICollection<Employee> Employees { get; set; }
        public ICollection<JobHistory> JobHistories { get; set; }
    }
}
