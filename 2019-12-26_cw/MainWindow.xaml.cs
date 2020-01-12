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

namespace _2019_12_26_cw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isButtonEnabled;

        public MainWindow()
        {
            InitializeComponent();

            var bind = new CommandBinding(ApplicationCommands.Open);

            bind.Executed += Bind_Executed;
            bind.CanExecute += Bind_CanExecute;
            this.CommandBindings.Add(bind);

            var bind2 = new CommandBinding(MyCommands.ChangeButtonStatus);
            bind2.Executed += CheckBox_Executed;   
            bind2.CanExecute += CheckBox_CanExecute;
            this.CommandBindings.Add(bind2);
        }

        public void Bind_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !this.isButtonEnabled;
        }

        public void Bind_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new MainWindow().ShowDialog();
        }

        public void CheckBox_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        public void CheckBox_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.isButtonEnabled = !this.isButtonEnabled;
        }
    }

    public static class MyCommands
    {
        public static RoutedCommand ChangeButtonStatus { get; set; }

        static MyCommands()
        {
            ChangeButtonStatus = new RoutedCommand(nameof(ChangeButtonStatus), typeof(MainWindow));
        }
    }
}
