using System;
using Serilog;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Clear();
            Console.WriteLine("Welcome to INVINCIBLE luxury sportswear!");
            
            
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("../logs/logs.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

            Log.Information("Application Starting...");
            
            new MainMenu().Start();

            Log.Information("Application closing...");
            Log.CloseAndFlush();
        }
    }
}