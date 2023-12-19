using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using shoppingcart.Models;
using shoppingcart.Views.utlility;
using ShoppingCart.Data;
using System.Security.Cryptography.X509Certificates;

namespace shoppingcart.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ShoppingCartContext _context;
        private readonly IToastNotification _toastNotification;
        public CategoryController(ShoppingCartContext context, IToastNotification toastNotification)
        {
            _context = context;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var data = _context.Category.ToList();
            return View(data);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(Category Category)

        {
            if (Category! == null && Category.Name.ToLower().Contains(ConstantValues.TestData.ToLower()))
            {
                ModelState.AddModelError("Name", "Test is not valid input");
            }
            if (ModelState.IsValid)
            {
                _context.Category.Add(Category);
                _context.SaveChanges();
                return View("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var data = _context.Category.Find(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (category != null)
            {
                _context.Category.Update(category);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Category Updated Successfully");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }
            var data = _context.Category.Find(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id, string name)
        {
            var data = _context.Category.Where(i => (i.CategoryId == id && i.Name == name)).FirstOrDefault();
            if (data != null)
            {
                _context.Category.Remove(data);
                _context.SaveChanges();
                _toastNotification.AddSuccessToastMessage("Category Deleted Successfully");
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}


