using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("departments", Schema = "dbo")]
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }

        [Column("DEPARTMENT_NAME"), StringLength(30)]
        public string DepartmentName { get; set; }

        [Column("MANAGER_ID")]
        public int ManagerId { get; set; }

        [Column("LOCATION_ID")]
        public int LocationId { get; set; }

        public Location Location { get; set; }
        public ICollection<JobHistory> JobHistories { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
