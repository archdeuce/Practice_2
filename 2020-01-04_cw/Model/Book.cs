using _2020_01_04_cw.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020_01_04_cw.Model
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public decimal Cost { get; set; }
        public DateTime DateOfPublication { get; set; }
        public Language Language { get; set; }
        public bool Read { get; set; }

        public Book(string title, decimal cost, DateTime dateOfPublication, Language language, bool isNew = true, bool read = false)
        {
            this.Title = title;
            this.Cost = cost;
            this.DateOfPublication = dateOfPublication;
            this.Language = language;
            this.IsNew = isNew;
            this.Read = read;
        }

        public Book() { }
    }
}
