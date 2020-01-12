using _2020_01_04_cw.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_01_04_cw.Model
{
    public class Author : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthOfDate { get; set; }
        public Country Country { get; set; }
        public Language Language { get; set; }
        public string PlaceOfBirth { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public Author(string firstName, string lastName, DateTime birthDate, Country country, Language language, string placeOfBirth, bool isNew = true)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthOfDate = birthDate;
            this.Country = country;
            this.Language = language;
            this.PlaceOfBirth = placeOfBirth;
            this.IsNew = isNew;
            this.Books = new ObservableCollection<Book>();
        }

        public Author() 
        {
            this.Books = new ObservableCollection<Book>();
        }

        public override string ToString()
        {
            return String.Concat(this.FirstName, " ", this.LastName);
        }
    }
}
