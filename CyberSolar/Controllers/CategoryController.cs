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
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
        Category _category = new Category();

        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            //default method
            //Category category = new Category();
            //category.Code = categoryViewModel.Code;
            //category.Name = categoryViewModel.Name;

            //automapper method
            Category category = Mapper.Map<Category>(categoryViewModel);

            string message="";

            if (_categoryManager.Add(category))
            {
                message += "Saved!";
            }
            else
            {
                message += "Not Saved!!";
            }

            categoryViewModel.Categories = _categoryManager.GetAll();
            ViewBag.Message = message;
            return View(categoryViewModel);
        }
    }
}