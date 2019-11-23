using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using CyberSolar.BLL.Manager;
using CyberSolar.Models;
using CyberSolar.MODEL.Model;

namespace CyberSolar.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        Product _product = new Product();

        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();

            CategoryDropDownLoad(productViewModel);

            //var products = productViewModel.Products;
            //var categories = _categoryManager.GetAll();

            //var qResult = from p in products
            //    join c in categories
            //        on p.CategoryId equals c.Id
            //    select new { p, c };

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            Product product = Mapper.Map<Product>(productViewModel); //first modify the Global.asax file

            var categories = _categoryManager.GetAll();
            //Select Id, Name from Category where product.CategoryId=Id;
            var qResult = from c in categories where c.Id == product.CategoryId select c;

            foreach (var category in qResult)
            {
                product.CategoryName = category.Name;
            }

            string message = "";

            if (ModelState.IsValid)
            {
                if (_productManager.Add(product))
                {
                    message += "Saved!";
                }
                else
                {
                    message += "Not Saved!!";
                }
            }
            productViewModel.Products = _productManager.GetAll();
            CategoryDropDownLoad(productViewModel);
            ViewBag.Message = message;
            return View(productViewModel);
        }

        private void CategoryDropDownLoad(ProductViewModel productViewModel)
        {
            productViewModel.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }
    }
}