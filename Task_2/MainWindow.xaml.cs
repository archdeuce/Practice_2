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

namespace Task_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnMyCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            this.nextBtn.Content = "-->Next other page and windows";
            this.prevBtn.Content = "<--Prev other page and windows";
        }

        private void OnMyCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            this.nextBtn.Content = ">Next";
            this.prevBtn.Content = "<Prev";
        }
    }
}
