using System;
using System.Collections.Generic;
using Models;
using StoreBL;

namespace UI
{
    public class LocationMenu : IMenu 
    {
        private IBl _bl;

        public LocationMenu(IBl bl)
        {
            this._bl = bl;
        }

        public void Start()
        {
            Console.Clear();
            System.Console.WriteLine("Here are our locations!\n");

            do {
                

                List<Store> storeList = _bl.GetStores();

                selectStore:

                for (int i = 0; i < storeList.Count; i++) {
                    System.Console.WriteLine($"[{i}] {storeList[i]}");
                }

                System.Console.WriteLine("[x] Exit\n");

                string input = Console.ReadLine();

                if (input == "X" || input == "x") {
                    Console.Clear();
                    break;
                }

                int parsedInput;
                bool parseSuccess = Int32.TryParse(input, out parsedInput);

                if(parseSuccess && parsedInput >= 0 && parsedInput < storeList.Count) {
                    Store store = storeList[parsedInput];

                    Item item = _bl.GetOneItemById(store.Id);

                    Console.Clear();
                    System.Console.WriteLine("Here's our inventory for this location!\n");
                    System.Console.WriteLine($"Inventory: {item}");
                    System.Console.WriteLine();
                }
                else {
                    Console.WriteLine("invalid input");
                    goto selectStore;
                }
            } while (true);
        }
    }
}