using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Player
    {
        private string UserName;
        private int StartingFunds;
        public void InitiatePlayer()
        {
            GetPlayerName();
            GetStartingFunds();
        }
        private void GetPlayerName()
        {
            Console.WriteLine("Enter your Username!");
            UserName = Console.ReadLine();
        }
        private void GetStartingFunds()
        {
            StartingFunds = 50;
            Console.WriteLine("You start with" + " $" + StartingFunds + "\n Press enter to continue");
            Console.ReadLine();
        }
    }
}
