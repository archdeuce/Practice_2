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

namespace _2019_12_28_cw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int buttonCounter = 1;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Mouse_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Mouse_Click: source {e.Source} sender {sender}");

            if (e.Source is CheckBox)
                return;

            for (int i = 0; i < 3; i++)
            {
                Button newBtn = new Button() { Content = $"Button {this.buttonCounter++}" };
                newBtn.AddHandler(Button.ClickEvent, new RoutedEventHandler(MouseClickColored));
                this.myStackPanel.Children.Add(newBtn);
            }

            e.Handled = true;
        }

        private void MouseClickColored(object sender, RoutedEventArgs e)
        {
            Button selectedButton = e.Source as Button;
            selectedButton.Background = Brushes.Yellow;

            e.Handled = true;
        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            //if (this.myCheckBox.IsChecked == true)
            //    this.myEllipse.Fill = Brushes.Red;
            //else
            //    this.myEllipse.Fill = Brushes.Green;

            //e.Handled = true;
        }

        private void Mouse_Enter(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Mouse_Enter: source {e.Source} sender {sender}");
        }

        private void Mouse_Down(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Mouse_Down: source {e.Source} sender {sender}");
        }
    }
}
