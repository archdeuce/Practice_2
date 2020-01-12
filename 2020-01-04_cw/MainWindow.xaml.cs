using _2020_01_04_cw.Model;
using _2020_01_04_cw.Tools;
using _2020_01_04_cw.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace _2020_01_04_cw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Author> myAuthors = new ObservableCollection<Author>()
        {
            new Author("Mark", "Twain", DateTime.Parse("1905/1/1"), Country.USA, Tools.Language.English, "Frorida, Missouri", false)  { Books = new ObservableCollection<Book> {
                new Book ("Roughing It", 322, DateTime.Parse("1872/1/1"), Tools.Language.English, false, true),
                new Book ("The Gilded Age", 326, DateTime.Parse("1873/1/1"), Tools.Language.English, false, true),
                new Book ("The Adventures of Tom Sawyer", 232, DateTime.Parse("1876/1/1"), Tools.Language.English, false, true),
                new Book ("The Adventures of Huckleberry Finn", 678, DateTime.Parse("1884/1/1"), Tools.Language.English, false),
                new Book ("A Connecticut Yankee in King Arthur’s Court", 677, DateTime.Parse("1872/1/1"), Tools.Language.English,false),
                new Book ("Following the Equator", 364, DateTime.Parse("1889/1/1"), Tools.Language.English, false),
                new Book ("The Mysterious Stranger", 347, DateTime.Parse("1916/1/1"), Tools.Language.English, false, true),
                new Book ("Eve's Diary", 279, DateTime.Parse("1906/1/1"), Tools.Language.English,false)
            } },

            new Author("O.", "Henry", DateTime.Parse("1862/9/11"), Country.USA, Tools.Language.English, "Greensboro, North Carolina", false)  { Books = new ObservableCollection<Book> {
                new Book ("The Gift of the Magi", 849, DateTime.Parse("1905/1/1"), Tools.Language.English, false),
                new Book ("The Ransom of Red Chief", 369, DateTime.Parse("1907/1/1"), Tools.Language.English, false, true),
                new Book ("The Last Leaf", 337, DateTime.Parse("1907/1/1"), Tools.Language.English, false)
            } },

            new Author("Isaac", "Asimov", DateTime.Parse("1920/1/2"), Country.Russia, Tools.Language.Russian, "Смоленск, Петровичи", false)  { Books = new ObservableCollection<Book> {
                new Book ("Камешек в небе", 173, DateTime.Parse("1950/1/1"), Tools.Language.Russian, false, true),
                new Book ("Я, робот", 362, DateTime.Parse("1950/1/1"), Tools.Language.Russian, false),
                new Book ("Звёзды как пыль", 623, DateTime.Parse("1951/1/1"), Tools.Language.Russian, false, true),
                new Book ("Основание", 235, DateTime.Parse("1951/1/1"), Tools.Language.Russian, false, true),
                new Book ("Космические течения", 112, DateTime.Parse("1952/1/1"), Tools.Language.Russian, false)
            } }
        };

        public MainWindow()
        {
            InitializeComponent();

            this.myListBox.ItemsSource = this.myAuthors;

            CommandBinding bindNewCommand = new CommandBinding(CustomCommands.NewCommand);
            bindNewCommand.Executed += NewCommand_Executed;
            bindNewCommand.CanExecute += NewCommand_CanExecute;
            this.CommandBindings.Add(bindNewCommand);

            CommandBinding bindEditCommand = new CommandBinding(CustomCommands.EditCommand);
            bindEditCommand.Executed += EditCommand_Executed;
            bindEditCommand.CanExecute += EditCommand_CanExecute;
            this.CommandBindings.Add(bindEditCommand);

            CommandBinding bindDeleteCommand = new CommandBinding(CustomCommands.DeleteCommand);
            bindDeleteCommand.Executed += DeleteCommand_Executed;
            bindDeleteCommand.CanExecute += EditCommand_CanExecute;
            this.CommandBindings.Add(bindDeleteCommand);
        }

        //
        // New Command.
        //
        public void NewCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            //
            // Add new author.
            //
            if (source == "myNewAuthorButton" || source == "listBoxItem" || source == "myNewMenuItem")
            {
                var resultAuthor = new Author();
                var authorWindow = new AuthorWindow(resultAuthor);
                authorWindow.Owner = this;
                bool resultAuthorWindow = authorWindow.ShowDialog().Value;

                if (resultAuthorWindow == true)
                    this.myAuthors.Add(resultAuthor);
            }
            //
            // Add new book.
            //
            else if (source == "myNewBookButton" || source == "dataGridItem")
            {
                var resultBook = new Book();
                var bookWindow = new BookWindow(resultBook);
                bookWindow.Owner = this;
                bool resultBookWindow = bookWindow.ShowDialog().Value;

                if (resultBookWindow == true)
                    (this.myListBox.SelectedItem as Author).Books.Add(resultBook);
            }
        }

        //
        // Edit Command.
        //
        public void EditCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            //
            // Edit author.
            //
            if (source == "myEditAuthorButton" || source == "listBoxItem" || source == "myEditMenuItem")
            {
                Author author = this.myListBox.SelectedItem as Author;
                var authorWindow = new AuthorWindow(author);
                authorWindow.Owner = this;
                authorWindow.ShowDialog();
            }
            //
            // Edit book.
            //
            else if (source == "myEditBookButton" || source == "dataGridItem" || source == "myEditMenuItem" )
            {
                Book book = this.myDataGrid.SelectedItem as Book;
                var bookWindow = new BookWindow(book);
                bookWindow.Owner = this;
                bookWindow.ShowDialog();
            }

            this.myListBox.Items.Refresh();
            this.myDataGrid.Items.Refresh();
        }


        //
        // Delete Command.
        //
        public void DeleteCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            //
            // Check edit and delete author button.
            //
            if (source == "myDeleteAuthorButton" || source == "listBoxItem" || source == "myDeleteMenuItem")
            {
                this.myAuthors.Remove(this.myListBox.SelectedItem as Author);
            }
            //
            // Check edit and delete book button.
            //
            else if (source == "myDeleteBookButton" || source == "dataGridItem" || source == "myDeleteMenuItem")
            {
                (this.myListBox.SelectedItem as Author).Books.Remove(this.myDataGrid.SelectedItem as Book);
            }
        }

        //
        // CanExecute.
        //
        public void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;

            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";

            switch (source)
            {
                case "listBoxItem":
                case "dataGridItem":
                case "myNewAuthorButton":
                case "myNewMenuItem":
                    e.CanExecute = true;
                    break;
                case "myNewBookButton":
                    if (this.myListBox.SelectedItem != null)
                        e.CanExecute = true;
                    break;
            }
        }

        public void EditCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            
            string source = string.Empty;

            if (e.Source is Button)
                source = (e.Source as Button).Name;
            else if (e.Source is MenuItem)
                source = (e.Source as MenuItem).Name;
            else if (e.OriginalSource is ListBoxItem)
                source = "listBoxItem";
            else if (e.OriginalSource is DataGridCell)
                source = "dataGridItem";


            if (this.myListBox.SelectedItem != null)
            {
                switch (source)
                {
                    case "listBoxItem":
                    case "myEditAuthorButton":
                    case "myEditAuthorMenuItem":
                    case "myDeleteAuthorButton":
                    case "myDeleteAuthorMenuItem":
                        e.CanExecute = true;
                        return;
                }
            }

            if (this.myDataGrid.SelectedItem != null)
            {
                switch (source)
                {
                    case "dataGridItem":
                    case "myEditBookButton":
                    case "myEditBookMenuItem":
                    case "myDeleteBookButton":
                    case "myDeleteBookMenuItem":
                        e.CanExecute = true;
                        return;
                }
            }
        }
    }
}
