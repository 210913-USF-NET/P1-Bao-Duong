using System;
using System.Collections.Generic;
using StoreBL;
using Models;

namespace UI {
    public class InventoryMenu : IMenu {
        private IBl _bl;

        public InventoryMenu(IBl bl) {
            this._bl = bl;
        }

        public void Start() {
            bool loop = true;
            string input;

            Console.Clear();
            do {
                
                Console.WriteLine("Iventory menu:");
                Console.WriteLine("\n[0] View tops");
                Console.WriteLine("[1] View bottoms");
                Console.WriteLine("[2] View footwears");
                Console.WriteLine("[x] Go back to main menu");

                input = Console.ReadLine();

                switch (input) {
                    case "0":
                        ViewAllTop();
                        break;
                    case "1":
                        ViewAllBottom();
                        break;
                    case "2":
                        ViewAllFootwear();
                        break;
                    case "x":
                        loop = false;
                        Console.Clear();
                        break;
                    default:
                        break;
                }

            } while (loop);
        }

        private void ViewAllTop() {
            Console.Clear();
            List<Top> allTop = _bl.GetAllTop();      

            foreach(Top top in allTop) {
                Console.WriteLine(top.ToString());
            }
        }

        private void ViewAllBottom() {
            Console.WriteLine("Needs implementation");
        }

        private void ViewAllFootwear() {
            Console.WriteLine("Needs implementation");
        }
    }
}