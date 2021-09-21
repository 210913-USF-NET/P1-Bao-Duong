using DL;
using StoreBL;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu (string menuInput) {

            switch (menuInput) {
                case "login":
                    return new LoginMenu(new Bl(new FileRepo()));
                case "signup":
                    return new SignupMenu(new Bl(new FileRepo())); 
                case "view":
                    return new InventoryMenu(new Bl(new FileRepo()));
                case "review":
                    return new ReviewMenu(new Bl(new FileRepo()));
                default :
                    return null;
            }
        }
    }
}