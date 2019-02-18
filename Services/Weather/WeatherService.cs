using Discord.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ggwp.Services.Weather
{
    public class WeatherService
    {
        private string weatherID = "433f32924ecebe72d3ff2b702ac1e498";
        public async Task GetWeather(SocketCommandContext Context, string query)
        {
            try
            {
                var search = System.Net.WebUtility.UrlEncode(query);
                string response = "";
                using (var http = new HttpClient())
                {
                    response = await http.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?q=" + search + "&appid=" + weatherID + "&units=metric").ConfigureAwait(false);
                }
                var data = JsonConvert.DeserializeObject<WeatherData>(response);
                await Context.Channel.SendMessageAsync("", embed: data.GetEmbed().Build());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await Context.Channel.SendMessageAsync(":no_entry_sign: Nie można znaleźć pogody dla tego miasta.");
            }

        }
    }
}
