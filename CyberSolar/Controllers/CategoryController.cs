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

        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();

            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            if (!String.IsNullOrEmpty(categoryViewModel.SearchText))
            {
                return RedirectToAction("Search", "Category", categoryViewModel);
            }

            Category category = Mapper.Map<Category>(categoryViewModel);
            category.Code = category.Code.ToUpper();

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
        //public ActionResult Search()
        //{
        //    CategoryViewModel categoryViewModel = new CategoryViewModel();
        //    categoryViewModel.Categories = _categoryManager.GetAll();
        //    return View(categoryViewModel);
        //}
        //[HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {
            string searchText = categoryViewModel.SearchText;
            string message = "";
            var categories = _categoryManager.GetAll();
            CategoryViewModel resultModel = new CategoryViewModel();
            if (searchText != null)
            {
                categories = categories.Where(
                        c => c.Code.ToLower().Contains(searchText.ToLower()) 
                            || c.Name.ToLower().Contains(searchText.ToLower())
                        ).ToList();
                //categories = categories.Where(c => c.Name.ToLower().Contains(searchText.ToLower())).ToList();
                message = categories.Count + " result found!";
                resultModel.Categories = categories;
                ModelState.Clear();
            }
            else
            {
                resultModel.Categories = new List<Category>();
                message = "0 result found!";
            }
            ViewBag.Message = message;

            return View(resultModel);
        }

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
                    TempData["Message"] = message;
                    return RedirectToAction("Add", "Category");
                }
                else
                {
                    message = "Not Updated";
                }
            }

            ViewBag.Message = message;
            CategoryViewModel categoryViewModel = new CategoryViewModel() { Categories = _categoryManager.GetAll() };
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
                    TempData["Message"] = message;
                    return RedirectToAction("Add", "Category");
                }
                else
                {
                    message = "Not Deleted";
                }
            }

            ViewBag.Message = message;
            CategoryViewModel categoryViewModel = new CategoryViewModel() { Categories = _categoryManager.GetAll() };
            return View(categoryViewModel);
        }

        public JsonResult IsNameExists(string Name)
        {
            List<Category> categories = _categoryManager.GetAll();
            JsonResult isUnique = Json(categories.All(c => c.Name.ToLower() != Name.ToLower()), JsonRequestBehavior.AllowGet);

            return isUnique;
        }

        public JsonResult IsCodeExists(string Code)
        {
            List<Category> categories = _categoryManager.GetAll();
            JsonResult isUnique = Json(categories.All(c => c.Code.ToLower() != Code.ToLower()), JsonRequestBehavior.AllowGet);

            return isUnique;
        }
    }
}