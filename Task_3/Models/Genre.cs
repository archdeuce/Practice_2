using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
    }
}
