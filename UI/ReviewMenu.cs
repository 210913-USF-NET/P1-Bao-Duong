using System;
using StoreBL;

namespace UI
{
    public class ReviewMenu : IMenu
    {
        private IBl _bl;

        public ReviewMenu(IBl bl) {
            this._bl = bl;
        }

        public void Start() {
            Console.WriteLine("Needs implementation");
        }
    }
}