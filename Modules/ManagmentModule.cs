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

using ggwp.Services.Managment_Methods;
using ggwp.Core.GuildAccounts;

namespace ggwp.Modules
{
    public class ManagmentModule : ModuleBase<SocketCommandContext>
    {
        [Command("sayasbot")]
        [Alias("botmsg", "botsay")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task SayAsBot([Remainder] string text = "")
        {
            await ManagmentService.SayAsBot(Context.Message, Context.Channel, text);
        }

        [Command("config")]
        [Alias("settings", "opcje")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Config(string Action, string Option = null, string Value = null)
        {
            await ManagmentService.Config(Context.Guild, Context.Channel, Context.Message, Action, Option, Value);
        }

        [Command("warn")]
        [Alias("ostrzezenie", "ostrzeżenie")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task WarnUser(IGuildUser user, [Remainder] string reason = "Brak.")
        {
            //sprawdzić kogo warnuje - permy
            await ManagmentService.Warn(Context.Guild, Context.Message, user, (IGuildUser)Context.User, reason);
        }

        [Command("kick")]
        [Alias("wyrzuc", "wyrzuć")]
        [RequireUserPermission(GuildPermission.KickMembers)]
        public async Task KickUser(IGuildUser user, [Remainder] string reason = "Brak.")
        {
            //sprawdzic kogo kickuje - permy
            await ManagmentService.Kick(Context.Guild, Context.Message, user, (IGuildUser)Context.User, reason);
        }

        [Command("ban")]
        [Alias("banuj")]
        [RequireUserPermission(GuildPermission.BanMembers)]
        public async Task BanUser(IGuildUser user, [Remainder] string reason = "Brak.")
        {
            //sprawdzic kogo banuje - permy
            await ManagmentService.Ban(Context.Guild, Context.Message, user, (IGuildUser)Context.User, reason);
        }

        [Command("mute")]
        [Alias("wycisz", "mutuj", "wyciszenie")]
        [RequireUserPermission(GuildPermission.MuteMembers)]
        public async Task MuteUser(IGuildUser user, int TimeInSeconds = 0, [Remainder] string reason = "Brak.")
        {
            //sprawdzic kogo mutuje - permy
            await ManagmentService.Mute(Context.Guild, Context.Message, user, (IGuildUser)Context.User, TimeInSeconds, reason);
        }

        [Command("awans")]
        [Alias("awansuj", "dodaj role", "dodajrole")]
        [RequireUserPermission(GuildPermission.ManageWebhooks)]
        public async Task PromoteUser(IGuildUser user, IRole role, [Remainder] string reason = "Brak.")
        {
            //dodać żeby nie mogło dawać ról wyższych niż svip chyba że ktoś jest ownerem
            await ManagmentService.Promote(Context.Guild, Context.Message, role, user, (IGuildUser)Context.User, reason);
        }

        [Command("degrad")]
        [Alias("degraduj", "usunrole", "usun role", "usuńrole", "usuń role")]
        [RequireUserPermission(GuildPermission.ManageWebhooks)]
        public async Task DemoteUser(IGuildUser user, IRole role, [Remainder] string reason = "Brak.")
        {
            //dodać żeby nie mogło usuwać ról wyższych niż svip chyba że ktoś jest ownerem
            await ManagmentService.Demote(Context.Guild, Context.Message, role, user, (IGuildUser)Context.User, reason);
        }

        [Command("ogłoszenie")]
        [Alias("ogl", "ogł", "ogloszenie")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Announcment([Remainder] string content)
        {
            await ManagmentService.Announcment(Context.Guild, Context.Message, (IGuildUser)Context.User, content);
        }

        [Command("ankieta")]
        [Alias("vote")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Vote(string option, [Remainder] string question)
        {
            await ManagmentService.Vote(Context.Guild, Context.Message, (IGuildUser)Context.User, question, option);
        }

        [Command("purge", RunMode = RunMode.Async)]
        [Alias("clear", "clean", "delete", "czyść", "czysc", "cc")]
        [RequireUserPermission(GuildPermission.ManageMessages)]
        public async Task Clear(int amountOfMessagesToDelete)
        {
            try
            {
                await Context.Message.DeleteAsync();
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }

            if (amountOfMessagesToDelete > 100 || amountOfMessagesToDelete < 0)
            {
                await ReplyAsync($"{Messages.wrong} {Context.User.Mention}, musisz wybrać więcej niż 0 lecz mniej niż 100 wiadomości!");
                return;
            }

            await ReplyAsync("***🗑️ Usuwam " + $"{amountOfMessagesToDelete}" + " wiadomości...***");

            var messages = await Context.Channel.GetMessagesAsync(amountOfMessagesToDelete + 1).FlattenAsync();

            var channel = Context.Message.Channel as SocketTextChannel;

            try
            {
                await channel.DeleteMessagesAsync(messages);
            }
            catch (ArgumentOutOfRangeException)
            {
                var num = await Context.Channel.GetMessagesAsync(1).FlattenAsync();
                var channelx = Context.Message.Channel as SocketTextChannel;
                await channelx.DeleteMessagesAsync(num);
                await ReplyAsync($"{Messages.wrong} {Context.User.Mention}, wiadomości nie mogą być starsze niż 14 dni!");
            }

            const int delay = 5000;
            await Task.Delay(delay);
        }

        [Command("giveaway", RunMode = RunMode.Async)]
        [Alias("ga", "gaway")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Giveaway(uint TimeInHours, uint Money = 0, IRole role = null)
        {
            await ManagmentService.Giveaway(Context.Guild, Context.Message, TimeInHours, Money, role);
        }
    }
}
