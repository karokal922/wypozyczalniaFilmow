using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalniaDAL.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        [Required]
        public IEnumerable<Rate> Rates { get; set; }
        [StringLength(30)]
        [Required]
        public string Name { get; set; }
        [StringLength(250)]
        [Required]
        public string Surname { get; set; }
    }
}
