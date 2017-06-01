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
        public bool disaster;

        public Weather(int temperature,string conditions,bool disaster)
        {
            this.temperature = GetTemperature();
            this.conditions = GetConditions();
            this.disaster = CheckDisaster();
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
        private bool CheckDisaster()
        {
            int disasterCheck = GetRandomNumber(1,100);
            if(disasterCheck == 13)
            {
                disaster = true;
                return disaster;
            }
            else
            {
                disaster = false;
                return disaster;
            }

        }
        private int GetRandomNumber(int min,int max)
        {
            Random random = new Random();
            return random.Next(min,max);
        }


    }
}
