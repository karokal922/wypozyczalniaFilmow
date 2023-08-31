using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    [Table("Rentals")]
    public class Rent
    {
        [Key]
        public int Id_Rent { get; set; }
        public DateTime RentingDate { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        //public int PaymentId { get; set; }
        //[ForeignKey(nameof(PaymentId))]
        public Payment Payment { get; set; }
        public ICollection<Movie> Movies { get; set; }
        [NotMapped]
        public ICollection<int> MoviesIds { get; set; }
    }
}
