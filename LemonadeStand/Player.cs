using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS2
{
    public class Player
    {
        public Inventory inventory = new Inventory();
        private string UserName;
        private double funds = 200;
        public void InitiatePlayer()
        {
            GetPlayerName();
            Console.Clear();
        }
        private void GetPlayerName()
        {
            Console.WriteLine("Enter your Username!");
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
