using System;
using System.Collections.Generic;

namespace DAL.Model
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? EnteranceDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Address Address { get; set; }
        public ICollection<Book> Books { get; set; }

        public Student GetDefaultStudent()
        {
            return new Student()
            {
                FirstName = "Default",
                LastName = "Student",
                Email = "default@mail.com"
            };
        }
    }
}