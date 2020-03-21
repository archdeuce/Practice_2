using DAL.Model;
using DAL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WPF.ViewModel
{
    public class MainWindowViewModel: INotifyPropertyChanged
    {
        private readonly IStoreService StoreService;
        public ObservableCollection<Customer> Customers { get; set; }
        public ObservableCollection<Product> Products { get; set; }
        private Customer selectedCustomer;
        private Order selectedOrder;
        private Stock selectedStock;
        private Product selectedProduct;
        private Product selectedStoreProduct;
        private Store selectedStore;

        public Customer SelectedCustomer
        {
            get
            {
                return this.selectedCustomer;
            }
            set
            {
                if (this.selectedCustomer == value)
                    return;

                this.selectedCustomer = value;
                this.OnPropertyChanged(nameof(this.SelectedCustomer));
            }
        }

        public Order SelectedOrder
        {
            get
            {
                return this.selectedOrder;
            }
            set
            {
                if (this.selectedOrder == value)
                    return;

                this.selectedOrder = value;
                this.OnPropertyChanged(nameof(this.SelectedOrder));

                if (this.selectedOrder != null)
                    this.SelectedProduct = this.selectedOrder.OrderItems.FirstOrDefault().Product;
                else
                    this.SelectedProduct = null;
            }
        }

        public Product SelectedProduct
        {
            get
            {
                return this.selectedProduct;
            }
            set
            {
                if (this.selectedProduct == value)
                    return;

                this.selectedProduct = value;
                this.OnPropertyChanged(nameof(this.SelectedProduct));
            }
        }

        public Product SelectedStoreProduct
        {
            get
            {
                return this.selectedStoreProduct;
            }
            set
            {
                if (this.selectedStoreProduct == value)
                    return;

                this.selectedStoreProduct = value;
                this.OnPropertyChanged(nameof(this.SelectedStoreProduct));
            }
        }

        public Stock SelectedStock
        {
            get
            {
                return this.selectedStock;
            }
            set
            {
                if (this.selectedStock == value)
                    return;

                this.selectedStock = value;
                this.OnPropertyChanged(nameof(this.SelectedStock));

                if (this.selectedStock != null)
                    this.SelectedStoreProduct = this.selectedStock.Product;
                else
                    this.SelectedStoreProduct = null;
            }
        }
        public Store SelectedStore
        {
            get
            {
                return this.selectedStore;
            }
            set
            {
                if (this.selectedStore == value)
                    return;

                this.selectedStore = value;
                this.OnPropertyChanged(nameof(this.SelectedOrder));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new System.Windows.DependencyObject()))
                return;

            this.StoreService = new StoreService();
            this.Customers = new ObservableCollection<Customer>(this.StoreService.GetCustomers());
            this.Products = new ObservableCollection<Product>(this.StoreService.GetProducts());
        }
    }
}
