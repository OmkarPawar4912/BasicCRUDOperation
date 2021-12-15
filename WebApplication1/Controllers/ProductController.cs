using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public static List<Product> Products = new List<Product>();
        public IActionResult Index()
        {
            return View(Products);
        }

        [HttpGet]
        [Route("Create")] //Form input
        public IActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        [Route("Create")] //Data Save 
        public IActionResult Create(Product product)
        {
            Products.Add(product);
            return RedirectToAction("Index", Products);
        }

        [HttpGet]
        [Route("Edit")] // Display Value For Edit
        public IActionResult Edit(int id)
        {
            Product product = Products.Where(p => p.Id.Equals(id)).Select(s => s).FirstOrDefault();
            return View(product);
        }

        [HttpPost]
        [Route("Edit")] // Updated Data Save 
        public IActionResult Update(Product product)
        {
            Product originalProduct = Products.Where(w => w.Id == product.Id).FirstOrDefault();
            if (originalProduct != null)
            {
                originalProduct.Name = product.Name;
                originalProduct.ExpiryDate = product.ExpiryDate;
            };
            return RedirectToAction("Index", Products);
        }

        [HttpGet]
        [Route("Details")] // Display Details
        public IActionResult Details(int id)
        {
            Product product = Products.Where(p => p.Id.Equals(id)).Select(s => s).FirstOrDefault();
            return View(product);
        }

        [Route("Delete")] // Delete Data
        public ActionResult Delete(int id)
        {
            Product originalProducts = Products.Find(c => c.Id == id);
            Products.Remove(originalProducts);
            return View("Index",Products);
        }
    }
}
