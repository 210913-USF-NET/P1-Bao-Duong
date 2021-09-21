using System;
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
            User newUser = new User();

            inputName:

            Console.WriteLine("Username: ");

            try {
                newUser.UserName = Console.ReadLine();
            }
            catch (InputInvalidException e) {
                Console.WriteLine(e);
                goto inputName;
            }
        }
    }
}