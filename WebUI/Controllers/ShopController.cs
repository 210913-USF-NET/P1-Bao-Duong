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
            List<Item> itemList = _bl.GetItemList();
            CheckOut checkOut = new CheckOut();

            foreach(Item item in itemList)
            {
                Item selectedItem = _bl.GetItemSizes(item.Id);

                foreach(Size sizes in selectedItem.Size)
                {
                    if (selectedItem.Name == (string)TempData["Item"] && sizes.ClothingSize == size)
                    {
                        if (quant > sizes.SizeQuantity)
                        {
                            TempData["msg"] = "<script>alert('Sorry we do not have that quantity');</script>";
                            return RedirectToAction("Buy", "Shop");
                        }
                    }
                }
            }

            checkOut.Item = (string)TempData["Item"];
            checkOut.Price = Convert.ToDecimal(TempData["Price"]);
            checkOut.Size = size;
            checkOut.Quantity = quant;

            List<Customer> customer = _bl.SearchCustomer((string)TempData["Username"]);

            checkOut.CustomerId = customer[0].Id;

            List<Store> storeList = _bl.GetStoreList();

            foreach(Store store in storeList)
            {
                Store selectedStore = _bl.GetStoreItem(store.Id);

                foreach(Item item in selectedStore.Item)
                {
                    if (item.Name == (string)TempData["Item"])
                    {
                        checkOut.StoreId = store.Id;
                        break;
                    }
                }
            }

            _bl.AddCheckOut(checkOut);

            TempData["Cart"] = _bl.GetCheckOutList().Count;

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
            List<Item> itemList = _bl.GetItemList();

            foreach (CheckOut checkOut in checkOutList)
            {
                Order order = new Order();

                order.CustomerId = checkOut.CustomerId;
                order.StoreId = checkOut.StoreId;

                _bl.AddOrder(order);

                foreach(Item item in itemList)
                {
                    Item selectedItem = _bl.GetItemSizes(item.Id);

                    foreach(Size size in selectedItem.Size)
                    {
                        if (selectedItem.Name == checkOut.Item && size.ClothingSize == checkOut.Size)
                        {
                            size.SizeQuantity -= checkOut.Quantity;

                            _bl.UpdateSize(size);
                        }
                    }
                }  
            }

            foreach (CheckOut item in checkOutList)
            {
                _bl.DeleteCheckOut(item.Id);
            }

            TempData["Cart"] = _bl.GetCheckOutList().Count;

            return View(checkOutList);
        }

        public ActionResult Delete(int id)
        {
            _bl.DeleteCheckOut(id);

            TempData["Cart"] = _bl.GetCheckOutList().Count;

            return RedirectToAction("Checkout", "Shop");
        }
    }
}
