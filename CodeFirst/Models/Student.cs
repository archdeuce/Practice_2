using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeFirst.Models
{
    [Table("MyStudent", Schema = "MySchema")]
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Column("Name", Order = 0)]
        public string FirstName { get; set; }

        [Required, StringLength(20)]
        public string LastName { get; set; }

        [Column("Birth", TypeName = "DateTime2")]
        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public string Comment { get; set; }

        [ForeignKey("GradeId")]
        public int GradeId { get; set; }
        public Grade Grade { get; set; }

        [ForeignKey("AddressId")]
        public int AddressId { get; set; }
        public StudentAdress Address { get; set; }
    }
}
