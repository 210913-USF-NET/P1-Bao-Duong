using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private IBl _bl;

        public LoginController(IBl bl)
        {
            this._bl = bl;
        }

        // GET: LoginController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            try
            {
                List<Customer> customerList = _bl.GetCustomerList();
                bool isUsername = CorrectUsername(customer.Username);
                bool isPassword = CorrectPassword(customer.Password);

                if (!isUsername)
                {
                    Log.Information("Fail login..");
                    ModelState.AddModelError("UsernameError", "Username is Incorrect");
                    return View(customer);
                }
                if (!isPassword)
                {
                    Log.Information("Fail login..");
                    ModelState.AddModelError("PasswordError", "Password is Incorrect");
                    return View(customer);
                }

                foreach (Customer cust in customerList)
                {
                    if (customer.Username == cust.Username && customer.Password == cust.Password)
                    {
                        Log.Information("Successful login..");
                        TempData["Username"] = customer.Username;
                        TempData.Keep("Username");

                        List<CheckOut> checkOutList = _bl.GetCheckOutList();

                        foreach (CheckOut item in checkOutList)
                        {
                            _bl.DeleteCheckOut(item.Id);
                        }

                        return RedirectToAction("Index", "Home");
                    }
                }

                Log.Information("Fail login..");
                ModelState.AddModelError("UsernameError", "Username is Incorrect");
                ModelState.AddModelError("PasswordError", "Password is Incorrect");
                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {    
                    bool isUsername = UsernameExist(customer.Username);
                    bool isEmail = EmailExist(customer.Email);

                    if (isUsername)
                    {
                        Log.Information("Fail signup..");
                        ModelState.AddModelError("UsernameExist", "Username is already taken");
                        return View(customer);
                    }
                    if (isEmail)
                    {
                        Log.Information("Fail signup..");
                        ModelState.AddModelError("EmailExist", "Email is already taken");
                        return View(customer);
                    }

                    Log.Information("Successful user creation..");
                    _bl.AddCustomer(customer);
                    return RedirectToAction("Index", "Login");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        [NonAction]
        public bool UsernameExist(string username)
        {
            bool flag = false;

            List<Customer> cust = _bl.GetCustomerList();

            for (int i = 0; i < cust.Count; i++)
            {
                if (username == cust[i].Username)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        [NonAction]
        public bool EmailExist(string email)
        {
            bool flag = false;

            List<Customer> cust = _bl.GetCustomerList();

            for (int i = 0; i < cust.Count; i++)
            {
                if (email == cust[i].Email)
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        [NonAction]
        public bool CorrectUsername(string username)
        {
            bool flag = true;

            List<Customer> cust = _bl.GetCustomerList();

            for (int i = 0; i < cust.Count; i++)
            {
                if (username != cust[i].Username)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }

        public bool CorrectPassword(string password)
        {
            bool flag = true;

            List<Customer> cust = _bl.GetCustomerList();

            for (int i = 0; i < cust.Count; i++)
            {
                if (password != cust[i].Password)
                {
                    flag = false;
                }
                else
                {
                    flag = true;
                    break;
                }
            }

            return flag;
        }
    }
}
