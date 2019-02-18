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
        public static async Task Warn(IGuild guild, IMessage message, IGuildUser warneduser, IGuildUser administrator, [Remainder] string reason)
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
            //Promote user
            await promoteuser.AddRoleAsync(role);//jesli awansuje do administracyjnej roli dodaj role ADMINISTRACJA
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
            //Demote user
            await demoteuser.RemoveRoleAsync(role); //jesli demotuje z administracyjnej roli odbirerz role ADMINISTRACJA
            //Send message
            await PenaltyChannel.SendMessageAsync("", false, Messages.GenerateDemoteEmbed(demoteuser, administrator, role, TimeDate, reason));
        }
    }
}
