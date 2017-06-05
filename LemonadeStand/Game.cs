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
            for (int days = 0; days <= 7; days++)
            {
                day.NewDay(player, game, forecast, days, player.inventory, day);
            }
        }
        private void GetWeatherInformation()
        {
            SetupForecast();
        }
        private void SetupForecast()
        {
            for (int i = 0; i <= 6; i++)
            {
                forecast.Add(new Weather());
                System.Threading.Thread.Sleep(50);
            }
        }
    }
}
