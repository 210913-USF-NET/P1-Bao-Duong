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
            Username newUser = new Username();
            Password newPass = new Password();
            List<Username> getUser = _bl.GetAllUsername();
            string name = "";
            string pass = "";

            Console.WriteLine("\nPlease enter a username and password");

            inputName:            
            Console.Write("\nUsername: ");

            name = Console.ReadLine();

            try {
                newUser.User = name;
            }
            catch (InputInvalidException e) {
                Console.WriteLine(e.Message);
                goto inputName;
            }

            Console.Write("\nPassword: ");
            pass = Console.ReadLine();

            newPass.Pass = pass;

            _bl.AddUsername(newUser);
            _bl.AddPassword(newPass);

            Console.Clear();
            Console.WriteLine("You've successfully created your account!");
        }
    }
}