using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Cup
    {
        public double cupPrice;
        public double pricePerCup;

        public void GetPrice()
        {
            cupPrice = Math.Round(GetRandomNumber(.1, .3), 2);
        }
        public void GetPricePerCup()
        {
            Console.WriteLine("Now choose your price per cup!");
            cupPrice = double.Parse(Console.ReadLine());
        }

        private double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
