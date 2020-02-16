using _2020_02_11_cw.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2020_02_11_cw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var context = new SchoolContext())
            {
                //var student = context.Students.Where(s => s.Name == "Elena Zub").FirstOrDefault<Student>();
                //Debug.WriteLine(student.Name);

                //var studentsAsc = context.Students.OrderBy(s => s.Name).ToList();
                //var studentsDesc = context.Students.OrderByDescending(s => s.Name).ToList();

                //foreach (var item in studentsDesc)
                //{
                //    Debug.WriteLine(item.Name);
                //}

                //var student = context.Students.Where(s => s.Name == "Elena Zub").Include(s => s.CourceId).FirstOrDefault();
                //Debug.WriteLine(student.Name);

                //context.Entry(student).Reference(s => s.StudentAddress).Load(); //loads StudentAddress
                //context.Entry(student).Reference(s => s.StudentCourses).Load(); //loads StudentCourses
                //var course = context.Cources.Where(c => c.CourseName == "MyCourseName").Include(c => c.Students).FirstOrDefault();

                IList<Student> studentsList = context.Students.ToList<Student>();
                Student std = studentsList[0];
                Debug.WriteLine(std.Name);
            }
        }
    }
}
