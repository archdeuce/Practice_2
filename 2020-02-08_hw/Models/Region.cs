using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("regions", Schema = "dbo")]
    public class Region
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("REGION_ID")]
        public int RegionId { get; set; }

        [Column("REGION_NAME"), StringLength(25)]
        public string RegionName { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
