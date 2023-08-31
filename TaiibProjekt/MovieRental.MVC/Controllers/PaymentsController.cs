using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MovieRental.DAL.Interfaces;
using MovieRental.DAL.Models;
using MovieRental.DAL.Repositories;

namespace MovieRental.MVC.Controllers
{
    public class PaymentsController : Controller
    {
        private IUnitOfWork unitOfWork;

        public PaymentsController(MovieRentalContext context)
        {
            this.unitOfWork = new UnitOfWork(context);
        }

        // GET: Payments
        public IActionResult Index()
        {
            var payments = unitOfWork.PaymentRepository.GetPayments();
            return View(payments.ToList());
        }

        // GET: Payments/Details/5
        public IActionResult Details(int id)
        {
            if (id == null || unitOfWork.PaymentRepository.GetPayments() == null)
            {
                return NotFound();
            }

            Payment payment = unitOfWork.PaymentRepository.GetPayment(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            ViewData["RentId"] = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Payment payment)
        {
            ModelState.Remove("Rent");
            if (ModelState.IsValid)
            {
                var isFreeRent = unitOfWork.RentRepository.GetRent(payment.RentId);
                if (isFreeRent.Payment == null)
                {
                    unitOfWork.PaymentRepository.InsertPayment(payment);
                    unitOfWork.Save();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["RentId"] = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent", payment.RentId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null || unitOfWork.PaymentRepository.GetPayments() == null)
            {
                return NotFound();
            }

            var payment = unitOfWork.PaymentRepository.GetPayment(id);

            if (payment == null)
            {
                return NotFound();
            }
            ViewData["RentId"] = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent", payment.RentId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Payment payment)
        {
            if (id != payment.Id_Payment)
            {
                return NotFound();
            }
            ModelState.Remove("Rent");
            if (ModelState.IsValid)
            {
                try
                {
                    unitOfWork.PaymentRepository.UpdatePayment(payment);
                    unitOfWork.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentExists(payment.Id_Payment))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RentId"] = new SelectList(unitOfWork.RentRepository.GetRents(), "Id_Rent", "Id_Rent", payment.RentId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public IActionResult Delete(int id)
        {
            if (id == null || unitOfWork.PaymentRepository.GetPayments() == null)
            {
                return NotFound();
            }

            var payment = unitOfWork.PaymentRepository.GetPayment(id);

            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (unitOfWork.PaymentRepository.GetPayments() == null)
            {
                return Problem("Entity set 'MovieRentalContext.Payments'  is null.");
            }
            var payment = unitOfWork.PaymentRepository.GetPayment(id);
            if (payment != null)
            {
                unitOfWork.PaymentRepository.DeletePayment(payment.Id_Payment);
            }
            unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentExists(int id)
        {
          return (unitOfWork.PaymentRepository.GetPayments()?.Any(e => e.Id_Payment == id)).GetValueOrDefault();
        }
    }
}
