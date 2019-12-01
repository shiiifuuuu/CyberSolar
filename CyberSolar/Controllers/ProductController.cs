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

        private void CategoryDropDownLoad(ProductViewModel productViewModel)
        {
            productViewModel.CategorySelectListItems = _categoryManager.GetAll()
                .Select(c => new SelectListItem() { Value = c.Id.ToString(), Text = c.Name }).ToList();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel(){Products = _productManager.GetAll()};

            CategoryDropDownLoad(productViewModel);
            
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            if (!String.IsNullOrEmpty(productViewModel.SearchText))
            {
                return RedirectToAction("Search", "Product", productViewModel);
            }

            Product product = Mapper.Map<Product>(productViewModel); //first modify the Global.asax file

            string message = "";

            if (ModelState.IsValid)
            {
                if (_productManager.Add(product))
                {
                    message = "Saved!";
                    ModelState.Clear();
                }
                else
                {
                    message = "Not Saved!!";
                }
            }
            ViewBag.Message = message;

            ProductViewModel emptyModel = new ProductViewModel() { Products = _productManager.GetAll() };
            CategoryDropDownLoad(emptyModel);
            return View(emptyModel);
        }

        [HttpGet]
        //public ActionResult Search()
        //{
        //    ProductViewModel productViewModel = new ProductViewModel();
        //    productViewModel.Products = _productManager.GetAll();


        //    return View(productViewModel);
        //}

        //[HttpPost]
        public ActionResult Search(ProductViewModel productViewModel)
        {
            string searchText = productViewModel.SearchText;
            string message = "";
            var products = _productManager.GetAll();
            ProductViewModel resultModel = new ProductViewModel();
            if (!String.IsNullOrEmpty(searchText))
            {
                products = products.Where(c => c.Code.Contains(searchText) 
                                               || c.Name.ToLower().Contains(searchText.ToLower()) 
                                               || c.Category.Name.ToLower().Contains(searchText.ToLower())).ToList();
                message = products.Count + " result found!";
                resultModel.Products = products;
                ModelState.Clear();
            }
            else
            {
                resultModel.Products = new List<Product>();
                message = "0 result found!";
            }

            ViewBag.Message = message;

            return View(resultModel);
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
                CategoryDropDownLoad(productViewModel);
                if (_productManager.Update(product))
                {
                    message = "Updated";
                    ModelState.Clear();
                }
                else
                {

                    message = "Not Updated";
                }
            }

            TempData["Message"] = message;
            return RedirectToAction("Add", "Product");
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
                CategoryDropDownLoad(productViewModel);
                if (_productManager.Delete(product.Id))
                {
                    message = "Deleted";
                }
                else
                {
                    message = "Not Deleted";
                }
            }

            TempData["Message"] = message;
            return RedirectToAction("Add", "Product");
        }

        public JsonResult IsCodeExists(string Code)
        {
            List<Product> products = _productManager.GetAll();
            //check if any of the UserName matches the UserName specified in the Parameter using the ANY extension method.  

            JsonResult isUnique = Json(products.All(c => c.Code != Code), JsonRequestBehavior.AllowGet);

            return isUnique;
        }

        public JsonResult IsNameExists(string Name)
        {
            List<Product> products = _productManager.GetAll();
            JsonResult isUnique = Json(products.All(c => c.Name != Name), JsonRequestBehavior.AllowGet);

            return isUnique; // if isNotUnique then a error message will display
        }
    }
}