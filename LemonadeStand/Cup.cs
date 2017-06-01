using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS2
{
    public class Cup
    {
        public double cupPrice;

        public void GetPrice()
        {
            cupPrice = Math.Round(GetRandomNumber(.1, .3), 2);
        }

        private double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
