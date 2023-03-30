using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wypozyczalniaDAL.Models
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        public int Id_Payment { get; set; }
        [Required]
        [Range(0.0,double.MaxValue)]
        public double Price { get; set; }
        
    }
}
