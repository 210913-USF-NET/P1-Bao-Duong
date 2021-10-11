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
        public ActionResult Index()
        {

            List<Item> itemList = _bl.GetItemList();

            TempData.Keep();

            return View(itemList);
        }

        public ActionResult Buy(int id)
        {
            Item selectedItem = _bl.GetItemSizes(id);

            return View(selectedItem.Size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy(string size, int quant)
        {
            

            return RedirectToAction("Index", "Shop");
        }

        public ActionResult Checkout()
        {

            return View();
        }

        // GET: ShopController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ShopController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ShopController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopController/Delete/5
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
