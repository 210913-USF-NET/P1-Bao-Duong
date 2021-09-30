using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;

namespace UI
{
    public class AdminMenu : IMenu
    {
        private IBl _bl;
        private ItemService _itemService;

        public AdminMenu(IBl bl, ItemService itemService)
        {
            this._bl = bl;
            this._itemService = itemService;
        }

        public void Start()
        {
            Console.Clear();

            bool loop = true;
            string input;

            do {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("\n[0] Restock Inventory");
                Console.WriteLine("[1] view order history of customer");
                Console.WriteLine("[x] Exit\n");

                input = Console.ReadLine();

                switch (input) {
                    case "0":
                        Restock();
                        break;
                    case "1":
                        ViewOrderCustomer();
                        break;
                    case "x":
                        loop = false;
                        Console.Clear();
                        Console.WriteLine("Have a great day!");
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (loop);
        }

        private void Restock() {
            Console.Clear();

            bool flag = true;

            List<CheckOut> checkOut = new List<CheckOut>();
            List<Store> storeId = new List<Store>();
            Size size = new Size();

            do {
                DisplayUsername.Username = "Admin";
                DisplayUsername.Email = "";

                Console.WriteLine($"Welcome: {DisplayUsername.Username}");
                List<Item> searchItem = _bl.GetStore();
                Item selectedItem = _itemService.SelectItem("\nWhat would you like to restock today? ([x] to exit)", searchItem);

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
                    Console.Clear();
                    System.Console.WriteLine($"Please select your quantity");
                    System.Console.WriteLine();
                    int quant = Convert.ToInt32(Console.ReadLine());
           
                    Store store = _bl.GetOneStoreById(selectedItem.Id);
                    storeId.Add(new Store() {Id = store.Id});
                    checkOut.Add(new CheckOut() {Id = selectedItem.Id, Item = selectedItem.Name, Price = selectedItem.Price, Size = selectedItem.Size[parsedInput].ClothingSize, Quantity = quant, TotalQuantity = selectedItem.Size[parsedInput].SizeQuantity - quant});
                    
                    List<CheckOut> checkOutList = checkOut.ToList();
                    List<Store> storeIdList = storeId.ToList();

                    for (int i = 0; i < checkOutList.Count; i++) {
                        size.ClothingSize = checkOutList[i].Size;
                        size.SizeQuantity = quant;
                        size.ItemId = checkOutList[i].Id;
                        _bl.UpdateSize(size);
                    }
                    
                    Console.Clear();
                    System.Console.WriteLine("Restock was successful!\n");

                    storeId.Clear();
                    checkOut.Clear();
                }
                else {
                    Console.WriteLine("invalid input");
                    goto selectSize;
                }              
            } while (flag);
            
        }

        private void ViewOrderCustomer() {
            Console.Clear();

            bool loop = true;
            string input;

            do {
                Console.WriteLine("[0] Search customer");
                Console.WriteLine("[1] View all customer");
                Console.WriteLine("[x] Exit\n");

                input = Console.ReadLine();

                switch (input) {
                    case "0":
                        SearchCustomer();
                        break;
                    case "1":
                        ViewAllCustomer();
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

        private void SearchCustomer() {
            Console.Clear();

            Console.WriteLine("Search a Customer\n");
            List<Customer> searchResult = _bl.SearchCustomer(Console.ReadLine());

            if(searchResult == null || searchResult.Count == 0)
            {
                Console.WriteLine("No Customer was found");
                return;
            }

            Customer selectedCustomer = _itemService.SelectCustomer("Pick a customer", searchResult);

            selectedCustomer = _bl.GetOneCustById(selectedCustomer.Id);

            Console.Clear();

            Console.WriteLine(selectedCustomer);
            System.Console.WriteLine();

            if (selectedCustomer.Orders.Count > 0) {
                foreach(Order order in selectedCustomer.Orders) {
                    Order selectedOrder = _bl.GetOrderById(order.Id);
                    Item selectedItem = _bl.GetOneItemById(selectedOrder.StoreId);

                    System.Console.WriteLine($"{selectedItem}      {selectedOrder.Stores.Address} {selectedOrder.Stores.City} {selectedOrder.Stores.State}");
                }
                System.Console.WriteLine();
            }
            else {
                System.Console.WriteLine("No purchase yet\n");
            }
        }

        private void ViewAllCustomer() {
            List<Customer> custList = _bl.GetCustomerList();

            Customer selectedCustomer = _itemService.SelectCustomer("Pick a customer", custList);

            selectedCustomer = _bl.GetOneCustById(selectedCustomer.Id);

            Console.Clear();

            Console.WriteLine(selectedCustomer);
            System.Console.WriteLine();

            if (selectedCustomer.Orders.Count > 0) {
                foreach(Order order in selectedCustomer.Orders) {
                    Order selectedOrder = _bl.GetOrderById(order.Id);
                    Item selectedItem = _bl.GetOneItemById(selectedOrder.StoreId);

                    System.Console.WriteLine($"{selectedItem}      {selectedOrder.Stores.Address} {selectedOrder.Stores.City} {selectedOrder.Stores.State}");
                }
                System.Console.WriteLine();
            }
            else {
                System.Console.WriteLine("No purchase yet\n");
            }
        }
    }
}