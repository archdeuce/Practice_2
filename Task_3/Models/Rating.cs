using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class Rating
    {
        public int Stars { get; set; }
        public int Position { get; set; }

        public int ReviewerId { get; set; }
        public Reviewer Reviewer { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
