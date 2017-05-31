using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Store
    {
        private double LemonPrice;
        private double SugarPrice;
        private double IcePrice;
        public double LemonTotalCost;
        public double SugarTotalCost;
        public double IceTotalCost;

        public void GeneratePrices()
        {
            GetLemonPrice();
            GetSugarPrice();
            GetIcePrice();
        }
        public void BuyLemons(Player FirstPlayer,Inventory Inventory)
        {
            int LemonAmount = GetLemonAmount(FirstPlayer,Inventory);
            LemonTotalCost = GetLemonCost(LemonAmount,LemonPrice);
            if (LemonTotalCost >= FirstPlayer.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:"+ FirstPlayer.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                Inventory.AmountLemons -= LemonAmount;
                Console.WriteLine("Lemons currently cost:" + LemonPrice + "\nSugar currently costs: " + SugarPrice + "\nIce currently costs:" + IcePrice);
                BuyLemons(FirstPlayer, Inventory);
                
            }             
         }
        private void GetLemonPrice()
        {
            LemonPrice = GetRandomNumber(1.5, 3.6);
            LemonPrice = Math.Round(LemonPrice, 2);
            Console.WriteLine("Lemons currently cost:" + LemonPrice);
        }
        private int GetLemonAmount(Player FirstPlayer, Inventory Inventory)
        {
            Console.WriteLine("How many lemons would you like?");
            Console.WriteLine("You currently have "+ FirstPlayer.Funds +"$");
            int LemonAmount = int.Parse(Console.ReadLine());
            Inventory.AmountLemons += LemonAmount;
            return LemonAmount;
        }
        private double GetLemonCost(int LemonAmount, double LemonPrice)
        {
            double LemonTotal = LemonPrice * LemonAmount;
            return LemonTotal;
        }
        public void BuySugar(Player FirstPlayer,Inventory Inventory)
        {
            int SugarAmount = GetSugarAmount(FirstPlayer,Inventory);
            SugarTotalCost = GetSugarCost(SugarAmount, SugarPrice);
            if (SugarTotalCost >= FirstPlayer.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:" + FirstPlayer.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                Inventory.AmountSugar -=SugarAmount;
                Console.WriteLine("Lemons currently cost:" + LemonPrice + "\nSugar currently costs: " + SugarPrice + "\nIce currently costs:" + IcePrice);
                BuySugar(FirstPlayer, Inventory);

            }
        }
        private void GetSugarPrice()
        {
            SugarPrice = GetRandomNumber(.62, 1.15);
            SugarPrice = Math.Round(SugarPrice, 2);
            Console.WriteLine("Sugar currently costs:" + SugarPrice);
        }
        private int GetSugarAmount(Player FirstPlayer, Inventory Inventory)
        {
            Console.WriteLine("How much sugar would you like?");
            Console.WriteLine("You currently have " + FirstPlayer.Funds + "$");
            int SugarAmount = int.Parse(Console.ReadLine());
            Inventory.AmountSugar += SugarAmount;
            return SugarAmount;
        }
        private double GetSugarCost(int SugarAmount, double SugarPrice)
        {
            double SugarCost = SugarAmount * SugarPrice;
            return SugarCost;       
        }
        public void BuyIce(Player FirstPlayer,Inventory Inventory)
        {

            int IceAmount = GetIceAmount(FirstPlayer,Inventory);
            IceTotalCost = GetIceCost(IceAmount, IcePrice);
            if (IceTotalCost >= FirstPlayer.Funds)
            {
                Console.WriteLine("You can't afford that!" + "\nYou have:" + FirstPlayer.Funds + "$ remaining" + "\nTry again" + "\nPress enter to continue");
                Console.ReadLine();
                Console.Clear();
                Inventory.AmountIce = 0;
                Console.WriteLine("Lemons currently cost:" + LemonPrice + "\nSugar currently costs: " + SugarPrice + "\nIce currently costs:" + IcePrice);
                BuyIce(FirstPlayer, Inventory);

            }
        }
        private void GetIcePrice()
        {
            IcePrice = GetRandomNumber(.3, .6);
            IcePrice = Math.Round(IcePrice, 2);
            Console.WriteLine("Ice currently costs:"+ IcePrice);
        }
        private int GetIceAmount(Player FirstPlayer, Inventory Inventory)
        {
            Console.WriteLine("How much ice would you like?");
            Console.WriteLine("You currently have " + FirstPlayer.Funds + "$");
            int IceAmount = int.Parse(Console.ReadLine());
            Inventory.AmountIce += IceAmount;
            return IceAmount;
        }
        private double GetIceCost(int IceAmount,double IcePrice)
        {
            double IceCost = IceAmount * IcePrice;
            return IceCost;
        }
        private double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
