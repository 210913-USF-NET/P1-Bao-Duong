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
    public class ShopController : Controller
    {
        private IBl _bl;

        public ShopController(IBl bl)
        {
            this._bl = bl;
        }

        // GET: ShopController
        public ActionResult Index(bool flag)
        {
            if (flag == true)
            {
                List<CheckOut> checkOutList = _bl.GetCheckOutList();

                foreach(CheckOut item in checkOutList)
                {
                    _bl.DeleteCheckOut(item.Id);
                }

                flag = false;
            }

            List<Item> itemList = _bl.GetItemList();

            return View(itemList);
        }

        public ActionResult Buy(int id)
        {
            Item selectedItem = _bl.GetItemSizes(id);

            TempData["Item"] = selectedItem.Name;
            TempData["Price"] = (int)selectedItem.Price;
            
            return View(selectedItem.Size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(string size, int quant)
        {
            CheckOut checkOut = new CheckOut();

            checkOut.Item = (string)TempData["Item"];
            checkOut.Price = Convert.ToDecimal(TempData["Price"]);
            checkOut.Size = size;
            checkOut.Quantity = quant;

            List<Customer> customer = _bl.SearchCustomer((string)TempData["Username"]);

            checkOut.CustomerId = customer[0].Id;

            _bl.AddCheckOut(checkOut);

            return RedirectToAction("Index", "Shop");
        }

        public ActionResult Checkout()
        {
            List<CheckOut> checkOutList = _bl.GetCheckOutList();
            return View(checkOutList);
        }

        public ActionResult Receipt()
        {
            List<CheckOut> checkOutList = _bl.GetCheckOutList();
            Order order = new Order();


            return View(checkOutList);
        }
    }
}
