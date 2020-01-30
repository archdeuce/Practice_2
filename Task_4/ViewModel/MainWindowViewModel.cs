using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task_4.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand GetCommand { get; set; }

        public MainWindowViewModel()
        {
            this.NewCommand = new RelayCommand(NewCommandExecuted, NewCommandCanExecute);
            this.DeleteCommand = new RelayCommand(DeleteCommandExecuted, DeleteCommandCanExecute);
            this.GetCommand = new RelayCommand(GetCommandExecuted, GetCommandCanExecute);
            this.Employees = new ObservableCollection<Employee>();
        }

        public void NewCommandExecuted(object obj)
        {
            this.Employees.Add(new Employee());
        }

        public bool NewCommandCanExecute(object obj)
        {
            return true;
        }

        public void DeleteCommandExecuted(object obj)
        {
            this.Employees.Remove(SelectedEmployee);
        }

        public bool DeleteCommandCanExecute(object obj)
        {
            if (this.SelectedEmployee != null)
                return true;
            else
                return false;
        }

        public void GetCommandExecuted(object obj)
        {
            this.Employees.Add(new Employee("Harry Potter", "Gis", false, DateTime.Now));
            this.Employees.Add(new Employee("Albus Dumbledore", "ParkMe", true, DateTime.Now));
            this.Employees.Add(new Employee("Hermione Jean Granger", "Sales", false, DateTime.Now));
        }

        public bool GetCommandCanExecute(object obj)
        {
            if (this.Employees.Count == 0)
                return true;
            else
                return false;

            // return !this.Employees.Any();
        }
    }
}
