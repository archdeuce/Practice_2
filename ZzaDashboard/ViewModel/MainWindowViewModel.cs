using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZzaDashboard.Model;

namespace ZzaDashboard.View
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private Customer customer;
        public Customer Customer 
        {
            get
            {
                return this.customer;
            }
            set
            {
                if (this.customer == value)
                    return;

                this.customer = value;
                this.OnPropertyChanged(nameof(this.Customer));
            } 
        }

        public ICommand ChangeCustomer { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged is null)
                return;

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));

        }
        
        public MainWindowViewModel()
        {
            this.Customer = new Customer("test1", "test2", "123");
            this.ChangeCustomer = new RelayCommand(this.ChangeCustomerCommandExecute);
        }

        private void ChangeCustomerCommandExecute(object obj)
        {
            this.Customer = new Customer("test1313", "test2342", "444");
        }
    }
}
