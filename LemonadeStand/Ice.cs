using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS2
{
    public class Ice
    {
        public double icePrice;

        public void GetPrice()
        {
            icePrice = Math.Round(GetRandomNumber(.3, .6), 2);
        }

        private double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
