using System;
using System.Collections.Generic;
using System.Text;

using Discord.WebSocket;
using ggwp.Services.Weather;

namespace ggwp
{
    internal static class Global
    {
        internal static DiscordSocketClient Client { get; set; }

        public static WeatherService weatherService;

        public static int NextActivity { get; set; }

        public static ulong MsgStatyExp { get; set; }

        public static ulong MsgStatyKasa { get; set; }

        public static string[] Swearwords = new[] { "kurw", "dziwk", "pierdo", "pierda", "huj", "pizd", "jeba", "jebi", "cwel", "kutas" };

        public static string TimeDate = DateTime.Now.ToString("dd.MM.yyyy");

        public static long[] OffLevelingChannelsId = new[] { 517789718772056095 }; //TO TRZEBA KONIECZNIE ZMIENIC!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }
}
