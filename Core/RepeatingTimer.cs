using Discord;
using Discord.Rest;
using Discord.WebSocket;
using ggwp.Services.Weather;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ggwp.Core
{
    internal static class RepeatingTimer
    {
        private static Timer loopingTimer;
        private static SocketVoiceChannel weatherchannel;

        internal static async Task StartTimer()
        {
            //serwer DEV
            weatherchannel = Global.Client.GetGuild(448884032391086090).GetVoiceChannel(482968155568865290);   

            var kanalStaty = Global.Client.GetGuild(448884032391086090).GetTextChannel(521725645592723468);

            //trycatch here
            var messages = await kanalStaty.GetMessagesAsync((int)100).FlattenAsync();
            await kanalStaty.DeleteMessagesAsync(messages);

            var orderedUsers = UserAccounts.UserAccounts.GetAllAccounts().OrderByDescending(acc => acc.XP).ToList().Take(8);
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("Top 8 graczy - LVL");
            foreach (var userAccount in orderedUsers)
            {
                uint level = (uint)Math.Sqrt(userAccount.XP / 50);
                var user = Global.Client.GetUser(userAccount.ID);
                eb.AddField("Gracz: ", user == null ? "Nie znaleziono" : user.Username, true);
                eb.AddField("Exp: ", userAccount.XP, true);
                eb.AddField("Poziom: ", level, true);
            }
            eb.WithColor(Color.Gold);
            var msgE = await kanalStaty.SendMessageAsync("", false, eb.Build());
            Global.MsgStatyExp = msgE.Id;

            var orderedUserss = UserAccounts.UserAccounts.GetAllAccounts().OrderByDescending(acc => acc.MoneyWallet).ToList().Take(8);
            EmbedBuilder ebb = new EmbedBuilder();
            ebb.WithTitle("Top 8 graczy - KASA");
            foreach (var userAccount in orderedUserss)
            {
                uint level = (uint)Math.Sqrt(userAccount.XP / 50);
                var userr = Global.Client.GetUser(userAccount.ID);
                ebb.AddField("Gracz: ", userr == null ? "Nie znaleziono" : userr.Username, true);
                ebb.AddField("Kasa: ", userAccount.MoneyWallet, true);
                ebb.AddField("Poziom: ", level, true);
            }
            ebb.WithColor(Color.Green);
            var msgK = await kanalStaty.SendMessageAsync("", false, ebb.Build());
            Global.MsgStatyKasa = msgK.Id;

            loopingTimer = new Timer()
            {
                Interval = 30000,
                AutoReset = true,
                Enabled = true
            };
            loopingTimer.Elapsed += OnTimerTicked;

        }

        private static async void OnTimerTicked(object sender, ElapsedEventArgs e)
        {

            //GGWP
            string[] Activities = new[] { "!pomoc - aby uzyskać pomoc", $"Graczy na serwerze: {Global.Client.GetGuild(448884032391086090).Users.Count()}", "\"!\" to domyślny prefix" };
            var kanalStaty = Global.Client.GetGuild(448884032391086090).GetTextChannel(521725645592723468);

            // Zmiana aktywności 
            if (Global.NextActivity == Activities.Count())
                Global.NextActivity = 0;
            await Global.Client.SetGameAsync(Activities[Global.NextActivity]);
            Global.NextActivity++;

            ////Gui
            //godzina
            string time = DateTime.Now.ToString("HH:mm");
            var channelTime = Global.Client.GetGuild(448884032391086090).GetVoiceChannel(482943719742505001);
            await channelTime.ModifyAsync(y => y.Name = $"🕒 Godzina: {time}");
            //data
            string date = DateTime.Now.ToString("dd.MM.yyyy");
            var channelDate = Global.Client.GetGuild(448884032391086090).GetVoiceChannel(561613046305259531);
            await channelDate.ModifyAsync(y => y.Name = $"📅 Data: {date}");
            //użytkownicy
            int howManyUsers = Global.Client.GetGuild(448884032391086090).Users.Count();
            var channelUsers = Global.Client.GetGuild(448884032391086090).GetVoiceChannel(482933282745483284);
            await channelUsers.ModifyAsync(y => y.Name = $"👪 Graczy: {howManyUsers}");
            //bany
            var getBans = await Global.Client.GetGuild(448884032391086090).GetBansAsync();
            int countBans = getBans.Count();
            var channelBans = Global.Client.GetGuild(448884032391086090).GetVoiceChannel(482933297362763776);
            await channelBans.ModifyAsync(y => y.Name = $"🚫 Bany: {countBans}");
            //staty
            var msgExp = await kanalStaty.GetMessageAsync(Global.MsgStatyExp);
            var msgExpR = msgExp as RestUserMessage;
            var msgKasa = await kanalStaty.GetMessageAsync(Global.MsgStatyKasa);
            var msgKasaR = msgKasa as RestUserMessage;

            var orderedUsers = UserAccounts.UserAccounts.GetAllAccounts().OrderByDescending(acc => acc.XP).ToList().Take(8);
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("Top 8 graczy - LVL");
            foreach (var userAccount in orderedUsers)
            {
                uint level = (uint)Math.Sqrt(userAccount.XP / 50);
                var user = Global.Client.GetUser(userAccount.ID);
                eb.AddField("Gracz: ", user == null ? "Nie znaleziono" : user.Username, true);
                eb.AddField("Exp: ", userAccount.XP, true);
                eb.AddField("Poziom: ", level, true);
            }
            eb.WithColor(Color.Gold);

            await msgExpR.ModifyAsync(message =>
            {
                message.Content = "";
                message.Embed = null;
                message.Embed = eb.Build();
            });

            var orderedUserss = UserAccounts.UserAccounts.GetAllAccounts().OrderByDescending(acc => acc.MoneyWallet).ToList().Take(8);
            EmbedBuilder ebb = new EmbedBuilder();
            ebb.WithTitle("Top 8 graczy - KASA");
            foreach (var userAccount in orderedUserss)
            {
                uint level = (uint)Math.Sqrt(userAccount.XP / 50);
                var userr = Global.Client.GetUser(userAccount.ID);
                ebb.AddField("Gracz: ", userr == null ? "Nie znaleziono" : userr.Username, true);
                ebb.AddField("Kasa: ", userAccount.MoneyWallet, true);
                ebb.AddField("Poziom: ", level, true);
            }
            ebb.WithColor(Color.Green);

            await msgKasaR.ModifyAsync(message =>
            {
                message.Content = "";
                message.Embed = null;
                message.Embed = ebb.Build();
            });
            //pogoda
            string weatherID = "433f32924ecebe72d3ff2b702ac1e498";
            string weatherString = "❌ Błąd Pogody";
            try
            {
                string response = "";
                using (var http = new HttpClient())
                {
                    response = await http.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?q=warsaw&appid=" + weatherID + "&units=metric").ConfigureAwait(false);
                }

                if (response.Contains("\"main\":\"Rain\""))
                    weatherString = "🌧️ Pogoda: Deszczowo";
                if (response.Contains("\"main\":\"Clouds\""))
                    weatherString = "☁️ Pogoda: Pochmurnie";
                if (response.Contains("\"main\":\"Snow\""))
                    weatherString = "🌨️ Pogoda: Śnieg";
                if (response.Contains("\"main\":\"Clear\""))
                    weatherString = "☀️ Pogoda: Słonecznie";
                if (response.Contains("\"main\":\"Thunderstorm\""))
                    weatherString = "⛈️ Pogoda: Burza";
                if (response.Contains("\"main\":\"Extreme\""))
                    weatherString = "⛈️ Pogoda: Apokalipsa";
                if (response.Contains("\"main\":\"Drizzle\""))
                    weatherString = "🌦️ Pogoda: Lekki deszcz";
                if (response.Contains("\"main\":\"Mist\""))
                    weatherString = "🌫️ Pogoda: Mgliście";
                await weatherchannel.ModifyAsync(y => y.Name = $"{weatherString}");
            }
            catch (Exception f)
            {
                Console.WriteLine(f);
            }
        }
    }
}
