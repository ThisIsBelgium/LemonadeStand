using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Day
    {
        List<Customer> customers = new List<Customer>();
        Store store = new Store();
        public double dailyProfit;
        public void NewDay(Player player,Game game,List<Weather>forecast,int days)
        {
            store.GeneratePrices();
            ViewForecast(forecast,days);
            InventoryRestock(player);
            Console.Clear();
            DisplayInventory(player);
            player.recipe.SetRecipe(player.inventory, game);
            //GenerateCustomers();
        }
        private void InventoryRestock(Player player)
        {
            store.BuyLemons(player);
            player.Funds -= store.lemonTotalCost;
            for (int i = 0; i <= store.lemonAmount - 1; i++)
            {
                player.inventory.lemons.Add(store.lemon);
            }
            store.BuySugar(player);
            player.Funds -= store.sugarTotalCost;
            for (int i = 0; i <= store.sugarAmount - 1; i++)
            {
                player.inventory.sugar.Add(store.sugar);
            }
            store.BuyIce(player);
            player.Funds -= store.iceTotalCost;
            for (int i = 0; i <= store.iceAmount - 1; i++)
            {
                player.inventory.ice.Add(store.ice);
            }
            store.BuyCup(player);
            player.Funds -= store.cupTotalCost;
            for (int i = 0; i <= store.cupAmount - 1; i++)
            {
                player.inventory.cups.Add(store.cup);
            }
        }
        private void DisplayInventory(Player player)
        {
            Console.WriteLine("You have " + "\n" + player.inventory.lemons.Count + " lemons" + "\n" + player.inventory.sugar.Count + " cups of sugar" +
                "\n" + player.inventory.ice.Count + " cups of ice" + "\n" + player.inventory.cups.Count + " cups");
            Console.WriteLine("Do you need more supplies (yes/no)" + "\n You have" + player.Funds + "$ remaining");
            string resupplyCheck = Console.ReadLine();
            if (resupplyCheck == "yes")
            {
                InventoryRestock(player);
                DisplayInventory(player);
            }
        }
       
        private void ViewForecast(List<Weather>forecast,int days)
        {
            Console.WriteLine("Here's your forecast for today!" + "\n" + forecast[days].temperature + " Degrees" + "\n" + forecast[days].conditions);
            Console.WriteLine("Would you like to see the forecast for the week?(yes/no)");
            string response = Console.ReadLine();
            if (response == "yes")
            {
                for (int i = 1; i <= 6-days; i++)
                {
                    Console.WriteLine(forecast[i].temperature + " Degrees" + "\n" + forecast[i].conditions + "\n");

                }
            }
            Console.ReadLine();
            Console.Clear();

        }


    }
}


