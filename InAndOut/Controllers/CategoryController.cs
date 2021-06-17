using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class CategoryController : Controller
    {
        
            private readonly ApplicationDbContext _context;
            public CategoryController(ApplicationDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                IEnumerable<Category> objList = _context.Categories;
                return View(objList);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Category obj)
            {
                if (ModelState.IsValid)
                {
                    _context.Categories.Add(obj);
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
                var obj = _context.Categories.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult DeletePost(int? id)
            {
                var obj = _context.Categories.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                _context.Categories.Remove(obj);
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
                var obj = _context.Categories.Find(id);
                if (obj == null)
                {
                    return NotFound();
                }
                return View(obj);
            }
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Update(Category obj)
            {
                if (ModelState.IsValid)
                {
                    _context.Categories.Update(obj);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(obj);
            }
        
    }
}
