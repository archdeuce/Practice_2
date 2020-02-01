using _2020_02_01_cw.Model.Constant;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _2020_02_01_cw.Model
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private string model;
        private string image;
        private string price;
        private string country;
        private string color;
        private string weight;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == value)
                    return;

                this.name = value;
                this.OnPropertyChanged(nameof(this.name));
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                if (this.model == value)
                    return;

                this.model = value;
                this.OnPropertyChanged(nameof(this.model));
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                if (this.image == value)
                    return;

                this.image = value;
                this.OnPropertyChanged(nameof(this.image));
            }
        }

        public string Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (this.price == value)
                    return;

                this.price = value;
                this.OnPropertyChanged(nameof(this.price));
            }
        }

        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                if (this.country == value)
                    return;

                this.country = value;
                this.OnPropertyChanged(nameof(this.country));
            }
        }

        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                if (this.color == value)
                    return;

                this.color = value;
                this.OnPropertyChanged(nameof(this.color));
            }
        }

        public string Weight
        {
            get
            {
                return this.weight;
            }
            set
            {
                if (this.weight == value)
                    return;

                this.weight = value;
                this.OnPropertyChanged(nameof(this.weight));
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

        public Product(string name, string model, string image, string price, string country, string color, string weight)
        {
            this.Name = name;
            this.Model = model;
            this.Image = image;
            this.Price = price;
            this.Country = country;
            this.Color = color;
            this.Weight = weight;
        }

        public Product()
        {
            this.Name = DefaultValues.Name;
            this.Model = DefaultValues.Model;
            this.Image = DefaultValues.Image;
            this.Price = DefaultValues.Price;
            this.Country = DefaultValues.Country;
            this.Color = DefaultValues.Color;
            this.Weight = DefaultValues.Weight;
        }
    }
}
