using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Employee> myEmployees = new ObservableCollection<Employee>()
        {
            new Employee("Harry Potter", "Gis", false, DateTime.Now),
            new Employee("Albus Dumbledore", "ParkMe", true, DateTime.Now),
            new Employee("Hermione Jean Granger", "Sales", false, DateTime.Now),
        };

        public MainWindow()
        {
            InitializeComponent();
            this.myDataGrid.ItemsSource = this.myEmployees;

            CommandBinding bindNew = new CommandBinding(ApplicationCommands.New);
            bindNew.Executed += New_Executed;
            bindNew.CanExecute += New_CanExecute;
            this.CommandBindings.Add(bindNew);

            CommandBinding bindDelete = new CommandBinding(ApplicationCommands.Delete);
            bindDelete.Executed += Delete_Executed;
            bindDelete.CanExecute += MyCommand_CanExecute;
            this.CommandBindings.Add(bindDelete);

            CommandBinding bindMyCommand = new CommandBinding(CustomCommands.MyCommand);
            bindMyCommand.Executed += MyCommand_Executed;
            bindMyCommand.CanExecute += MyCommand_CanExecute;
            this.CommandBindings.Add(bindMyCommand);
        }

        //
        // New item.
        //
        public void New_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.myEmployees.Add(new Employee());
        }

        public void New_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //
        // Delete item.
        //
        public void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.myEmployees.Remove(this.myDataGrid.SelectedItem as Employee);
        }

        //
        // Custom commands.
        //
        public void MyCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Info showWindow = new Info(this.myDataGrid.SelectedItem as Employee);
            showWindow.ShowDialog();
        }

        public void MyCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (this.myDataGrid.SelectedItem is null)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }
    }
}
