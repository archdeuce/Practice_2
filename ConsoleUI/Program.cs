using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task (1,2,3,4):");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Program.Task1();
                    break;
                case "2":
                    Program.Task2();
                    break;
                case "3":
                    Program.Task3();
                    break;
                case "4":
                    Program.Task4();
                    break;
                default:
                    Console.WriteLine("Wrong input. Press any key for exit.");
                    break;
            }

            Console.ReadKey();
        }

        public static void Task1()
        {
            Console.WriteLine("Task 1 Create Solution structure:");
            Console.WriteLine("ConsoleUI project(net core console app)");
            Console.WriteLine("DAL project(net core dll)");
            Console.WriteLine("Complete!");
        }

        public static void Task2()
        {
            StudentRepository sr = new StudentRepository(new UniversityDbContext());

            Student student = new Student()
            {
                FirstName = "Oleg",
                LastName = "Reshetilo",
            };

            sr.InsertStudent(student);
            sr.Save();

            Console.WriteLine("The student has been saved.");
        }

        public static void Task3()
        {
            UnitOfWork unitOfWork = new UnitOfWork();

            var courses = unitOfWork.CourseRepository.Get(includeProperties: "Department");
            Course course = unitOfWork.CourseRepository.Get(1);
            unitOfWork.CourseRepository.Add(course);
            unitOfWork.Save();

            Course course2 = unitOfWork.CourseRepository.Get(2);
            unitOfWork.CourseRepository.Update(course);
            unitOfWork.Save();

            var departmentsQuery = unitOfWork.DepartmentRepository.Get(orderBy: q => q.OrderBy(d => d.Name));
            Course course3 = unitOfWork.CourseRepository.Get(3);
            unitOfWork.CourseRepository.Delete(3);
            unitOfWork.Save();
            unitOfWork.Dispose();
        }

        public static void Task4()
        {
            Console.WriteLine("Part 4");
            Console.WriteLine("Task Using Console Application implement:");
            Console.WriteLine("•	Viewing the list of all entities and properties");
            Console.WriteLine("•	Adding new specific entity");
            Console.WriteLine("•	Adding new specific entity");
            Console.WriteLine("•	Deleting entity");
            Console.WriteLine("•	Updating entity");
            Console.WriteLine();

            GenericRepository<Student> genericRepository = new GenericRepository<Student>();
            List<Student> studentList = new List<Student>(genericRepository.Get());

            foreach (var student in studentList)
            {
                Console.WriteLine(String.Format("Student: #{0, -3} {1, -10} {2, -10} \t-\t Course: {3,10}", student?.Id, student?.FirstName, student?.LastName, student?.Course?.Name));
            }

            Student newStudent = new Student()
            {
                FirstName = "Tanya",
                LastName = "Ryzhyk",
                Course = new Course()
                {
                    Name = "Course1"
                }
            };

            //genericRepository.Add(newStudent);

            Student selectedStudent = genericRepository.Get(7);

            //if (selectedStudent != null)
            //    genericRepository.Delete(selectedStudent);

            if (selectedStudent != null)
            {
                selectedStudent.FirstName = "Vanya";
                genericRepository.Update(selectedStudent);
            }

            genericRepository.Save();

            var res = genericRepository.Get(s => s.FirstName == "Oleg").FirstOrDefault<Student>();
            Console.WriteLine(String.Format("\n\nStudent: #{0, -3} {1, -10} {2, -10} \t-\t Course: {3,10}", res?.Id, res?.FirstName, res?.LastName, res?.Course?.Name));
        }
    }
}