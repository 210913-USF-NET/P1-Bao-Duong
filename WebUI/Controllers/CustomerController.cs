using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

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
            OrderVM orderVM = new OrderVM();
            List<OrderVM> orderVMList = new List<OrderVM>();

            foreach(Order order in orderList)
            {
                if (id == order.CustomerId)
                {
                    Order selectedOrder = _bl.GetOrderStore(order.Id);

                    Store selectedStore = _bl.GetStoreItem(selectedOrder.StoreId);

                    orderVM.Username = selectedOrder.Customers.Username;
                    orderVM.Item = selectedStore.Item[0].Name;
                    orderVM.Price = selectedStore.Item[0].Price;
                    orderVM.Address = selectedStore.Address;
                    orderVM.City = selectedStore.City;
                    orderVM.State = selectedStore.State;

                    orderVMList.Add(new OrderVM()
                    {
                        Username = orderVM.Username,
                        Item = orderVM.Item,
                        Price = orderVM.Price,
                        Address = orderVM.Address,
                        City = orderVM.City,
                        State = orderVM.State
                    });
                }

                
            }

            return View(orderVMList);
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
