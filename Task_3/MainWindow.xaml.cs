using System;
using System.Collections.Generic;
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

namespace Task_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<TaskManager> tm = new List<TaskManager>
            {
                new TaskManager("Grocery", "Pick up grocery", 2),
                new TaskManager("Laundry", "Do my laundry", 1),
                new TaskManager("Email", "Check mail and reply on urgent", 3)
            };

            this.DataContext = tm;
        }
    }
}
