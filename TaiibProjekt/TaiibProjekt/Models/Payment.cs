using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int Id_Payment { get; set; }
        [Required, Range(0.0, double.MaxValue)]
        public double Price { get; set; }

        
        public int RentId { get; set; }
        [ForeignKey(nameof(RentId))]
        public Rent Rent { get; set; }
    }
}
