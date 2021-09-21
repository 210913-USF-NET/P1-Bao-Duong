using System;
using StoreBL;

namespace UI {
    public class LoginMenu : IMenu {
        private IBl _bl;

        public LoginMenu(IBl bl) {
            this._bl = bl;
        }

        public void Start() {
            Console.WriteLine("Needs implementation");
        }
    }
}