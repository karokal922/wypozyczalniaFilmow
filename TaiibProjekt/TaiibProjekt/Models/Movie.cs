using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    [Table("Movies")]
    public class Movie
    {
        [Key]
        public int Id_Movie { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public DateTime Premiere { get; set; }
        [StringLength(250)]
        public string? Description { get; set; }
        
        public int? RentId { get; set; }
        [ForeignKey(nameof(RentId))]
        public Rent? Rent { get; set; }
        public ICollection<Category> Categories { get; set; }
        [NotMapped]
        public ICollection<int> CategoriesIds { get; set; }
        public ICollection<Rate>? Rates { get; set; }
    }
}
