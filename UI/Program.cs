using System;
using Models;
using StoreBL;
using DL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.Clear();
            Console.WriteLine("Welcome to INVINCIBLE luxury sportswear!");
            new MainMenu().Start();
        }
    }
}