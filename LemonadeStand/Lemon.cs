using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Lemon
    {
        public double lemonPrice;

        public void GetPrice()
        {
            lemonPrice = Math.Round(GetRandomNumber(1.5, 3.6), 2);
        }

        private double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
