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

            string message = "";

            if (ModelState.IsValid)
            {
                if (_categoryManager.Add(category))
                {
                    message += "Saved!";
                    ModelState.Clear();
                }
                else
                {
                    message += "Not Saved!!";
                }
            }
            ViewBag.Message = message;

            CategoryViewModel emptyModel = new CategoryViewModel();
            emptyModel.Categories = _categoryManager.GetAll();
            return View(emptyModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();


            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {
            string searchText = categoryViewModel.SearchText;
            string message = "";
            var categories = _categoryManager.GetAll();

            if (searchText != null)
            {
                categories = categories.Where(c => c.Code.Contains(searchText) || c.Name.ToLower().Contains(searchText.ToLower())).ToList();
                //categories = categories.Where(c => c.Name.ToLower().Contains(searchText.ToLower())).ToList();
                message = categories.Count + " result found!";
                ModelState.Clear();
            }
            else
            {
                message = "0 result found!";
            }

            ViewBag.Message = message;

            CategoryViewModel emptyModel = new CategoryViewModel();
            emptyModel.Categories = categories;

            return View(emptyModel);
        }

        //[HttpPost]
        //public ActionResult Search(CategoryViewModel categoryViewModel)
        //{
        //    var categories = _categoryManager.GetAll();

        //    if (categoryViewModel.Code != null)
        //    {
        //        categories = categories.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();
        //    }

        //    if (categoryViewModel.Name != null)
        //    {
        //        categories = categories.Where(c => c.Name.ToLower().Contains(categoryViewModel.Name.ToLower())).ToList();
        //    }

        //    categoryViewModel.Categories = categories;


        //    return View(categoryViewModel);
        //}

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var category = _categoryManager.GetById(id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel _categoryViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(_categoryViewModel);

                if (_categoryManager.Update(category))
                {
                    message = "Updated";
                    ModelState.Clear();
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
            CategoryViewModel categoryViewModel = new CategoryViewModel(){Categories = _categoryManager.GetAll() };
            /*categoryViewModel.Categories = _categoryManager.GetAll()*/;

            return View(categoryViewModel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var category = _categoryManager.GetById(id);

            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Delete(CategoryViewModel _categoryViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(_categoryViewModel);

                if (_categoryManager.Delete(category.Id))
                {
                    message = "Deleted";
                    ModelState.Clear();
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
            CategoryViewModel categoryViewModel = new CategoryViewModel(){Categories = _categoryManager.GetAll()};
            //_categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }

        public JsonResult IsNameExists(string Name)
        {
            List<Category> categories = _categoryManager.GetAll();
            return Json(!categories.Any(c => c.Name == Name), JsonRequestBehavior.AllowGet);
        }

        public JsonResult IsCodeExists(string Code)
        {
            List<Category> categories = _categoryManager.GetAll();
            return Json(!categories.Any(c => c.Code == Code), JsonRequestBehavior.AllowGet);
        }
    }
}