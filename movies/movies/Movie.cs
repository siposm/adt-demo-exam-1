using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace movies
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)] 
        public string Title { get; set; }
        public string Genre { get; set; }
        
        [MinimumYear(1888)]
        public int YearOfRelease { get; set; }

        public override string ToString()
        {
            return $"{Id} {Title} {Genre} {YearOfRelease}";
        }
    }
}
