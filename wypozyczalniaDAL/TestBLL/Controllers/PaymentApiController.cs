using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using wypozyczalniaDAL.Models;

namespace TestBLL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentApiController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentApiController(IPaymentService paymentService)
        {
            this._paymentService = paymentService;
        }
        [HttpGet("GetAveragePaymentValue")]
        public double GetAveragePaymentValue(int userId, DateTime startDate, DateTime endDate)
        {
            return _paymentService.GetAveragePaymentValue(userId, startDate, endDate);
        }
        [HttpGet("GetPaymentsInRange")]
        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice)
        {
            return _paymentService.GetPaymentsInRange(minPrice, maxPrice);
        }
    }
}
