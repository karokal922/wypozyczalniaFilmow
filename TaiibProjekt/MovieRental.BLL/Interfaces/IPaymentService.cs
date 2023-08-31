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
        public double GetAveragePaymentValue(int userId, DateTime startDate, DateTime endDate);
        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice);
    }
}
