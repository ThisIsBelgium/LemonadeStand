using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        Player player = new Player();
        Store store = new Store();
        Day day = new Day();
        public List<Weather> forecast = new List<Weather>();


        public void Run(Game game)
        {
            player.InitiatePlayer();
            store.GeneratePrices();
            InventoryRestock(player);
            Console.Clear();
            DisplayInventory();
            GetWeatherInformation();
            player.recipe.SetRecipe(player.inventory,game);
        }
        private void InventoryRestock(Player player)
        {
            store.BuyLemons(player);
            player.Funds -= store.lemonTotalCost;
            for (int i = 0; i <= store.lemonAmount-1; i++)
            {
                player.inventory.lemons.Add(store.lemon);
            }
            store.BuySugar(player);
            player.Funds -= store.sugarTotalCost;
            for (int i = 0; i <= store.sugarAmount-1; i++)
            {
                player.inventory.sugar.Add(store.sugar);
            }
            store.BuyIce(player);
            player.Funds -= store.iceTotalCost;
            for (int i = 0; i <= store.iceAmount-1; i++)
            {
                player.inventory.ice.Add(store.ice);
            }
            store.BuyCup(player);
            player.Funds -= store.cupTotalCost;
            for (int i = 0; i <= store.cupAmount-1; i++)
            {
                player.inventory.cups.Add(store.cup);
            }
        }
        private void DisplayInventory()
        {
            Console.WriteLine("You have " + "\n" + player.inventory.lemons.Count + " lemons" +"\n" + player.inventory.sugar.Count + " cups of sugar" +
                "\n" + player.inventory.ice.Count + " cups of ice" + "\n" + player.inventory.cups.Count + " cups" );
            Console.WriteLine("Do you need more supplies (yes/no)" + "\n You have" + player.Funds + "$ remaining" );
            string resupplyCheck = Console.ReadLine();
            if (resupplyCheck == "yes")
            {
                InventoryRestock(player);
                DisplayInventory();
            }
        }
        private void GetWeatherInformation()
        {
            SetupForecast();
            CheckDisaster();
            ViewForecast();
        }
        private void SetupForecast()
        {
            for (int i = 0; i <= 6; i++)
            {
                forecast.Add(new Weather(0,null,false));
                System.Threading.Thread.Sleep(150);
            }
        }
        private void CheckDisaster()
        {
            for(int i=0; i <= 6; i++)
            {
                if (forecast[i].disaster == true)
                {
                    Console.WriteLine("OH NOES DISASTER HAS STRUCK AND HALF YOUR LEMONS HAVE GONE BAD");
                    double totalLemons = player.inventory.lemons.Count;
                    totalLemons = Math.Round(totalLemons / 2);
                    for (int a = 0; a <= totalLemons-1; a++)
                    {
                        player.inventory.lemons.RemoveAt(a);
                    }
                }
            }
        }
        private void ViewForecast()
        {
            Console.WriteLine("Here's your forecast for today!" + "\n" + forecast[0].temperature + " Degrees" + "\n" + forecast[0].conditions);
            Console.WriteLine("Would you like to see the forecast for the week?(yes/no)");
            string response = Console.ReadLine();
            if (response == "yes")
            {
                for(int i = 1; i <= 6; i++)
                {
                    Console.WriteLine(forecast[i].temperature + " Degrees" + "\n" + forecast[i].conditions +"\n");
                    
                }
            } Console.ReadLine();
            Console.Clear();

        }


    }
}
