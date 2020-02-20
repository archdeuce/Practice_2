using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class MovieGenre
    {
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
