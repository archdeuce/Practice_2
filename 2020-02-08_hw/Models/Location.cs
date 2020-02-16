using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("locations", Schema = "dbo")]
    public class Location
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("LOCATION_ID")]
        public int LocationId { get; set; }

        [Column("STREET_ADDRESS"), StringLength(25)]
        public string StreetAddress { get; set; }

        [Column("POSTAL_CODE"), StringLength(12)]
        public string PostalCode { get; set; }

        [Column("CITY"), StringLength(30)]
        public string City { get; set; }

        [Column("STATE_PROVINCE"), StringLength(12)]
        public string StateProvince { get; set; }

        [Column("COUNTRY_ID"), StringLength(2)]
        public string CountryId { get; set; }

        public Country Country { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
