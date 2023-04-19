using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wypozyczalniaDAL.Models;

namespace MovieRentalBLL.Interfaces
{
    public interface IPaymentService
    {
        public double GetAveragePaymentValue(int userId, DateTime startDate, DateTime endDate);
        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice);
    }
}
