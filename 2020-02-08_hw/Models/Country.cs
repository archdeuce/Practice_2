using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace _2020_02_08_hw.Models
{
    [Table("countries", Schema = "dbo")]
    public class Country
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("COUNTRY_ID", TypeName = "CHAR(2)")]
        public string CountryId { get; set; }

        [Column("DEPARTMENT_NAME"), StringLength(40)]
        public string CountryName { get; set; }

        [Column("REGION_ID")]
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public ICollection<Location> Locations { get; set; }
    }
}
