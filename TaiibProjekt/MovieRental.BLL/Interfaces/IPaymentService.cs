using MovieRental.BLL.Services;
using MovieRental.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.BLL.Interfaces
{
    public interface IPaymentService
    {
        public UserAveragePaymentResult GetUserAveragePaymentValue(int userId);
        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice);
    }
}
