using Discord;
using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ggwp.Core.LevelingSystem
{
    internal static class Leveling
    {
        internal static async void UserSentMessage(SocketGuildUser user, SocketTextChannel channel, SocketUserMessage message)
        {
            try
            {
                bool GiveXP = false; var UserMessages = (await message.Channel.GetMessagesAsync
                (message, Direction.Before, 2)
                .FlattenAsync()) // Flatten() if you're on 1.2
                .Where(x => x.Author == message.Author);
                foreach (var mesage in UserMessages)
                { if (message.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(10))) { GiveXP = false; } }
                if (!GiveXP) { /*/ You may not give XP /*/}
            }
            catch { }

            if (Global.OffLevelingChannelsId.Contains((long)message.Channel.Id)) return;

            var coin = Emote.Parse("<:coin:462326527661572097>");

            var userAccount = UserAccounts.UserAccounts.GetAccount(user);
            uint oldLevel = userAccount.LevelNumber;
            userAccount.XP += 50;
            UserAccounts.UserAccounts.SaveAccounts();
            uint newLevel = userAccount.LevelNumber;
            uint MoneyForLevel = newLevel * 50;

            if (oldLevel != newLevel)
            {
                // the user leveled up
                var msg = await channel.SendMessageAsync($":confetti_ball: Gratulacje {user.Mention} awansowałeś na poziom {newLevel}. Otrzymujesz {MoneyForLevel}{coin}");
                userAccount.MoneyWallet += MoneyForLevel;
                UserAccounts.UserAccounts.SaveAccounts();
                await Helpers.RemoveMessage(msg, 5);
            }
        }
    }
}
