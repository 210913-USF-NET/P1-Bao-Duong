using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using StoreBL;

namespace UI
{
    public class StoreMenu : IMenu
    {
        private IBl _bl;
        private ItemService _itemService;

        public StoreMenu(IBl bl, ItemService itemService)
        {
            this._bl = bl;
            this._itemService = itemService;
        }

        public void Start()
        {
            Console.Clear();

            bool flag = true;

            List<CheckOut> checkOut = new List<CheckOut>();
            List<Store> storeId = new List<Store>();
            Size size = new Size();
            
            do {
                Console.WriteLine($"Welcome: {DisplayUsername.Username}");
                List<Item> searchItem = _bl.GetStore();
                Item selectedItem = _itemService.SelectItem("\nWhat would you like to purchase today? ([x] to exit)", searchItem);

                if (selectedItem == null) {
                    Console.Clear();
                    break;
                }

                selectedItem = _bl.GetOneItemById(selectedItem.Id);
                
                selectSize:
                Console.Clear();

                System.Console.WriteLine("Please select your size");
                System.Console.WriteLine();

                for (int i = 0; i < selectedItem.Size.Count; i++) {
                    System.Console.WriteLine($"[{i}] {selectedItem.Size[i]}");
                }

                System.Console.WriteLine();

                string input = Console.ReadLine();
                int parsedInput;
                bool parseSuccess = Int32.TryParse(input, out parsedInput);

                if(parseSuccess && parsedInput >= 0 && parsedInput < selectedItem.Size.Count) {
                    inputQuant:
                    Console.Clear();
                    System.Console.WriteLine($"Please select your quantity. (Only {selectedItem.Size[parsedInput].SizeQuantity} in stock!)");
                    System.Console.WriteLine();
                    int quant = Convert.ToInt32(Console.ReadLine());

                    if (quant > selectedItem.Size[parsedInput].SizeQuantity) {
                        goto inputQuant;
                    }
                    
            
                    Store store = _bl.GetOneStoreById(selectedItem.Id);
                    storeId.Add(new Store() {Id = store.Id});
                    checkOut.Add(new CheckOut() {Id = selectedItem.Id, Item = selectedItem.Name, Price = selectedItem.Price, Size = selectedItem.Size[parsedInput].ClothingSize, Quantity = quant, TotalQuantity = selectedItem.Size[parsedInput].SizeQuantity - quant});
                    
                    Console.Clear();
                    System.Console.WriteLine("Would you like to checkout? y/n");
                    System.Console.WriteLine();
                    char cart = Console.ReadLine()[0];

                    if (cart == 'y' || cart == 'Y') {
                        
                        CheckOut(checkOut, storeId, quant, size);
                    }
                }
                else {
                    Console.WriteLine("invalid input");
                    goto selectSize;
                }
            } while (flag);
        }

        private void CheckOut(List<CheckOut> items, List<Store> stores, int quant, Size size)
        {
            Order order = new Order();
            List<Order> orderIdList = new List<Order>();

            decimal total = 0;

            Console.Clear();

            System.Console.WriteLine("This is your cart!\n");
            for (int i = 0; i < items.Count; i++) {
                System.Console.WriteLine(items[i]);
                
                for (int j = 0; j < items[i].Quantity; j++) {
                    total += items[i].Price;
                }
            }

            System.Console.WriteLine();
            System.Console.WriteLine($"Total: {total.ToString("C")}");

            System.Console.WriteLine("\nPurchase? y/n");
            System.Console.WriteLine();
            char input = Console.ReadLine()[0];

            if (input == 'y') {
                order.CustomerId = DisplayUsername.Id;

                for (int i = 0; i < stores.Count; i++) {
                    order.StoreId = stores[i].Id;

                    _bl.AddOrder(order);
                    orderIdList.Add( new Order() {Id = order.Id});
                }
                
                receipt(items, stores, quant, size);
                
            }

        }

        private void receipt(List<CheckOut> items, List<Store> stores, int quant, Size size)
        {
            Console.Clear();

            System.Console.WriteLine("Here is your receipt!");
            System.Console.WriteLine();

            System.Console.WriteLine($"Username: {DisplayUsername.Username} Email: {DisplayUsername.Email}");
            
            foreach(CheckOut item in items) {
                System.Console.WriteLine(item);
            }

            for (int i = 0; i < items.Count; i++) {
                size.ClothingSize = items[i].Size;
                size.SizeQuantity = items[i].TotalQuantity;
                size.ItemId = items[i].Id;
                _bl.UpdateSize(size);
            }

            System.Console.WriteLine();
        }
    }
}