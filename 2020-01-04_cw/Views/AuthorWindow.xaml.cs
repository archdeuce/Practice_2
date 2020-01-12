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
    /// Interaction logic for AuthorWindow.xaml
    /// </summary>
    public partial class AuthorWindow : Window
    {
        public Author tmpAuthor = new Author();
        public Author recievedAuthor;

        public AuthorWindow(Author author)
        {
            InitializeComponent();

            if (author.FirstName != null)
                this.tmpAuthor.IsNew = false;

            this.recievedAuthor = author;

            this.tmpAuthor.FirstName = author.FirstName;
            this.tmpAuthor.LastName = author.LastName;
            this.tmpAuthor.BirthOfDate = author.BirthOfDate;
            this.tmpAuthor.Country = author.Country;
            this.tmpAuthor.Language = author.Language;
            this.tmpAuthor.PlaceOfBirth = author.PlaceOfBirth;
            this.tmpAuthor.Books = author.Books;

            this.DataContext = this.tmpAuthor;

            CommandBinding bindOkButton = new CommandBinding(CustomCommands.OkCommand);
            bindOkButton.Executed += OkCommand_Executed;
            bindOkButton.CanExecute += ButtonCommand_CanExecute;
            this.CommandBindings.Add(bindOkButton);

            CommandBinding bindCancelButton = new CommandBinding(CustomCommands.CancelCommand);
            bindCancelButton.Executed += CancelCommand_Executed;
            bindCancelButton.CanExecute += ButtonCommand_CanExecute;
            this.CommandBindings.Add(bindCancelButton);
        }

        public void OkCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.recievedAuthor.FirstName = this.tmpAuthor.FirstName;
            this.recievedAuthor.LastName = this.tmpAuthor.LastName;
            this.recievedAuthor.BirthOfDate = this.tmpAuthor.BirthOfDate;
            this.recievedAuthor.Country = this.tmpAuthor.Country;
            this.recievedAuthor.Language = this.tmpAuthor.Language;
            this.recievedAuthor.PlaceOfBirth = this.tmpAuthor.PlaceOfBirth;
            this.recievedAuthor.Books = this.tmpAuthor.Books;
            this.recievedAuthor.Save();

            this.DialogResult = true;
            this.Close();
        }

        public void CancelCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        public void ButtonCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
