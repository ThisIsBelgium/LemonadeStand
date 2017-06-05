using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Weather
    {
        public int temperature;
        public string conditions;

        public Weather()
        {
            this.temperature = GetTemperature();
            this.conditions = GetConditions();
        }


        private int GetTemperature()
        {
            temperature = GetRandomNumber(45, 85);
            return temperature;
        }

        private string GetConditions()
        {
            int randomCondition = GetRandomNumber(1, 4);
            switch (randomCondition)
            {
                case 1:
                    conditions = "Sunny";
                    return conditions;
                case 2:
                    conditions = "Cloudy";
                    return conditions;
                case 3:
                    conditions = "Rain-y";
                    return conditions;
            }
            return conditions;
        }
        private int GetRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }


    }
}
