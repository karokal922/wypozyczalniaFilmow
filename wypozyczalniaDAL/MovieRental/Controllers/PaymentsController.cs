using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.Models;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace MovieRental.Controllers
{
    //[Route("api/[controller]")]
    public class PaymentsController : Controller
    {
        //private UnitOfWork unitOfWork = new UnitOfWork();

        private IUnitOfWork unitOfWork;// = new UnitOfWork();

        public PaymentsController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        //GET: Payments
        public ActionResult Index()
        {
            var payments = unitOfWork.PaymentRepository.GetPayments();//Get(includeProperties: "");
            return View(payments.ToList());
        }
        [HttpGet]
        [Route("api/payments")]
        public IEnumerable<PaymentResponse> Get()
        {
            var payments = unitOfWork.PaymentRepository.GetPayments();
            return payments.Select(x => new PaymentResponse(x.Id_Payment, x.Price));
        }

        // GET: Payments/Details/5
        public ActionResult Details(int id)
        {
            Payment payment = unitOfWork.PaymentRepository.GetPayment(id);//GetByID(id);
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.PaymentRepository.InsertPayment(payment);//Insert(payment);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int id)
        {
            Payment payment = unitOfWork.PaymentRepository.GetPayment(id); //GetByID(id);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Payment payment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.PaymentRepository.UpdatePayment(payment);//Update(payment);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int id)
        {
            Payment payment = unitOfWork.PaymentRepository.GetPayment(id); //GetByID(id);
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = unitOfWork.PaymentRepository.GetPayment(id); //GetByID(id);
            unitOfWork.PaymentRepository.DeletePayment(id);//Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        //private bool PaymentExists(int id)
        //{
        //  return (unitOfWork.PaymentRepository.Get.Any(e => e.Id_Payment == id)).GetValueOrDefault();
        //}
    }
}
