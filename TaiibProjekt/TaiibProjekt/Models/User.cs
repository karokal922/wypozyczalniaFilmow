using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        [Required, StringLength(30)]
        public string Name { get; set; }
        [Required, StringLength(250)]
        public string Surname { get; set; }

        public ICollection<Rate>? Rates { get; set; }
        public ICollection<Rent>? Rents { get; set; }
    }
}
