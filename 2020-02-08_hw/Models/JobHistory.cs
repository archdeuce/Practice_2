using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("job_history", Schema = "dbo")]
    public class JobHistory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("START_DATE")]
        [Column("START_DATE")]
        public DateTime StartDate { get; set; }

        [Column("END_DATE")]
        public DateTime EndDate { get; set; }

        [Column("JOB_ID"), StringLength(10)]
        public string JobId { get; set; }

        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public Job Job { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
