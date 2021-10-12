using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {
        private IBl _bl;

        public CustomerController(IBl bl)
        {
            this._bl = bl;
        }

        // GET: CustomerController
        public ActionResult Index()
        {
            List<Customer> customer = _bl.GetCustomerList();

            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string name)
        {
            List<Customer> customer = _bl.SearchCustomer(name);

            return View(customer);
        }

        public ActionResult Order(int id)
        {
            List<Order> orderList = _bl.GetOrderList();

            foreach(Order order in orderList)
            {
                if (id == order.CustomerId)
                {
                    Order selectedOrder = _bl.GetOrderStore(order.Id);

                    TempData["Name"] = selectedOrder.Customers.Username;

                }

                
            }

            return View(orderList);
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
