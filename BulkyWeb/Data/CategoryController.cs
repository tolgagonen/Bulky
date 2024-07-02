﻿using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Data
{
    public class CategoryController : Controller
    {
        public readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create2(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder can't match the name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if ((categoryFromDb == null))
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
             
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category categoryFromDb = _db.Categories.Find(id);
            if ((categoryFromDb == null))
            {
                return NotFound();
            }


            return View(categoryFromDb);
        }
        [HttpPost,ActionName("Delete")] // aynı delete aksiyon metodunu arıyacağı için ActionName("Delete") kullandık.
        public IActionResult DeletePOST(int? id) //Parametlerer aynı olacağı iççin DELETEPOST yaptık
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
           

        }

    }
}
