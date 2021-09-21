using System;
using StoreBL;
using Models;

namespace UI {

    public class MainMenu : IMenu {

        public void Start() {
            bool loop = true;
            string input;

            do {
                Console.WriteLine("\nSign in menu:");
                Console.WriteLine("[0] Log in as existing customer");
                Console.WriteLine("[1] Sign up as new customer");
                Console.WriteLine("[x] Exit");

                input = Console.ReadLine();

                switch (input) {
                    case "0":
                        MenuFactory.GetMenu("login").Start();
                        break;
                    case "1":
                        MenuFactory.GetMenu("signup").Start();
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
    }
}