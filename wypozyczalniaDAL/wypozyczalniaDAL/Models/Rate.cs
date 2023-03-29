using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalniaDAL.Models
{
    [Table("Ratings")]
    public class Rate
    {
        [Key]
        public int Id_Rate { get; set; }
        [ForeignKey(nameof(Movie))]
        [Required]
        public int Movie_ID { get; set; }
        [ForeignKey(nameof(User))]
        [Required]
        public int User_ID { get; set; }
        [Range(1.0, 10.0, ErrorMessage = "Rate must be between 1 and 10")]
        [Required]
        public double _Rate { get; set; }
        [StringLength(250)]
        public string? Comment { get; set; }
    }
    
}
