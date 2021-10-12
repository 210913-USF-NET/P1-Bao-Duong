using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private IBl _bl;

        public HomeController(ILogger<HomeController> logger, IBl bl)
        {
            _logger = logger;
            _bl = bl;
        }

        public IActionResult Index(bool flag)
        {
            if (flag == true)
            {
                TempData["Username"] = null;
                flag = false;
            }

            List<CheckOut> checkOutList = _bl.GetCheckOutList();

            foreach(CheckOut item in checkOutList)
            {
                _bl.DeleteCheckOut(item.Id);
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
