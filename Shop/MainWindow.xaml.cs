using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> myList = new ObservableCollection<Product>();

        public MainWindow()
        {
            InitializeComponent();

            this.SetDefaultTextFields();
            this.pCodeTextBox.Focus();

            this.myDataGrid.ItemsSource = myList;
        }

        //
        // Purification of the input fields. Setting the focus to the input field.
        //
        private void SetDefaultTextFields()
        {
            this.pCodeTextBox.Text = string.Empty;
            this.productNameTextBox.Text = string.Empty;
            this.quantityTextBox.Text = string.Empty;
            this.priceTextBox.Text = string.Empty;

            this.pCodeTextBox.Focus();
        }

        //
        // Switch background color when entering illegal characters.
        //
        private void ChangeTextBoxBackgroundColor(string textBoxName, SolidColorBrush backgroundErrorColor)
        {
            switch (textBoxName)
            {
                case "pCodeTextBox":
                    this.pCodeTextBox.Background = backgroundErrorColor;
                    break;
                case "quantityTextBox":
                    this.quantityTextBox.Background = backgroundErrorColor;
                    break;
                case "priceTextBox":
                    this.priceTextBox.Background = backgroundErrorColor;
                    break;
                default:
                    break;
            }
        }

        //
        // Formation of a new product.
        //
        private Product ProductFormation()
        {
            string productName = this.productNameTextBox.Text;
            int productID = 0;
            int quantity = 0;
            int price = 0;

            Int32.TryParse(this.pCodeTextBox.Text, out productID);
            Int32.TryParse(this.quantityTextBox.Text, out quantity);
            Int32.TryParse(this.priceTextBox.Text, out price);

            if (productName == string.Empty)
                productName = "defaultProductName";

            Product product = new Product(productID, productName, quantity, price);

            return product;
        }
        //
        // Adding new products.
        //
        private void OnAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.myList.Add(ProductFormation());

            this.SetDefaultTextFields();
        }

        //
        // Edit selected product information.
        //
        private void OnSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.myList.Count == 0)
                return;

            int itemPosition = this.myDataGrid.SelectedIndex;

            this.myList[itemPosition] = ProductFormation();
        }

        //
        // Removing the selected product, and move the cursor to the last row in the table.
        //
        private void OnRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = this.myDataGrid.SelectedItem as Product;

            this.myList.Remove(selectedProduct);

            this.myDataGrid.SelectedIndex = this.myDataGrid.Items.Count - 1;
        }

        //
        // Purification of the data source table.
        //
        private void OnClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.myList.Clear();

            this.SetDefaultTextFields();
        }

        //
        // Selection of the current product with the mouse.
        //
        private void OnMyDataGrid_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (this.myList.Count == 0)
                return;

            int itemPosition = this.myDataGrid.SelectedIndex;

            if (itemPosition < 0)
                return;

            Product selectedProduct = this.myList[itemPosition];

            this.pCodeTextBox.Text = (selectedProduct.Code).ToString();
            this.productNameTextBox.Text = selectedProduct.ProductName;
            this.quantityTextBox.Text = (selectedProduct.Quantity).ToString();
            this.priceTextBox.Text = (selectedProduct.Price).ToString();
        }

        //
        // Checking input when the button is pressed.
        //
        private void OnTextBoxNumberVerify_KeyDown(object sender, KeyEventArgs e)
        {
            string senderName = (sender as TextBox).Name;

            if ((e.Key < Key.D0) || (e.Key > Key.D9))
            {
                ChangeTextBoxBackgroundColor(senderName, Brushes.Pink);

                e.Handled = true;
            }
        }

        //
        // Checking input when the button is released.
        //
        private void OnTextBoxNumberVerify_KeyUp(object sender, KeyEventArgs e)
        {
            string senderName = (sender as TextBox).Name;

            ChangeTextBoxBackgroundColor(senderName, Brushes.White);
        }
    }
}