using Microsoft.AspNetCore.Mvc;
using MovieRentalBLL.Interfaces;
using MovieRentalBLL.Services;

namespace TestBLL.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this._paymentService = paymentService;
            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPaymentsInRange(double min_price,double max_price)
        {
            ViewBag.PaymentsInRange = _paymentService.GetPaymentsInRange(min_price, max_price);
            return View("Index");
        }

        public IActionResult ShowAveragePaymentValueForUser(int userId, DateTime startDate, DateTime endDate)
        {
            ViewBag.AveragePayment = _paymentService.GetAveragePaymentValue(userId,startDate,endDate);
            return View("Index");
        }
    }
}
