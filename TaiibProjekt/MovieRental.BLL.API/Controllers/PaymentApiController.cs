using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.API.Models;
using MovieRental.BLL.Interfaces;
using MovieRental.BLL.Services;
using MovieRental.DAL.Models;
using System.Linq;

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
        public IActionResult GetUserAveragePaymentValue(int id)
        {
            var userAvgPayment = paymentService.GetUserAveragePaymentValue(id);
            return Ok(userAvgPayment);
        }
        [HttpGet("GetPaymentsInRange")]
        public IActionResult GetPaymentsInRange(double minPrice, double maxPrice)
        {
            var payments = paymentService.GetPaymentsInRange(minPrice, maxPrice);
            var result = new List<PaymentResponse>();
            foreach (var payment in payments) 
            {
                var paymentResponse = new PaymentResponse();
                var rentResponse = new RentResponse();
                if (payment.Rent != null) //
                {//
                    rentResponse.Id_Rent = payment.Rent.Id_Rent;//
                    rentResponse.RentingDate = payment.Rent.RentingDate;//
                }//
                //rentResponse.Id_Rent = payment.Rent.Id_Rent;
                //rentResponse.RentingDate = payment.Rent.RentingDate;
                paymentResponse.Id_Payment = payment.Id_Payment;
                paymentResponse.Price = payment.Price;
                paymentResponse.Rent = rentResponse;
                result.Add(paymentResponse);
            }
            return Ok(result);
        }
    }
}
