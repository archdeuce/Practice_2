using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Task_2
{
    public static class CustomCommands
    {
        public static RoutedCommand MyCommand { get; set; }

        static CustomCommands()
        {
            CustomCommands.MyCommand = new RoutedCommand(nameof(MyCommand), typeof(MainWindow));
        }
    }
}
