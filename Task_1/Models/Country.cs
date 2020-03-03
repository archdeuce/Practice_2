using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2020_02_08_hw.Models
{
    public class Country
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }

        public Region Region { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
