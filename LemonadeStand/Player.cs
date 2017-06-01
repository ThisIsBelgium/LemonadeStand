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
        private double funds = 200;
        public void InitiatePlayer()
        {
            GetPlayerName();
            Console.Clear();
        }
        private void GetPlayerName()
        {
            Console.WriteLine("Welcome to lemonade stand enter your username to play!");
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
