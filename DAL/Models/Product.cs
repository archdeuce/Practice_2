using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DAL.Models
{
    public class Product : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private string model;
        private string image;
        private string price;
        private string country;
        private string color;
        private string weight;

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (this.id == value)
                    return;

                this.id = value;
                this.OnPropertyChanged(nameof(this.Id));
            }

        }
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
                this.OnPropertyChanged(nameof(this.Name));
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
                this.OnPropertyChanged(nameof(this.Model));
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
                this.OnPropertyChanged(nameof(this.Image));
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
                this.OnPropertyChanged(nameof(this.Price));
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
                this.OnPropertyChanged(nameof(this.Country));
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
                this.OnPropertyChanged(nameof(this.Color));
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
                this.OnPropertyChanged(nameof(this.Weight));
            }
        }

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
