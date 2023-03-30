using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalniaDAL.Models
{
    [Table("Rentals")]
    public class Rent
    {
        [Key]
        public int Id_Rate { get; set; }
        [Required]
        public IEnumerable<int> Movie_IDs { get; set; }
        [Required]
        [ForeignKey(nameof(Payment))]
        public int Payment_ID { get; set; }
        [Required]
        [ForeignKey(nameof(User))]
        public int User_ID { get; set; }
        [Required]
        public DateTime RentingDate { get; set; }
    }
}
