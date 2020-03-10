using System;
using System.Collections.ObjectModel;
using DAL.Model;
using DAL.Services;
using Presentation.Extensions;


namespace Presentation.ViewModel
{
    public class StudentViewModel : ViewModelBase.ViewModelBase
    {
        private Student selectedStudent;
        private Book selectedBook;
        private ObservableCollection<Student> students;
        private IStudentService studentService;

        public ObservableCollection<Student> Students
        {
            get 
            { 
                return this.students; 
            }
            set
            {
                this.students = value;
                this.OnPropertyChanged();
            }
        }

        public Student SelectedStudent
        {
            get 
            { 
                return this.selectedStudent; 
            }
            set
            {
                this.selectedStudent = value;
                this.OnPropertyChanged();
            }
        }

        public Book SelectedBook
        {
            get
            {
                return this.selectedBook;
            }
            set
            {
                this.selectedBook = value;
                this.OnPropertyChanged();
            }
        }

        public DelegateCommand.DelegateCommand GetStudentsCommand { get; }
        public DelegateCommand.DelegateCommand SaveStudentsCommand { get; }
        public DelegateCommand.DelegateCommand AddStudentCommand { get; }
        public DelegateCommand.DelegateCommand DelStudentCommand { get; }

        public StudentViewModel(IStudentService studentService)
        {
            if (studentService == null) 
                throw new ArgumentNullException(nameof(studentService));

            this.studentService = studentService;
            this.Students = new ObservableCollection<Student>();

            this.GetStudentsCommand = new DelegateCommand.DelegateCommand(this.ExecuteGetStudents, this.CanExecuteGetStudents);
            this.SaveStudentsCommand = new DelegateCommand.DelegateCommand(this.ExecuteSaveStudents, this.CanExecuteSaveStudents);
            this.AddStudentCommand = new DelegateCommand.DelegateCommand(this.ExecuteAddStudent, this.CanExecuteAddStudent);
            this.DelStudentCommand = new DelegateCommand.DelegateCommand(this.ExecuteDelStudent, this.CanExecuteDelStudent);
        }

        private void ExecuteGetStudents()
        {
            this.studentService = new StudentService();
            this.Students = this.studentService.GetStudents().ToObservableCollection();
        }

        private bool CanExecuteGetStudents()
        {
            return true;
        }

        private void ExecuteSaveStudents()
        {
            this.studentService.SaveStudents(this.Students);
        }

        private bool CanExecuteSaveStudents()
        {
            return true;
        }

        private void ExecuteAddStudent()
        {
            Student s = new Student().GetDefaultStudent();

            this.Students.Add(s);
            this.studentService.AddStudent(s);
            this.ExecuteSaveStudents();
        }

        private bool CanExecuteAddStudent()
        {
            return true;
        }

        private void ExecuteDelStudent()
        {
            Student s = this.SelectedStudent as Student;
            this.Students.Remove(this.SelectedStudent);
            this.studentService.DeleteStudent(s);
            this.ExecuteSaveStudents();
        }

        private bool CanExecuteDelStudent()
        {
            return this.selectedStudent != null;
        }
    }
}