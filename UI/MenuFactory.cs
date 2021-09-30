using DL;
using StoreBL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace UI
{
    public class MenuFactory
    {
        public static IMenu GetMenu (string menuInput) {

            string connectionString = File.ReadAllText(@"../connectionString.txt");
            DbContextOptions<InvincibleDBContext> options = new DbContextOptionsBuilder<InvincibleDBContext>().UseSqlServer(connectionString).Options;

            InvincibleDBContext context = new InvincibleDBContext(options);

            switch (menuInput) {
                case "main":
                    return new MainMenu();
                case "login":
                    return new LoginMenu(new Bl(new DBRepo(context)));
                case "signup":
                    return new SignupMenu(new Bl(new DBRepo(context))); 
                case "nav":
                    return new NavMenu(new Bl(new DBRepo(context))); 
                case "shop":
                    return new StoreMenu(new Bl(new DBRepo(context)), new ItemService()); 
                case "store":
                    return new LocationMenu(new Bl(new DBRepo(context))); 
                case "admin":
                    return new AdminMenu(new Bl(new DBRepo(context)), new ItemService()); 
                default :
                    return null;
            }
        }
    }
}