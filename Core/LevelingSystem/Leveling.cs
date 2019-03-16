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
                bool GiveXP = false;
                var UserMessages = (await message.Channel.GetMessagesAsync(message, Direction.Before, 2)
                .FlattenAsync())
                .Where(x => x.Author == message.Author);

                foreach (var mesage in UserMessages)
                {
                    if (message.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(10)))
                    {
                        GiveXP = false;
                    }
                }
                if (!GiveXP) { /*/ You may not give XP /*/}
            }
            catch { }

            if (Global.OffLevelingChannelsId.Contains((long)message.Channel.Id)) return;

            var coin = Emote.Parse("<:coin:462351821910835200>");

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

            var guild = user.Guild;
            var r1 = guild.Roles.FirstOrDefault(x => x.Id == 548964370517065740);
            var r2 = guild.Roles.FirstOrDefault(x => x.Id == 548963386713440276);
            var r3 = guild.Roles.FirstOrDefault(x => x.Id == 548963384910151701);
            var r4 = guild.Roles.FirstOrDefault(x => x.Id == 548963383056138262);
            var r5 = guild.Roles.FirstOrDefault(x => x.Id == 548963382175334411);
            var r6 = guild.Roles.FirstOrDefault(x => x.Id == 548963380892008467);
            var r7 = guild.Roles.FirstOrDefault(x => x.Id == 548963379146915902);
            var r8 = guild.Roles.FirstOrDefault(x => x.Id == 548963372922568725);
            var r9 = guild.Roles.FirstOrDefault(x => x.Id == 548963592741978149);
            var r10 = guild.Roles.FirstOrDefault(x => x.Id == 548963595237457990);
            var r11 = guild.Roles.FirstOrDefault(x => x.Id == 548963596684754944);
            var r12 = guild.Roles.FirstOrDefault(x => x.Id == 548963599998255154);
            var r13 = guild.Roles.FirstOrDefault(x => x.Id == 548963601700880386);
            var r14 = guild.Roles.FirstOrDefault(x => x.Id == 548963602506448896);

            if(newLevel == 1 || newLevel == 5 || newLevel == 10 || newLevel == 15 || newLevel == 20 || newLevel == 25 || newLevel == 30 || newLevel == 40 || newLevel == 50 || newLevel == 60 || newLevel == 70 || newLevel == 80 || newLevel == 90 || newLevel == 100)
            {
                await user.RemoveRoleAsync(r1);
                await user.RemoveRoleAsync(r2);
                await user.RemoveRoleAsync(r3);
                await user.RemoveRoleAsync(r4);
                await user.RemoveRoleAsync(r5);
                await user.RemoveRoleAsync(r6);
                await user.RemoveRoleAsync(r7);
                await user.RemoveRoleAsync(r8);
                await user.RemoveRoleAsync(r9);
                await user.RemoveRoleAsync(r10);
                await user.RemoveRoleAsync(r11);
                await user.RemoveRoleAsync(r12);
                await user.RemoveRoleAsync(r13);
                await user.RemoveRoleAsync(r14);
            }

            if (newLevel == 1)
                await user.AddRoleAsync(r1); 
            if (newLevel == 5)
                await user.AddRoleAsync(r2);
            if (newLevel == 10)
                await user.AddRoleAsync(r3);
            if (newLevel == 15)
                await user.AddRoleAsync(r4);
            if (newLevel == 20)
                await user.AddRoleAsync(r5);
            if (newLevel == 25)
                await user.AddRoleAsync(r6);
            if (newLevel == 30)
                await user.AddRoleAsync(r7);
            if (newLevel == 40)
                await user.AddRoleAsync(r8);
            if (newLevel == 50)
                await user.AddRoleAsync(r9);
            if (newLevel == 60)
                await user.AddRoleAsync(r10);
            if (newLevel == 70)
                await user.AddRoleAsync(r11);
            if (newLevel == 80)
                await user.AddRoleAsync(r12);
            if (newLevel == 90)
                await user.AddRoleAsync(r13);
            if (newLevel == 100)
                await user.AddRoleAsync(r14);
        }
    }
}
