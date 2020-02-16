using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("employees", Schema = "dbo")]
    public class Employee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("EMPLOYEE_ID")]
        public int EmployeeId { get; set; }

        [Column("FIRST_NAME"), StringLength(20)]
        public string FirstName { get; set; }

        [Column("LAST_NAME"), StringLength(25)]
        public string LastName { get; set; }

        [Column("EMAIL"), StringLength(25)]
        public string Email { get; set; }

        [Column("PHONE_NUMBER"), StringLength(20)]
        public string PhoneNumber { get; set; }

        [Column("HIRE_DATE")]
        public DateTime HireDate { get; set; }

        [Column("JOB_ID"), StringLength(10)]
        public string JobId { get; set; }

        [Column("SALARY")]
        public int Salary { get; set; }

        [Column("COMMISION_PCT")]
        public int CommisionPct { get; set; }

        [Column("MANAGER_ID")]
        public int ManagerId { get; set; }

        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }

        public Job Job { get; set; }
        public Department Department { get; set; }
        public JobHistory JobHistory { get; set; }
    }
}
