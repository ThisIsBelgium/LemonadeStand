using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LS2
{
    public class Sugar
    {
        public double sugarPrice;

        public void GetPrice()
        {
            sugarPrice = Math.Round(GetRandomNumber(.62, 1.15), 2);
        }

        private double GetRandomNumber(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
    }
}
