using System;
using System.Collections.Generic;
using Models;

namespace UI
{
    public class ItemService
    {
        public Item SelectItem(string prompt, List<Item> listToPick) {

            selectItem:
            Console.WriteLine(prompt);
            System.Console.WriteLine();

            for (int i = 0; i < listToPick.Count; i++)
            {
                Console.WriteLine($"[{i}] {listToPick[i]}");
            }

            System.Console.WriteLine();
                  
            string input = Console.ReadLine();

            if (input == "x" || input == "X") {
                return null;
            }

            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if(parseSuccess && parsedInput >= 0 && parsedInput < listToPick.Count)
            {
                return listToPick[parsedInput];
            }
            else {
                Console.WriteLine("invalid input");
                goto selectItem;
            }
        }

        public Customer SelectCustomer(string prompt, List<Customer> listToPick) {

            selectItem:
            Console.WriteLine(prompt);
            System.Console.WriteLine();

            for (int i = 0; i < listToPick.Count; i++)
            {
                Console.WriteLine($"[{i}] {listToPick[i]}");
            }

            System.Console.WriteLine();
                  
            string input = Console.ReadLine();

            if (input == "x" || input == "X") {
                return null;
            }

            int parsedInput;
            bool parseSuccess = Int32.TryParse(input, out parsedInput);

            if(parseSuccess && parsedInput >= 0 && parsedInput < listToPick.Count)
            {
                return listToPick[parsedInput];
            }
            else {
                Console.WriteLine("invalid input");
                goto selectItem;
            }
        }
    }
}