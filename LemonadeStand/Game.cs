using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public class Game
    {
        Player player = new Player();
        Day day = new Day();
        public List<Weather> forecast = new List<Weather>();


        public void Run(Game game)
        {
            player.InitiatePlayer();
            GetWeatherInformation();
            day.NewDay(player, game, forecast);
        }
        private void GetWeatherInformation()
        {
            SetupForecast();
            CheckDisaster();
            
        }
        private void SetupForecast()
        {
            for (int i = 0; i <= 6; i++)
            {
                forecast.Add(new Weather(0, null, false));
                System.Threading.Thread.Sleep(150);
            }
        }
        private void CheckDisaster()
        {
            for (int i = 0; i <= 6; i++)
            {
                if (forecast[i].disaster == true)
                {
                    Console.WriteLine("OH NOES DISASTER HAS STRUCK AND HALF YOUR LEMONS HAVE GONE BAD");
                    double totalLemons = player.inventory.lemons.Count;
                    totalLemons = Math.Round(totalLemons / 2);
                    for (int a = 0; a <= totalLemons - 1; a++)
                    {
                        player.inventory.lemons.RemoveAt(a);
                    }
                }
            }
        }  
    }
}
