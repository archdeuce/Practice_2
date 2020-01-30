using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2._3
{
    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDegreeMaster { get; set; }

        public Employee(string firstName, string lastName, bool isDegreeMaster)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.IsDegreeMaster = isDegreeMaster;
        }

        public Employee()
        {
        }
    }
}
