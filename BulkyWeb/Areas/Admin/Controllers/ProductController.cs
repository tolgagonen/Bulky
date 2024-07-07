using BulkyWeb.Models;
using BulkyWeb.Models.ViewModels;
using BulkyWeb.Repository;
using BulkyWeb.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            
            return View(objProductList);
        }

        public IActionResult CreateP()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;
            ProductVM productVM = new()
            {
                CategoryList = CategoryList,
                Product = new Product()
            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateP(ProductVM obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj.Product);
            _unitOfWork.Save();
            TempData["success"] = "New product created successfully";
            return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                ViewBag.CategoryList = CategoryList;
                ProductVM productVM = new()
                {
                    CategoryList = CategoryList,
                    Product = new Product()
                };
                return View(productVM);
            }
            

        }

        public IActionResult EditP(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            ViewBag.CategoryList = CategoryList;
            ProductVM productVM = new ProductVM
            {
                CategoryList = CategoryList,
                Product = productFromDb // Edit işlemi için mevcut ürünü ProductVM içinde kullanın
            };

            return View(productVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditP(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj.Product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                ViewBag.CategoryList = CategoryList;
                ProductVM productVM = new()
                {
                    CategoryList = CategoryList,
                    Product = new Product()
                };
                return View(productVM);
            }
        }


        public IActionResult DeleteP(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product productFromDb = _unitOfWork.Product.Get(u => u.Id == id);
            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }


        [HttpPost, ActionName("DeleteP")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            Product obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
