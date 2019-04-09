using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;

using ggwp.Core.UserAccounts;
using ggwp.Core.GuildAccounts;

namespace ggwp.Services.Managment_Methods
{
    public static class ManagmentService
    {
        public static async Task Warn(IGuild guild, IMessage message, IGuildUser warneduser, IUser administrator, [Remainder] string reason)
        {
            await message.DeleteAsync();
            //Variables
            string TimeByDate = Global.TimeDate;
            var UserAccount = UserAccounts.GetAccount((SocketUser)warneduser);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong PenaltyChannelID = GuildAccount.PenaltyChannelID;
            var PenaltyChannel = ContextGuild.GetChannel(PenaltyChannelID) as IMessageChannel;
            string WarnNumberString;
            //Giving warn to user and saveing accounts
            UserAccount.Warns++;
            UserAccounts.SaveAccounts();

            if (UserAccount.Warns >= 6)
            {
                await warneduser.Guild.AddBanAsync(warneduser, 5);
                WarnNumberString = "6 na 5 - banicja";
                await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateWarnEmbed(warneduser, administrator, TimeByDate, WarnNumberString, reason));
            }
            else if (UserAccount.Warns == 5)
            {
                await warneduser.KickAsync();
                WarnNumberString = "5 na 5 - wyrzucenie";
                await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateWarnEmbed(warneduser, administrator, TimeByDate, WarnNumberString, reason));
            }
            else if (UserAccount.Warns == 4)
            {
                WarnNumberString = "4 na 5";
                await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateWarnEmbed(warneduser, administrator, TimeByDate, WarnNumberString, reason));
            }
            else if (UserAccount.Warns == 3)
            {
                WarnNumberString = "3 na 5";
                await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateWarnEmbed(warneduser, administrator, TimeByDate, WarnNumberString, reason));
            }
            else if (UserAccount.Warns == 2)
            {
                WarnNumberString = "2 na 5";
                await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateWarnEmbed(warneduser, administrator, TimeByDate, WarnNumberString, reason));
            }
            else if (UserAccount.Warns == 1)
            {
                WarnNumberString = "1 na 5";
                await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateWarnEmbed(warneduser, administrator, TimeByDate, WarnNumberString, reason));
            }
        }

        public static async Task Config(SocketGuild guild, ISocketMessageChannel channel, SocketUserMessage message, string action, string option, string value)
        {
            await message.DeleteAsync();

            var GuildAccount = GuildAccounts.GetAccount(guild);

            if (action == "viev" || action == "list")
            {
                var DivideArray1 = (GuildAccount.OffLevelingChannelsId == null) ? null : GuildAccount.OffLevelingChannelsId.Skip(1).Aggregate(GuildAccount.OffLevelingChannelsId[0].ToString(), (s, i) => s + "," + i.ToString());
                await channel.SendMessageAsync($"```cs\nID: {GuildAccount.ID}\nPenaltyChannelID: {GuildAccount.PenaltyChannelID}\nAnnouncmentChannelID: {GuildAccount.AnnouncmentChannelID}\nVoteChannelID: {GuildAccount.VoteChannelID}\nBankChannelID: {GuildAccount.BankChannelID}\nWelcomeChannelID: {GuildAccount.WelcomeChannelID}\nCountingChannelID: {GuildAccount.CountingChannelID}\nMemesChannelID: {GuildAccount.MemesChannelID}\nGiveawayChannelID: {GuildAccount.GiveawayChannelID}\nShopPage: {GuildAccount.ShopPage}\nGamblingPage: {GuildAccount.GamblingPage}\nAdmChannelID: {GuildAccount.AdmChannelID}\nSuggestionsChannelID: {GuildAccount.SuggestionsChannelID}\nInviteLink: {GuildAccount.InviteLink}\nOffLevelingChannelsId: {DivideArray1}\nRekrutacja: {GuildAccount.Rekrutacja}```");
            }
            else if (action == "set")
            {
                if (option == null || value == null)
                {
                    await channel.SendMessageAsync($"{Messages.wrong} Opcja i Wartość nie mogą być puste. `!config set opcja wartość`");
                    return;
                }
                if (option == "ID")
                    GuildAccount.ID = Convert.ToUInt64(value);
                else if(option == "PenaltyChannelID")
                    GuildAccount.PenaltyChannelID = Convert.ToUInt64(value);
                else if (option == "AnnouncmentChannelID")
                    GuildAccount.AnnouncmentChannelID = Convert.ToUInt64(value);
                else if (option == "VoteChannelID")
                    GuildAccount.VoteChannelID = Convert.ToUInt64(value);
                else if (option == "BankChannelID")
                    GuildAccount.BankChannelID = Convert.ToUInt64(value);
                else if (option == "WelcomeChannelID")
                    GuildAccount.WelcomeChannelID = Convert.ToUInt64(value);
                else if (option == "CountingChannelID")
                    GuildAccount.CountingChannelID = Convert.ToUInt64(value);
                else if (option == "MemesChannelID")
                    GuildAccount.MemesChannelID = Convert.ToUInt64(value);
                else if (option == "GiveawayChannelID")
                    GuildAccount.GiveawayChannelID = Convert.ToUInt64(value);
                else if (option == "ShopPage")
                    GuildAccount.ShopPage = Convert.ToUInt32(value);
                else if (option == "GamblingPage")
                    GuildAccount.GamblingPage = Convert.ToUInt32(value);
                else if (option == "AdmChannelID")
                    GuildAccount.AdmChannelID = Convert.ToUInt64(value);
                else if (option == "SuggestionsChannelID")
                    GuildAccount.SuggestionsChannelID = Convert.ToUInt64(value);
                else if (option == "InviteLink")
                    GuildAccount.InviteLink = value;
                else if (option == "OffLevelingChannelsId")
                {
                    long[] ConvertedArray = value.Split(",").Select(long.Parse).ToArray();
                    GuildAccount.OffLevelingChannelsId = ConvertedArray;
                }
                else if (option == "Rekrutacja")
                    GuildAccount.Rekrutacja = Convert.ToBoolean(value);

                GuildAccounts.SaveAccounts();
                await channel.SendMessageAsync($"{Messages.check} Pomyślnie zaktualizowano `{option}: {value}`");
            }
        }

        public static async Task SayAsBot(IMessage message, ISocketMessageChannel channel, string text)
        {
            await message.DeleteAsync();
            await channel.SendMessageAsync($"{text}");
        }

        public static async Task Kick(IGuild guild, IMessage message, IGuildUser kickuser, IGuildUser administrator, [Remainder] string reason)
        {
            await message.DeleteAsync();
            //Variables
            string TimeByDate = Global.TimeDate;
            var UserAccount = UserAccounts.GetAccount((SocketUser)kickuser);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong PenaltyChannelID = GuildAccount.PenaltyChannelID;
            var PenaltyChannel = ContextGuild.GetChannel(PenaltyChannelID) as IMessageChannel;
            //Kick user
            await kickuser.KickAsync(reason);
            //Send message
            await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateKickEmbed(kickuser, administrator, TimeByDate, reason));
        }

        public static async Task Vote(IGuild guild, IMessage message, IGuildUser user, string question, string option)
        {
            await message.DeleteAsync();

            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong VoteChannelID = GuildAccount.VoteChannelID;
            var VoteChannel = ContextGuild.GetChannel(VoteChannelID) as IMessageChannel;

            var yes = Emote.Parse(Messages.check);
            var no = Emote.Parse(Messages.wrong);

            string[] emotes = { "\u0031\u20e3", "\u0032\u20e3", "\u0033\u20e3", "\u0034\u20e3", "\u0035\u20e3", "\u0036\u20e3", "\u0037\u20e3", "\u0038\u20e3", "\u0039\u20e3" };

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"ANKIETA");
            eb.Author.WithIconUrl("https://cdn4.iconfinder.com/data/icons/social-messaging-ui-color-and-shapes-3/177800/136-512.png");
            eb.WithDescription(question);
            eb.WithColor(Color.Blue);
            var msg = await VoteChannel.SendMessageAsync("", false, eb.Build());

            int.TryParse(option, out var num);

            if (option == "yesno" || option == "taknie" || option == "noyes" || option == "nietak")
            {
                await msg.AddReactionAsync(yes);
                await msg.AddReactionAsync(no);
            }
            else if(num <= emotes.Length)
            {
                for (var i = 0; i < num; i++)
                {
                    await msg.AddReactionAsync(new Emoji(emotes[i]));
                }
            }
        }

        public static async Task Giveaway(IGuild guild, IMessage message, uint timeInHours, uint money, IRole role = null)
        {
            await message.DeleteAsync();

            string reward = "";

            var emoji = new Emoji("🎊");
            var coin = Messages.coin;

            if (money == 0 && role == null)
            {
                return;
            }
            if (money == 0 && role != null)
                reward = $"👤 {role.Mention}";
            if (money != 0 && role == null)
                reward = $"{coin} {money}";
            if (money != 0 && role != null)
            {
                reward = $"{coin} {money}\n👤 {role.Mention}";
            }

            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong GiveawayChannelID = GuildAccount.GiveawayChannelID;
            var GiveawayChannel = ContextGuild.GetChannel(GiveawayChannelID) as IMessageChannel;

            uint TimeInMilisecs = timeInHours * 3600000;

            var time = DateTime.Now;
            var time2 = time.AddHours(TimeInMilisecs);
            var time3 = time2.ToString("HH:mm");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("GIVEAWAY");
            eb.Author.WithIconUrl("https://freeiconshop.com/wp-content/uploads/edd/gift-flat.png");
            eb.WithDescription($"**Nagroda:**\n {reward}\n\n**Wyniki o:** {time3}");
            eb.WithFooter("👇 ZAREAGUJ ABY WZIĄĆ UDZIAŁ!");
            eb.WithColor(Color.Gold);

            RestUserMessage msg = (RestUserMessage)await GiveawayChannel.SendMessageAsync("@everyone", false, eb.Build());
            Global.GiveawayMessageID = msg.Id;
            await msg.AddReactionAsync(emoji);

            await Task.Delay(Convert.ToInt32(TimeInMilisecs));

            await msg.UpdateAsync();
            var UsersThatReacted = (await msg.GetReactionUsersAsync(emoji)).Where(u => u.IsBot == false).ToArray();
            Random rand = new Random();
            var randomuser = UsersThatReacted[rand.Next(UsersThatReacted.Length)];
            await GiveawayChannel.SendMessageAsync($":confetti_ball: GRATULACJE :confetti_ball:\n{randomuser.Mention} wygrywa.");
            try
            {
                var UserToAddRole = ContextGuild.GetUser(randomuser.Id);
                await UserToAddRole.AddRoleAsync(role);
            }
            catch { }
            try
            {
                var UserAccount = UserAccounts.GetAccount(randomuser);
                UserAccount.MoneyAccount += money;
                UserAccounts.SaveAccounts();
            }
            catch { }
    }

        public static async Task Announcment(IGuild guild, IMessage message, IGuildUser user, string content)
        {
            await message.DeleteAsync();

            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong AnnChannelID = GuildAccount.AnnouncmentChannelID;
            var AnnChannel = ContextGuild.GetChannel(AnnChannelID) as IMessageChannel;

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"OGŁOSZENIE");
            eb.Author.WithIconUrl("http://www.wsbedu.eu/wp-content/uploads/2017/05/bhp.png");
            eb.WithDescription(content);
            eb.WithColor(new Color(250, 166, 26));
            await AnnChannel.SendMessageAsync("@everyone", false, eb.Build());
        }

        public static async Task Ban(IGuild guild, IMessage message, IGuildUser banuser, IGuildUser administrator, [Remainder] string reason)
        {
            await message.DeleteAsync();
            //Variables
            string TimeByDate = Global.TimeDate;
            var UserAccount = UserAccounts.GetAccount((SocketUser)banuser);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong PenaltyChannelID = GuildAccount.PenaltyChannelID;
            var PenaltyChannel = ContextGuild.GetChannel(PenaltyChannelID) as IMessageChannel;
            //Ban user
            await banuser.Guild.AddBanAsync(banuser, 5, reason);
            //Send message
            await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateBanEmbed(banuser, administrator, TimeByDate, reason));
        }

        public static async Task Mute(IGuild guild, IMessage message, IGuildUser muteuser, IGuildUser administrator,int time, [Remainder] string reason)
        {
            await message.DeleteAsync();
            //Variables
            string TimeDate = Global.TimeDate;
            var UserAccount = UserAccounts.GetAccount((SocketUser)muteuser);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong PenaltyChannelID = GuildAccount.PenaltyChannelID;
            var PenaltyChannel = ContextGuild.GetChannel(PenaltyChannelID) as IMessageChannel;
            //Mute user
            UserAccount.UnmuteTime = DateTime.Now.Add(TimeSpan.FromSeconds(time));
            UserAccounts.SaveAccounts();
            //Send message
            await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateMuteEmbed(muteuser, administrator, TimeDate, time, reason));
        }
        public static async Task Promote(IGuild guild, IMessage message, IRole role, IGuildUser promoteuser, IGuildUser administrator, [Remainder] string reason)
        {
            await message.DeleteAsync();
            //Variables
            string TimeDate = Global.TimeDate;
            var UserAccount = UserAccounts.GetAccount((SocketUser)promoteuser);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong PenaltyChannelID = GuildAccount.PenaltyChannelID;
            var PenaltyChannel = ContextGuild.GetChannel(PenaltyChannelID) as IMessageChannel;

            var RoleAdm = guild.Roles.FirstOrDefault(x => x.Id == 517062140612313089);
            var RoleStazysta = guild.Roles.FirstOrDefault(x => x.Name == "STAŻYSTA");
            var RolePomocnik = guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK");
            var RolePomocnikPlus = guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK+");
            var RoleModerator = guild.Roles.FirstOrDefault(x => x.Name == "MODERATOR");
            var RoleAdministrator = guild.Roles.FirstOrDefault(x => x.Name == "ADMIN");
            var RoleOwner = guild.Roles.FirstOrDefault(x => x.Name == "WŁAŚCICIEL");

            var SocketGuildAdministrator = (SocketGuildUser)administrator;

            //pomocnik
            if (SocketGuildAdministrator.Roles.Contains(RolePomocnik) && (role == RoleStazysta || role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;
            //pomocnik plus
            if (SocketGuildAdministrator.Roles.Contains(RolePomocnikPlus) && (role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;
            //moderator
            if (SocketGuildAdministrator.Roles.Contains(RoleModerator) && (role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;
            //administrator
            if (SocketGuildAdministrator.Roles.Contains(RoleAdministrator) && (role == RoleAdministrator || role == RoleOwner))
                return;

            //Promote user
            await promoteuser.AddRoleAsync(role);
            if(role == RoleStazysta || role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator)
                await promoteuser.AddRoleAsync(RoleAdm);
            //Send message
            await PenaltyChannel.SendMessageAsync("", false, Messages.GeneratePromoteEmbed(promoteuser, administrator, role, TimeDate, reason));
        }
        public static async Task Demote(IGuild guild, IMessage message, IRole role, IGuildUser demoteuser, IGuildUser administrator, [Remainder] string reason)
        {
            await message.DeleteAsync();
            //Variables
            string TimeDate = Global.TimeDate;
            var UserAccount = UserAccounts.GetAccount((SocketUser)demoteuser);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong PenaltyChannelID = GuildAccount.PenaltyChannelID;
            var PenaltyChannel = ContextGuild.GetChannel(PenaltyChannelID) as IMessageChannel;

            var RoleAdm = guild.Roles.FirstOrDefault(x => x.Id == 517062140612313089);
            var RoleStazysta = guild.Roles.FirstOrDefault(x => x.Name == "STAŻYSTA");
            var RolePomocnik = guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK");
            var RolePomocnikPlus = guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK+");
            var RoleModerator = guild.Roles.FirstOrDefault(x => x.Name == "MODERATOR");
            var RoleAdministrator = guild.Roles.FirstOrDefault(x => x.Name == "ADMIN");
            var RoleOwner = guild.Roles.FirstOrDefault(x => x.Name == "WŁAŚCICIEL");

            var SocketGuildAdministrator = (SocketGuildUser)administrator;

            //pomocnik
            if (SocketGuildAdministrator.Roles.Contains(RolePomocnik) && (role == RoleStazysta || role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;
            //pomocnik plus
            if (SocketGuildAdministrator.Roles.Contains(RolePomocnikPlus) && (role == RoleStazysta || role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;
            //moderator
            if (SocketGuildAdministrator.Roles.Contains(RoleModerator) && (role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;
            //administrator
            if (SocketGuildAdministrator.Roles.Contains(RoleAdministrator) && (role == RoleModerator || role == RoleAdministrator || role == RoleOwner))
                return;

            //Demote user
            await demoteuser.RemoveRoleAsync(role);
            if (role == RoleStazysta || role == RolePomocnik || role == RolePomocnikPlus || role == RoleModerator || role == RoleAdministrator)
                await demoteuser.RemoveRoleAsync(RoleAdm);
            //Send message
            await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateDemoteEmbed(demoteuser, administrator, role, TimeDate, reason));
        }
    }
}
