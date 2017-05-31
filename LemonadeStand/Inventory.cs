using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Inventory
    {
        public int AmountLemons;
        public int AmountIce;
        public int AmountSugar;

        public void InventoryRestock(Store NewStore,Player FirstPlayer,Inventory Inventory)
        {
            GetAmountLemons(NewStore,FirstPlayer,Inventory);
            GetAmountSugar(NewStore,FirstPlayer,Inventory);
            GetAmountIce(NewStore,FirstPlayer,Inventory);
            DisplayInventory();
        }
       
        private void GetAmountLemons(Store NewStore, Player FirstPlayer,Inventory Inventory)
        {
            
            Console.WriteLine("You currently have:" + AmountLemons + " lemons" + "\nWould you like to buy more?(yes/no)");
            string BuyDecision = Console.ReadLine();
            if (BuyDecision == "yes")
            {
                NewStore.BuyLemons(FirstPlayer,Inventory);
                FirstPlayer.Funds -= NewStore.LemonTotalCost;
            }      
        }
        private void GetAmountSugar(Store NewStore, Player FirstPlayer, Inventory Inventory)
        {
            Console.WriteLine("You currently have:" + AmountSugar + " cups of sugar" + "\nWould you like to buy more?(yes/no)");
            string BuyDecision = Console.ReadLine();
            if (BuyDecision == "yes")
            {
                NewStore.BuySugar(FirstPlayer,Inventory);
                FirstPlayer.Funds -= NewStore.SugarTotalCost;
            }
        }    
        private void GetAmountIce(Store NewStore, Player FirstPlayer, Inventory Inventory)
        {
            Console.WriteLine("You currently have " + AmountIce + " cups of ice" +"\nWould you like to buy more?(yes/no)");
            string BuyDecision = Console.ReadLine();
            if (BuyDecision == "yes")
            {
                NewStore.BuyIce(FirstPlayer,Inventory);
                FirstPlayer.Funds -= NewStore.IceTotalCost;
            }            
        }
        private void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine(AmountLemons);
            Console.WriteLine(AmountIce+" cups of ice");
            Console.WriteLine(AmountSugar+" cups of sugar");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
