using System;
using System.Collections.Generic;
using System.Text;

using Discord.WebSocket;

namespace ggwp
{
    internal static class Global
    {
        internal static DiscordSocketClient Client { get; set; }

        public static string TimeDate = DateTime.Now.ToString("dd.MM.yyyy");
        //TO TRZEBA KONIECZNIE ZMIENIC!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public static long[] OffLevelingChannelsId = new[] { 517789718772056095 };
    }
}
