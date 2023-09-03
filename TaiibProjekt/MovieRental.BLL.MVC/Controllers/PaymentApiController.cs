using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.Services;
using MovieRental.DAL.Models;

namespace MovieRental.BLL.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentApiController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymentApiController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
        [HttpGet("GetUserAveragePaymentValue")]
        public UserAveragePaymentResult GetUserAveragePaymentValue(int userId)
        {
            return paymentService.GetUserAveragePaymentValue(userId);
        }
        [HttpGet("GetPaymentsInRange")]
        public IEnumerable<Payment> GetPaymentsInRange(double minPrice, double maxPrice)
        {
            return paymentService.GetPaymentsInRange(minPrice, maxPrice);
        }
    }
}
