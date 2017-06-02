using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        List<Cup> Filledcups = new List<Cup>();
        Cup pitcherCup = new Cup();
        public int lemonAmount;
        public int sugarAmount;
        public int iceAmount;
        public double pricePerCup;

        public void SetRecipe(Inventory inventory,Game game)
        {
            GetPitcherInfo();
            GetLemonAmount(inventory);
            RemoveLemons(inventory);
            GetSugarAmount(inventory);
            RemoveSugar(inventory);
            GetIceAmount(inventory);
            GenerateCups(inventory,game);

         }
        private void GetPitcherInfo()
        {
            Console.WriteLine("Design your recipe for the day!" + "\nEach recipe amount will make 1 pitcher" + "\n1 pitcher will fill 10 Cups!");
        }

        private void GetLemonAmount(Inventory inventory)
        {
            Console.WriteLine("How many lemons do you want per pitcher?" + "\nYou have " + inventory.lemons.Count + " lemons");
            lemonAmount =int.Parse(Console.ReadLine());
            if (lemonAmount > inventory.lemons.Count)
            {
                Console.WriteLine("You don't have enough lemons!"+ "\nPress enter to try again!");
                Console.ReadLine();
                GetLemonAmount(inventory);
            }
        }
        private void RemoveLemons(Inventory inventory)
        {
            for (int i = 0; i <= lemonAmount-1; i++)
            {
                inventory.lemons.RemoveAt(i);
            }
        }
        private void GetSugarAmount(Inventory inventory)
        {
            Console.WriteLine("How much sugar do you want per pitcher?" + "\nYou have " + inventory.sugar.Count + " cups of sugar");
            sugarAmount = int.Parse(Console.ReadLine());
            if (sugarAmount > inventory.sugar.Count)
            {
                Console.WriteLine("You don't have enough sugar!" + "\nPress enter to try again!");
                Console.ReadLine();
                GetSugarAmount(inventory);
            }
        }
        private void RemoveSugar(Inventory inventory)
        {
            for (int i = 0; i<= sugarAmount-1; i++)
            {
                inventory.sugar.RemoveAt(i);
            }
        }
        private void GetIceAmount(Inventory inventory)
        {
            Console.WriteLine("How much ice do you want per pitcher?" + "\nYou have " + inventory.ice.Count + " cups of ice");
            iceAmount = int.Parse(Console.ReadLine());
            if (iceAmount > inventory.ice.Count)
            {
                Console.WriteLine("You don't have enough ice!" + "\nPress enter to try again!");
                Console.ReadLine();
                GetIceAmount(inventory);
            }
        }
        private void RemoveIce(Inventory inventory)
        {
            for (int i = 0; i <= iceAmount - 1; i++)
            {
                inventory.ice.RemoveAt(i);
            }
        }
        private void GenerateCups(Inventory inventory,Game game)
        {
            pitcherCup.GetPricePerCup();
            if (10 > inventory.cups.Count)
            {
                Console.WriteLine("You dont have enough cups for this pitcher" + "Restart or wait the day out?(restart/wait)");
                string restartchoice = Console.ReadLine();
                if (restartchoice == "restart")
                {
                    game.Run(game);
                }   
            }
            for (int i =0; i<=9; i++)
            {
                inventory.cups.RemoveAt(i);
                Filledcups.Add(pitcherCup);
            }

        }
    }
}
