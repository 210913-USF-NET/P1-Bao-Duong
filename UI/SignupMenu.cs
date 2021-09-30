using System;
using System.Collections.Generic;
using StoreBL;
using Models;

namespace UI {

    public class SignupMenu : IMenu {
        private IBl _bl;

        public SignupMenu(IBl bl) {
            this._bl = bl;
        }

        public void Start() {
            Console.Clear();
            Console.WriteLine("Thank you for being a part of the community!");

            CreateUser();
        }

        private void CreateUser() {
            Customer newCust = new Customer();
            List<Customer> getUser = _bl.GetCustomerList();

            string name = "";
            string pass = "";
            string email = "";

            Console.WriteLine("\nPlease enter a username and password");

            inputName:            
            Console.Write("\nUsername: ");

            name = Console.ReadLine().ToLower();

            for (int i = 0; i < getUser.Count; i++) {
                if (name == getUser[i].Username) {
                    Console.WriteLine("Username is taken, please try again!");
                    goto inputName;
                }
            }

            try {
                newCust.Username = name;          
            }
            catch (InputInvalidException e) {
                Console.WriteLine(e.Message);
                goto inputName;
            }
            
            inputEmail:
            Console.Write("\nEmail: ");
            email = Console.ReadLine().ToLower();

            try {
                newCust.Email = email;          
            }
            catch (InputInvalidException e) {
                Console.WriteLine(e.Message);
                goto inputEmail;
            }

            Console.Write("\nPassword: ");
            pass = Console.ReadLine();
            
            newCust.Email = email;
            newCust.Password = pass;

            _bl.AddCustomer(newCust);

            List<Customer> getNewUser = _bl.GetCustomerList();

            for (int i = 0; i < getNewUser.Count; i++) {
                if (name == getNewUser[i].Username && pass == getNewUser[i].Password) {
                    Console.WriteLine("\n");

                    DisplayUsername.Id = getNewUser[i].Id;
                    DisplayUsername.Username = getNewUser[i].Username;
                    DisplayUsername.Email = getNewUser[i].Email;
                    break;
                }
            }

            MenuFactory.GetMenu("nav").Start();
            
        }
    }
}