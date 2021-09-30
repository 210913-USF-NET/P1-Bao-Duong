using System;
using System.Collections.Generic;
using StoreBL;
using Models;

namespace UI {
    public class LoginMenu : IMenu {
        private IBl _bl;

        public LoginMenu(IBl bl) {
            this._bl = bl;
        }

        public void Start() {
            bool flag = false;
            char signOut;

            Console.Clear();
            Console.WriteLine("Please enter your username and password");

            do {
                flag = LogIn();

                Console.Clear();
                if (flag == false) {
                    Console.WriteLine("Invalid login!");

                    Console.WriteLine("\nSign out? y/n");
                    signOut = Console.ReadLine()[0];

                    if (signOut == 'y' || signOut == 'Y') {
                        Console.Clear();
                        break;
                    }
                    else {
                        Console.Clear();
                    }
                } 
            } while (!flag);

            if (flag == true) {
                MenuFactory.GetMenu("nav").Start();
            }
        }

        private bool LogIn() {
            bool check = false;
            string name = "";
            string pass = "";

            List<Customer> getUser = _bl.GetCustomerList();

            Console.Write("Username: ");

            name = Console.ReadLine().ToLower();

            Console.Write("Password: ");
            pass = HideCharacter();

            for (int i = 0; i < getUser.Count; i++) {
                if (name == getUser[i].Username && pass == getUser[i].Password) {
                    Console.WriteLine("\n");

                    DisplayUsername.Id = getUser[i].Id;
                    DisplayUsername.Username = getUser[i].Username;
                    DisplayUsername.Email = getUser[i].Email;
                    check = true;
                    break;
                }
            }

            return check;
        }

        private string HideCharacter() {
            ConsoleKeyInfo key;
            string code = "";
            do {
                key = Console.ReadKey(true);

                if (key.KeyChar == (char)8 && code.Length > 0) {
                    code = code.Remove(code.Length - 1);    
                }
                else {
                     if (key.Key == ConsoleKey.Enter) {
                         break;
                     }
                     else {
                         code += key.KeyChar;
                     }
                }
                
            } while (key.Key != ConsoleKey.Enter);

            return code;
        }

    }
}