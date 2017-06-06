using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        public Inventory inventory = new Inventory();
        public Recipe recipe = new Recipe();
        private string UserName;
        private double funds = 100;
        public void InitiatePlayer()
        {
            GetPlayerName();
            Console.Clear();
        }
        private void GetPlayerName()
        {
            Console.WriteLine("Welcome to lemonade stand!");
            Console.WriteLine("You will attempt to make as much profit over 7 days as you can!" + "\nYou will design a recipe for each pitcher and each pitcher will fill 10 cups" + "\nCustomers will change based on the current weather!");
            Console.WriteLine("Enter your username to play!");
            UserName = Console.ReadLine();

        }

        public double Funds
        {
            get
            {
                return funds;
            }
            set
            {
                funds = value;
            }
        }
    }
}
