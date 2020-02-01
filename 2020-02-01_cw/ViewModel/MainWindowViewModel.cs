using _2020_02_01_cw.Model;
using _2020_02_01_cw.Model.Constant;
using _2020_02_01_cw.ViewModel.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2020_02_01_cw.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public ICommand DefaultCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public MainWindowViewModel()
        {
            this.Products = new ObservableCollection<Product>()
            {
                new Product("Asus", "PRIME H310M-E R2.0", "D:/2020-02-01_cw/2020-02-01_cw/Model/Images/asus.png", "110", "China", "Black", "0.5"),
                new Product("Intel", "i5-8400", "D:/2020-02-01_cw/2020-02-01_cw/Model/Images/intel.png", "50", "China", "Silver", "0.2"),
                new Product("Intel", "UHD Graphics 630", "D:/2020-02-01_cw/2020-02-01_cw/Model/Images/intel.png", "60", "China", "None", "0"),
                new Product("Gigabyte", "GA-Z270X-Gaming 7", "D:/2020-02-01_cw/2020-02-01_cw/Model/Images/gigabyte.png", "10", "China", "None", "0"),
                new Product()
            };

            this.DefaultCommand = new RelayCommand(DefaultCommandExecuted, DefaultCommandCanExecute);
            this.DeleteCommand = new RelayCommand(DeleteCommandExecuted, DeleteCommandCanExecute);
        }

        private void SetDefaultValues()
        {
            this.SelectedProduct.Name = DefaultValues.Name;
            this.SelectedProduct.Model = DefaultValues.Model;
            this.SelectedProduct.Image = DefaultValues.Image;
            this.SelectedProduct.Price = DefaultValues.Price;
            this.SelectedProduct.Country = DefaultValues.Country;
            this.SelectedProduct.Color = DefaultValues.Color;
            this.SelectedProduct.Weight = DefaultValues.Weight;
        }

        public void DeleteCommandExecuted(object obj)
        {
            this.Products.Remove(this.SelectedProduct);
        }

        public bool DeleteCommandCanExecute(object obj)
        {
            if (this.SelectedProduct != null)
                return true;
            else
                return false;
        }

        public void DefaultCommandExecuted(object obj)
        {
            this.SetDefaultValues();
        }

        public bool DefaultCommandCanExecute(object obj)
        {
            if (this.SelectedProduct != null)
                return true;
            else
                return false;
        }
    }
}
