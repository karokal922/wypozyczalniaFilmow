using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    [Table("Ratings")]
    public class Rate
    {
        [Key]
        public int Id_Rate { get; set; }
        [Required, Range(1.0, 10.0, ErrorMessage = "Rate must be between 1 and 10")]
        public double RateValue { get; set; }
        [StringLength(250)]
        public string? Comment { get; set; }
        
        public int MovieId { get; set; }
        [ForeignKey(nameof(MovieId))]
        public Movie Movie { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}