using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string RegionName { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
