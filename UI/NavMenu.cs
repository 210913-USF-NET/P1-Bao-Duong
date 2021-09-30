using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;

namespace UI
{
    public class NavMenu : IMenu
    {
        private IBl _bl;

        public NavMenu(IBl bl) {
            this._bl = bl;
        }
        public void Start()
        {
            bool loop = true;
            string input;

            Console.Clear();
            do {
                Console.WriteLine($"Welcome: {DisplayUsername.Username}");
                Console.WriteLine("\n[0] Shop");
                Console.WriteLine("[1] Store");
                Console.WriteLine("[x] Logout");

                input = Console.ReadLine();

                switch (input) {
                    case "0":
                        MenuFactory.GetMenu("shop").Start();
                        break;
                    case "1":
                        MenuFactory.GetMenu("store").Start();
                        break;
                    case "x":
                        loop = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (loop);
        }
    }
}