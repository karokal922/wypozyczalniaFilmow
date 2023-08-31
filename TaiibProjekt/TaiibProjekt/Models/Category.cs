using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.DAL.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }
        [Required, StringLength(50)]
        public string CategoryName { get; set; }
        public virtual IEnumerable<Movie>? Movies { get; set; }
    }
}
