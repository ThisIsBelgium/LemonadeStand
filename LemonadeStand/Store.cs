using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS2
{
    public class Store
    {
        public Lemon lemon = new Lemon();
        public int lemonAmount;
        private double lemonPrice;
        public double lemonTotalCost;
        public Sugar sugar = new Sugar();
        public int sugarAmount;
        private double sugarPrice;
        public double sugarTotalCost;
        public Ice ice = new Ice();
        public int iceAmount;
        private double icePrice;
        public double iceTotalCost;
        public Cup cup = new Cup();
        public int cupAmount;
        private double cupPrice;
        public double cupTotalCost;



        public void GeneratePrices()
        {
            lemon.GetPrice();
            lemonPrice = lemon.lemonPrice;
            sugar.GetPrice();
            sugarPrice = sugar.sugarPrice;
            ice.GetPrice();
            icePrice = ice.icePrice;
            cup.GetPrice();
            cupPrice = cup.cupPrice;

        }

        //LEMON CALC
        public void BuyLemons(Player player)
        {
            GetLemonAmount(player);
            LemonTotalCost();
            if (lemonTotalCost >= player.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:" + player.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                BuyLemons(player);
            }
        }
        private void GetLemonAmount(Player player)
        {
            Console.WriteLine("How many lemons do you want?" + "\n lemons currently cost:" + lemonPrice + "\n You currently have:" + player.Funds + "$" + " and " + player.inventory.lemons.Count + " lemons");
            lemonAmount = int.Parse(Console.ReadLine());
        }
        private void LemonTotalCost()
        {
            lemonTotalCost = lemonAmount * lemonPrice;
        }

        //SUGAR CALC
        public void BuySugar(Player player)
        {
            GetSugarAmount(player);
            SugarTotalCost();
            if (sugarTotalCost >= player.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:" + player.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                BuySugar(player);
            }
        }
        private void GetSugarAmount(Player player)
        {
            Console.WriteLine("How much sugar do you want?" + "\n sugar currently cost:" + sugarPrice + "\n You currently have:" + player.Funds + "$" + " and " + player.inventory.sugar.Count + " cups of sugar");
            sugarAmount = int.Parse(Console.ReadLine());
        }
        private void SugarTotalCost()
        {
            sugarTotalCost = sugarAmount * sugarPrice;
        }


        //ICE CALC
        public void BuyIce(Player player)
        {
            GetIceAmount(player);
            IceTotalCost();
            if (iceTotalCost >= player.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:" + player.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                BuyIce(player);
            }
        }
        private void GetIceAmount(Player player)
        {
            Console.WriteLine("How much ice do you want?" + "\n ice currently cost:" + icePrice + "\n You currently have:" + player.Funds + "$" + " and " + player.inventory.ice.Count + " cups of ice");
            iceAmount = int.Parse(Console.ReadLine());
        }
        private void IceTotalCost()
        {
            iceTotalCost = iceAmount * icePrice;
        }


        //CUP CALC
        public void BuyCup(Player player)
        {
            GetCupAmount(player);
            CupTotalCost();
            if (cupTotalCost >= player.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:" + player.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                BuyCup(player);
            }

        }
        private void GetCupAmount(Player player)
        {
            Console.WriteLine("How many cups do you want?" + "\n cups currently cost:" + cupPrice + "\n You currently have:" + player.Funds + "$" + " and " + player.inventory.cups.Count + " cups ");
            cupAmount = int.Parse(Console.ReadLine());
        }
        private void CupTotalCost()
        {
            cupTotalCost = cupAmount * cupPrice;
        }


    }

}

