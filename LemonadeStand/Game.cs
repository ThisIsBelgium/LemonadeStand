using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS2
{
    public class Game
    {
        Player player = new Player();
        Store store = new Store();

        public void Run()
        {
            player.InitiatePlayer();
            store.GeneratePrices();
            InventoryRestock(player);
            Console.Clear();
            DisplayInventory();
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
            Console.WriteLine("Do you need more supplies (yes/no)");
            string resupplyCheck = Console.ReadLine();
            if (resupplyCheck == "yes")
            {
                InventoryRestock(player);
            }
        }

    }
}
