using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Recipe
    {
        public List<Cup> filledCups = new List<Cup>();
        public Cup pitcherCup = new Cup();
        public int lemonAmount;
        public int sugarAmount;
        public int iceAmount;
        public double pricePerCup;

        public void SetRecipe(Inventory inventory, Game game)
        {
            GetPitcherInfo();
            GetLemonAmount(inventory);
            RemoveLemons(inventory);
            GetSugarAmount(inventory);
            RemoveSugar(inventory);
            GetIceAmount(inventory);
            RemoveIce(inventory);
            GenerateCups(inventory, game);

        }
        private void GetPitcherInfo()
        {
            Console.WriteLine("Design your recipe for the day!" + "\nEach recipe amount will make 1 pitcher" + "\n1 pitcher will fill 10 Cups!");
        }

        private void GetLemonAmount(Inventory inventory)
        {
            Console.WriteLine("How many lemons do you want per pitcher?" + "\nYou have " + inventory.lemons.Count + " lemons");
            lemonAmount = int.Parse(Console.ReadLine());
            if (lemonAmount >= inventory.lemons.Count)
            {
                Console.WriteLine("You don't have enough lemons!" + "\nPress enter to try again!");
                Console.ReadLine();
                GetLemonAmount(inventory);
            }
        }
        private void RemoveLemons(Inventory inventory)
        {
            for (int i = 0; i <= lemonAmount - 1; i++)
            {
                inventory.lemons.RemoveAt(0);
            }
        }
        private void GetSugarAmount(Inventory inventory)
        {
            Console.WriteLine("How much sugar do you want per pitcher?" + "\nYou have " + inventory.sugar.Count + " cups of sugar");
            sugarAmount = int.Parse(Console.ReadLine());
            if (sugarAmount >= inventory.sugar.Count)
            {
                Console.WriteLine("You don't have enough sugar!" + "\nPress enter to try again!");
                Console.ReadLine();
                GetSugarAmount(inventory);
            }
        }
        private void RemoveSugar(Inventory inventory)
        {
            for (int i = 0; i <= sugarAmount - 1; i++)
            {
                inventory.sugar.RemoveAt(0);
            }
        }
        private void GetIceAmount(Inventory inventory)
        {
            Console.WriteLine("How much ice do you want per pitcher?" + "\nYou have " + inventory.ice.Count + " cups of ice");
            iceAmount = int.Parse(Console.ReadLine());
            if (iceAmount >= inventory.ice.Count)
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
                inventory.ice.RemoveAt(0);
            }
        }
        private void GenerateCups(Inventory inventory, Game game)
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
            for (int i = 0; i <= 9; i++)
            {
                inventory.cups.RemoveAt(0);
                filledCups.Add(pitcherCup);
            }

        }
        public void MakeAdditionalPitchers(Inventory inventory, Game game, Day day, Player player)
        {
            if (iceAmount > inventory.ice.Count)
            {
                Console.WriteLine("Oh no you ran out of ice, time to pack it up" + "\n press enter to continue");
                Console.ReadLine();
                return;

            }
            RemoveIce(inventory);
            if (lemonAmount > inventory.lemons.Count)
            {
                Console.WriteLine("Oh no you ran out of lemons, time to pack it up" + "\n press enter to continue");
                Console.ReadLine();
                return;
            }
            RemoveLemons(inventory);
           if (sugarAmount > inventory.sugar.Count)
            {
                Console.WriteLine("Oh no you ran out of sugar, time to pack it up" + "\n press enter to continue");
                Console.ReadLine();
                return;
            }
            RemoveSugar(inventory);
            if (10 > inventory.cups.Count)
            {
                Console.WriteLine("You dont have enough cups for this pitcher" + "Restart or wait the day out?(restart/wait)");
                string restartchoice = Console.ReadLine();
                if (restartchoice == "restart")
                {
                    game.Run(game);
                }
                else
                {
                    return;
                }
            }
            for (int i = 0; i <= 9; i++)
            {
                inventory.cups.RemoveAt(0);
                filledCups.Add(pitcherCup);
            }

        }

    }
}
