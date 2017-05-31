using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        public void RunStartup()
        {
            Player FirstPlayer = new Player();
            FirstPlayer.InitiatePlayer();
            Store NewStore = new Store();
            NewStore.GeneratePrices();
            Inventory Inventory = new Inventory();
            Inventory.InventoryRestock(NewStore,FirstPlayer,Inventory);
            

        }
    }
}
