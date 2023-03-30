using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalniaDAL.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int Id_Movie { get; set; }
        [Required]
        public IEnumerable<Category> Categories { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public DateTime Premiere { get; set; }
        public IEnumerable<Rate>? Ratings {get;set;}
        [Required,StringLength(250)]
        public string? Description { get; set; }
    }
}
