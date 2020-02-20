using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3.Models
{
    public class MovieCast
    {
        public string Role { get; set; }

        public int ActorId { get; set; }
        public Actor Actor { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }
    }
}
