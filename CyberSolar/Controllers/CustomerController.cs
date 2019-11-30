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
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        Customer _customer = new Customer();

        [HttpGet]
        public ActionResult Add()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
            //default method
            //Category category = new Category();
            //category.Code = categoryViewModel.Code;
            //category.Name = categoryViewModel.Name;

            //automapper method
            Customer customer = Mapper.Map<Customer>(customerViewModel);

            string message = "";

            if (ModelState.IsValid)
            {
                if (_customerManager.Add(customer))
                {
                    message += "Saved!";
                    ModelState.Clear(); //sets the text box empty
                }
                else
                {
                    message += "Not Saved!!";
                }
            }

            ViewBag.Message = message;
            CustomerViewModel emptyModel = new CustomerViewModel() { Customers = _customerManager.GetAll() }; //emptyTextbox

            return View(emptyModel);
        }

        [HttpGet]
        public ActionResult Search()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.Customers = _customerManager.GetAll();


            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Search(CustomerViewModel customerViewModel)
        {
            string searchText = customerViewModel.SearchText;
            string message = "";
            CustomerViewModel resultModel = new CustomerViewModel();
            
            if (!String.IsNullOrEmpty(searchText))
            {
                var customers = _customerManager.GetAll();
                customers = customers.Where(c =>
                c.Name.ToLower().Contains(searchText.ToLower())
                || c.Contact.ToLower().Contains(searchText.ToLower())
                || c.Email.ToLower().Contains(searchText.ToLower())
                )
                .ToList();
                //categories = categories.Where(c => c.Name.ToLower().Contains(searchText.ToLower())).ToList();
                resultModel.Customers = customers;
                message = customers.Count + " result found";
                ModelState.Clear();
            }
            else
            {
                customerViewModel.Customers = new List<Customer>();
                message = "0 result found!";
            }

            ViewBag.Message = message;
            return View(resultModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _customerManager.GetById(id);

            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);

            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Customer customer = Mapper.Map<Customer>(customerViewModel);

                if (_customerManager.Update(customer))
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
            CustomerViewModel emptyModel = new CustomerViewModel() { Customers = _customerManager.GetAll() };

            return View(emptyModel);
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            var customer = _customerManager.GetById(id);

            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);

            customerViewModel.Customers = _customerManager.GetAll();

            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Delete(CustomerViewModel customerViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Customer customer = Mapper.Map<Customer>(customerViewModel);

                if (_customerManager.Delete(customer.Id))
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
            CustomerViewModel emptyModel = new CustomerViewModel(){Customers = _customerManager.GetAll()};

            return View(emptyModel);
        }
    }
}