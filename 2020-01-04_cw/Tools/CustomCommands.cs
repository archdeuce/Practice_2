using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2020_01_04_cw.Tools
{
    public static class CustomCommands
    {
        public static RoutedCommand NewCommand { get; set; }
        public static RoutedCommand EditCommand { get; set; }
        public static RoutedCommand DeleteCommand { get; set; }
        public static RoutedCommand OkCommand { get; set; }
        public static RoutedCommand CancelCommand { get; set; }

        static CustomCommands()
        {
            CustomCommands.NewCommand = new RoutedCommand(nameof(NewCommand), typeof(MainWindow));
            CustomCommands.EditCommand = new RoutedCommand(nameof(EditCommand), typeof(MainWindow));
            CustomCommands.DeleteCommand = new RoutedCommand(nameof(DeleteCommand), typeof(MainWindow));
            CustomCommands.OkCommand = new RoutedCommand(nameof(OkCommand), typeof(MainWindow));
            CustomCommands.CancelCommand = new RoutedCommand(nameof(CancelCommand), typeof(MainWindow));
        }
    }
}