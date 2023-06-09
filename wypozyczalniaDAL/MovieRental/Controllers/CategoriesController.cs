﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using wypozyczalniaDAL.Interfaces;
using wypozyczalniaDAL.Models;
using wypozyczalniaDAL.Repositories;

namespace MovieRental.Controllers
{
    public class CategoriesController : Controller
    {
        private IUnitOfWork unitOfWork;// = new UnitOfWork();

        public CategoriesController(MovieRentalContext context) { 
            this.unitOfWork = new UnitOfWork(context);
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = unitOfWork.CategoryRepository.GetCategories();//Get(includeProperties: "");
            return View(categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category category = unitOfWork.CategoryRepository.GetCategory(id);//GetByID(id);
            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CategoryRepository.InsertCategory(category);//Insert(category);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            Category category = unitOfWork.CategoryRepository.GetCategory(id);//GetByID(id);
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    unitOfWork.CategoryRepository.UpdateCategory(category);//Update(category);
                    unitOfWork.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            Category category = unitOfWork.CategoryRepository.GetCategory(id); //GetByID(id);
            return View(category);
        }

        

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = unitOfWork.CategoryRepository.GetCategory(id); //GetByID(id);
            unitOfWork.MovieRepository.DeleteMovie(id);//Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
