using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieRental.BLL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;

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
        private static int RentID = 0;
        public IActionResult Create(int idRent)
        {
            RentID = idRent;
            ViewData["RentId"] = new SelectList(paymentService.GetAllRents().Where(r => r.Id_Rent == idRent), "Id_Rent", "Id_Rent", idRent);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Payment payment)
        {
            ModelState.Remove("Rent");
            if (ModelState.IsValid)
            {
                var rent = paymentService.GetAllRents().Where(r => r.Id_Rent == RentID).FirstOrDefault();
                if (rent != null)
                {
                    payment.Rent = rent;
                    int? result = paymentService.CreatePayment(payment);
                    if (result != null)
                    {
                        return RedirectToAction(nameof(Index), "Rent");
                    }
                    ViewData["CreatingError"] = "Something went wrong with payment.";
                }
            }
            ViewData["RentId"] = new SelectList(paymentService.GetAllRents().Where(r => r.Id_Rent == RentID), "Id_Rent", "Id_Rent", RentID);
            return View(payment);
        }
    }
}
