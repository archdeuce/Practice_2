using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    public class Employee
    {
        private static int idCounter = 0;
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public bool IsManager { get; set; }
        public DateTime HiredDate { get; set; }

        public Employee(string fullName, string department, bool isManager, DateTime hiredDate)
        {
            this.Id = idCounter++;
            this.FullName = fullName;
            this.Department = department;
            this.IsManager = isManager;
            this.HiredDate = hiredDate;
        }

        public Employee()
        {
            this.Id = idCounter++;
        }
    }
}
