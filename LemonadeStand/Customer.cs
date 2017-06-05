using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Customer
    {
        public int temperaturePreference;
        public int tastePreference;
        public double budget;

        public Customer()
        {
            this.temperaturePreference = GetTemperaturePreference();
            this.tastePreference = GetTastePreference();
            this.budget = GetBudget();

        }
        private int GetTemperaturePreference()
        {
            temperaturePreference = GetRandomNumber(0, 2);
            return temperaturePreference;
        }
        private int GetTastePreference()
        {
            tastePreference = GetRandomNumber(0, 2);
            return tastePreference;

        }
        private double GetBudget()
        {
            budget = Math.Round(GetRandomDouble(.1, 1.76),2);
            return budget;


        }
        private double GetRandomDouble(double min, double max)
        {
            Random random = new Random();
            return random.NextDouble() * (max - min) + min;
        }
        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

    }
}
