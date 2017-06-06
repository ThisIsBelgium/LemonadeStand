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
        public void NewDay(Player player, Game game, List<Weather> forecast, int days, Inventory inventory, Day day)
        {
            dailyProfit = 0;
            Console.Clear();
            store.GeneratePrices();
            ViewForecast(forecast, days);
            InventoryRestock(player);
            Console.Clear();
            DisplayInventory(player);
            player.recipe.SetRecipe(player.inventory, game);
            GenerateCustomers(forecast, days);
            OpenStore(player, inventory, game, day);
            DisplayDailyProfit(player);
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
            Console.WriteLine("Do you need more supplies (yes/no)" + "\n You have $" + Math.Round(player.Funds,2) + " remaining");
            string resupplyCheck = Console.ReadLine();
            if (resupplyCheck == "yes")
            {
                InventoryRestock(player);
                DisplayInventory(player);
            }
        }

        private void ViewForecast(List<Weather> forecast, int days)
        {
            Console.WriteLine("Here's your forecast for today!" + "\n" + forecast[days].temperature + " Degrees" + "\n" + forecast[days].conditions);
            Console.WriteLine("Would you like to see the forecast for the week?(yes/no)");
            string response = Console.ReadLine();
            if (response == "yes")
            {
                for (int i = 1; i <= 6 - days; i++)
                {
                    Console.WriteLine(forecast[i].temperature + " Degrees" + "\n" + forecast[i].conditions + "\n");

                }
            }
            else if (response == "no")
            {
                
            }
            else
            {
                Console.Clear();
                ViewForecast(forecast, days);
            }
        }
        private void SellCup(Player player, Inventory inventory, Game game, Day day)
        {
            if (player.recipe.filledCups.Count <= 1)
            {
                Console.WriteLine("Thats one pitcher down!");
                player.recipe.MakeAdditionalPitchers(inventory, game, day, player);

            }
            dailyProfit += player.recipe.filledCups[0].cupPrice;
            player.recipe.filledCups.RemoveAt(0);
        }
        private void GenerateCustomers(List<Weather> forecast, int days)
        {
            if (forecast[days].conditions == "Sunny")
            {
                for (int i = 0; i <= 149; i++)
                {
                    System.Threading.Thread.Sleep(15);
                    customers.Add(new Customer());
                }
            }
            if (forecast[days].conditions == "Cloudy")
            {
                for (int i = 0; i <= 99; i++)
                {
                    System.Threading.Thread.Sleep(15);
                    customers.Add(new Customer());
                }
            }
            if (forecast[days].conditions == "Rain-y")
            {
                for (int i = 0; i <= 49; i++)
                {
                    System.Threading.Thread.Sleep(15);
                    customers.Add(new Customer());
                }
            }

        }
        private void OpenStore(Player player, Inventory inventory, Game game, Day day)

        {
            foreach (Customer customer in customers)
            {
                if (player.recipe.filledCups.Count == 0)
                {
                    return;
                }
                if (customer.tastePreference == 0)
                {
                    if (player.recipe.lemonAmount > player.recipe.sugarAmount)
                    {
                        if (customer.temperaturePreference == 0)
                        {
                            if (customer.budget >= player.recipe.filledCups[0].cupPrice && player.recipe.iceAmount >= 3)
                            {
                                Console.WriteLine("One cup sold!");
                                SellCup(player, inventory, game, day);
                            }
                        }
                        else if (customer.temperaturePreference == 1)
                        {
                            if (customer.budget >= player.recipe.filledCups[0].cupPrice && player.recipe.iceAmount <= 3)
                            {
                                Console.WriteLine("One cup sold!");
                                SellCup(player, inventory, game, day);
                            }
                        }
                    }
                }
                else if (customer.tastePreference == 1)
                {
                    if (player.recipe.lemonAmount <= player.recipe.sugarAmount)
                    {
                        if (customer.temperaturePreference == 0)
                        {
                            if (customer.budget >= player.recipe.filledCups[0].cupPrice && player.recipe.iceAmount >= 3)
                            {
                                Console.WriteLine("One cup sold!");
                                SellCup(player, inventory, game, day);
                            }
                        }
                        else if (customer.temperaturePreference == 1)
                        {
                            if (customer.budget >= player.recipe.filledCups[0].cupPrice && player.recipe.iceAmount <= 3)
                            {
                                Console.WriteLine("One cup sold!");
                                SellCup(player, inventory, game, day);
                            }
                        }
                    }
                }
            }
        }
        public void DisplayDailyProfit(Player player)
        {
            Console.WriteLine("$" + dailyProfit + " earned today");
            Math.Round(player.Funds, 2);
            player.Funds += dailyProfit;
            Console.WriteLine("press enter to continue to the next day");
            Console.ReadLine();

        }
    }
}


