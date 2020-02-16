using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2020_02_08_hw.Models
{
    [Table("job_grades", Schema = "dbo")]
    public class JobGrade
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("GRADE_LEVEL"), StringLength(22)]
        public string GradeLevel { get; set; }

        [Column("LOWEST_SAL")]
        public int LowestSal { get; set; }

        [Column("HIGHEST_SAL")]
        public int HighestSal { get; set; }
    }
}
