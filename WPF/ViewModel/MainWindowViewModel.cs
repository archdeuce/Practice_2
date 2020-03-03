using WPF.ViewModel.Command;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using System.ComponentModel;
using System.Linq;
using WPF;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using DAL;
using DAL.Models;

namespace WPF.ViewModel
{
    public class MainWindowViewModel
    {
        public GenericRepository<Product> genericRepository;
        public ObservableCollection<Product> Products { get; set; }
        public Product SelectedProduct { get; set; }
        public ICommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand DefaultCommand { get; set; }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.NewCommand = new RelayCommand(NewCommandExecuted, NewCommandCanExecute);
            this.SaveCommand = new RelayCommand(SaveCommandExecuted, SaveCommandCanExecute);
            this.DefaultCommand = new RelayCommand(DefaultCommandExecuted, DefaultCommandCanExecute);
            this.DeleteCommand = new RelayCommand(DeleteCommandExecuted, DeleteCommandCanExecute);
            
            this.genericRepository = new GenericRepository<Product>();
            this.Products = new ObservableCollection<Product>(this.genericRepository.Get());
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

        public void NewCommandExecuted(object obj)
        {
            Product p = new Product();
            this.Products.Add(p);
            this.genericRepository.Add(p);
        }

        public bool NewCommandCanExecute(object obj)
        {
            return true;
        }

        public void DeleteCommandExecuted(object obj)
        {
            Product p = this.SelectedProduct;
            this.Products.Remove(p);
            this.genericRepository.Delete(p);
        }

        public bool DeleteCommandCanExecute(object obj)
        {
            if (this.SelectedProduct != null)
                return true;
            else
                return false;
        }

        public void SaveCommandExecuted(object obj)
        {
            this.genericRepository.Save();
        }

        public bool SaveCommandCanExecute(object obj)
        {
            return true;
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
