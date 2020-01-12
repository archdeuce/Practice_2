using _2020_01_04_cw.Model;
using _2020_01_04_cw.Tools;
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
using System.Windows.Shapes;

namespace _2020_01_04_cw.Views
{
    /// <summary>
    /// Interaction logic for BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        public Book tmpBook = new Book();
        public Book recievedBook;

        public BookWindow(Book book)
        {
            InitializeComponent();

            if (book.Title != null)
                this.tmpBook.IsNew = false;

            this.recievedBook = book;

            this.tmpBook.Title = book.Title;
            this.tmpBook.Cost = book.Cost;
            this.tmpBook.DateOfPublication = book.DateOfPublication;

            this.DataContext = this.tmpBook;

            CommandBinding bindOkButton = new CommandBinding(CustomCommands.OkCommand);
            bindOkButton.Executed += OkCommand_Executed;
            bindOkButton.CanExecute += ButtonCommand_CanExecute;
            this.CommandBindings.Add(bindOkButton);

            CommandBinding bindCancelButton = new CommandBinding(CustomCommands.CancelCommand);
            bindCancelButton.Executed += CancelButton_Executed;
            bindCancelButton.CanExecute += ButtonCommand_CanExecute;
            this.CommandBindings.Add(bindCancelButton);
        }

        public void OkCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.recievedBook.Title = this.tmpBook.Title;
            this.recievedBook.Cost = this.tmpBook.Cost;
            this.recievedBook.DateOfPublication = this.tmpBook.DateOfPublication;
            this.recievedBook.Save();

            this.DialogResult = true;
            this.Close();
        }

        public void CancelButton_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public void ButtonCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
