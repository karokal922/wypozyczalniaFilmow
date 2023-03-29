using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalniaDAL.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id_Category { get; set; }
        [Required]
        public IEnumerable<int> Movie_Ids { get; set; } 
        [StringLength(50)]
        [Required]
        public string CategoryName { get; set; }
    }
}
