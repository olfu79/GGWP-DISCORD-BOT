    using System;
    using System.Collections.Generic;
    using System.Text;
    using Discord.Commands;
    using Discord;
    using ggwp.Services.Weather;
    using System.Threading.Tasks;
    using ggwp.Services;
    using Newtonsoft.Json;
    using System.Net.Http;
    using System.Text.RegularExpressions;

    namespace ggwp.Modules
    {
        public class Weather : ModuleBase<SocketCommandContext>
        {
            [Command("weather", RunMode = RunMode.Async)]
            [Alias("pogoda")]
            public async Task GetWeather([Remainder]string query)
            {
                if (Context.Channel is IPrivateChannel)
                    return;

                await Global.weatherService.GetWeather(Context, query);
            }
        }
    }
