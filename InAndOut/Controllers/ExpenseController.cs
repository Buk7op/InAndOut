using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ExpenseController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> objList = _context.Expenses;
            return View(objList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryDropDown = _context.Categories.Select(i => new SelectListItem
            {
                Text = i.CategoryName,
                Value = i.Id.ToString()
            });

            ViewBag.CategoryDropDown = CategoryDropDown;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense obj)
        {
            if(ModelState.IsValid)
            {
                _context.Expenses.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(obj);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.Expenses.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _context.Expenses.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.Expenses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Expense obj)
        {
            if (ModelState.IsValid)
            {
                _context.Expenses.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }
    }
}
