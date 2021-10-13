using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Serilog;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class StoreController : Controller
    {

        private IBl _bl;

        public StoreController(IBl bl)
        {
            this._bl = bl;
        }

        // GET: StoreController
        public ActionResult Index()
        {
            List<Store> storeList = _bl.GetStoreList();
            return View(storeList);
        }

        public ActionResult Inventory(int id)
        {
            Store selectedStore = _bl.GetStoreItem(id);

            return View(selectedStore.Item);
        }

        public ActionResult Size(int id)
        {
            Item selectedItem = _bl.GetItemSizes(id);

            return View(selectedItem.Size);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Size(int id, int refill)
        {
            List<Size> sizeList = _bl.GetSizeList();

            foreach(Size size in sizeList)
            {
                if (size.Id == id)
                {
                    size.SizeQuantity = refill;
                    _bl.UpdateSize(size);

                    Log.Information("Replenish successful..");
                    return RedirectToAction("Size", "Store");
                }
            }

            return View();
        }
    }
}
