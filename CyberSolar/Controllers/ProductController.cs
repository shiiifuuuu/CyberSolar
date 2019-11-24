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

        private void CategoryDropDownLoad(ProductViewModel productViewModel)
        {
            productViewModel.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();

            CategoryDropDownLoad(productViewModel);

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

        [HttpGet]
        public ActionResult Search()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();


            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Search(string searchText)
        {
            var products = _productManager.GetAll();

            if (searchText != null)
            {
                products = products.Where(c => c.Code.Contains(searchText) || c.Name.ToLower().Contains(searchText.ToLower()) || c.CategoryName.ToLower().Contains(searchText.ToLower())).ToList();
            }

            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = products;

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _productManager.GetById(id);

            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);
            CategoryDropDownLoad(productViewModel);
            productViewModel.Products = _productManager.GetAll();

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Update(product))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            productViewModel.Products = _productManager.GetAll();

            return View(productViewModel);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var product = _productManager.GetById(id);

            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);
            CategoryDropDownLoad(productViewModel);
            productViewModel.Products = _productManager.GetAll();

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Delete(ProductViewModel productViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Delete(product.Id))
                {
                    message = "Deleted";
                }
                else
                {
                    message = "Not Deleted";
                }
            }
            else
            {
                message = "Model State False!!";
            }

            ViewBag.Message = message;
            productViewModel.Products = _productManager.GetAll();

            return View(productViewModel);
        }
    }
}