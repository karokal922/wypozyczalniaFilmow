using Microsoft.AspNetCore.Mvc;
using MovieRental.BLL.Interfaces;

namespace MovieRental.BLL.MVC.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowPaymentsInRange(double min_price, double max_price)
        {
            ViewBag.PaymentsInRange = paymentService.GetPaymentsInRange(min_price, max_price);
            return View("Index");
        }

        public IActionResult ShowAveragePaymentValueForUser(int userId)
        {
            ViewBag.AveragePayment = paymentService.GetUserAveragePaymentValue(userId);
            return View("Index");
        }
    }
}
