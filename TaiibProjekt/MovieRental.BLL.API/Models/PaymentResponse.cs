using MovieRental.DAL.Models;

namespace MovieRental.BLL.API.Models
{
    public class PaymentResponse
    {
        public int Id_Payment { get; set; }
        public double Price { get; set; }
        public RentResponse Rent { get; set; }
        
    }
}
