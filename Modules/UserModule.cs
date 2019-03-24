using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;

using ggwp.Core;
using ggwp.Services.Cooldown;
using ggwp.Core.GuildAccounts;

namespace ggwp.Modules
{
    public class User : ModuleBase
    {
        [Cooldown(60)]
        [Command("podanie")]
        public async Task Application([Remainder] string podanie)
        {
            try
            {
                var client = Context.Client as DiscordSocketClient;
                var guild = client.GetGuild(448884032391086090);
                var GuildAccount = GuildAccounts.GetAccount(guild);
                var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
                var admChannel = guild.GetChannel(GuildAccount.AdmChannelID) as ITextChannel;
                var nie = Emote.Parse(Messages.wrong);
                var tak = Emote.Parse(Messages.check);

                if (Context.Channel is IPrivateChannel)
                {
                    EmbedBuilder eb = new EmbedBuilder();
                    eb.WithAuthor(Context.User.Username);
                    eb.Author.WithIconUrl(Context.User.GetAvatarUrl());
                    eb.WithTitle("Podanie");
                    eb.WithDescription(podanie);
                    eb.WithColor(Color.Blue);
                    eb.WithCurrentTimestamp();
                    var msg = await admChannel.SendMessageAsync("", false, eb.Build());
                    await msg.AddReactionAsync(tak);
                    await msg.AddReactionAsync(nie);
                    await dmChannel.SendMessageAsync($"{Messages.check} Podanie zostało dostarczone do administracji. Jeśli uda Ci się przejść do kolejnego etapu ktoś z administracji Cię poinformuje.");
                }
                else
                {
                    await Context.Channel.SendMessageAsync("Napisz swoje podanie pod komendą `!podanie [treść]` w wiadomości prywatnej do bota.\n**Nie pisz podań do członków administracji!**");
                    await dmChannel.SendMessageAsync("`!podanie [treść]` aby napisać podanie :)");
                }
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }
        }

        [Cooldown(30)]
        [Command("propozycja")]
        public async Task Suggestion([Remainder] string propozycja)
        {
            try
            {
                var client = Context.Client as DiscordSocketClient;
                var guild = client.GetGuild(448884032391086090);
                var GuildAccount = GuildAccounts.GetAccount(guild);

                var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
                var sugChannel = guild.GetChannel(GuildAccount.SuggestionsChannelID) as ITextChannel;
                var admChannel = guild.GetChannel(GuildAccount.AdmChannelID) as ITextChannel;

                var nie = Emote.Parse(Messages.wrong);
                var ok = new Emoji("🆗");

                if (Context.Channel is IPrivateChannel)
                {
                    //Building and sending message
                    EmbedBuilder eb = new EmbedBuilder();
                    eb.WithAuthor(Context.User.Username);
                    eb.Author.WithIconUrl(Context.User.GetAvatarUrl());
                    eb.WithTitle("Propozycja");
                    eb.WithDescription(propozycja);
                    eb.WithColor(Color.Green);
                    eb.WithCurrentTimestamp();
                    var msg = await admChannel.SendMessageAsync("", false, eb.Build());
                    await msg.AddReactionAsync(nie);
                    await msg.AddReactionAsync(ok);
                    //Response
                    await dmChannel.SendMessageAsync($"{Messages.check} Propozycja została wysłana pomyślnie.");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{Messages.wrong}Swoją propozycję napisz w wiadomości prywatnej.");
                    await dmChannel.SendMessageAsync("`!propozycja [treść]` aby napisać propozycje :)");
                }
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }
        }

        [Cooldown(20)]
        [Command("link")]
        [Alias("zaproszenie", "zapro", "invite", "inv")]
        public async Task Invitation()
        {
            try
            {
                var client = Context.Client as DiscordSocketClient;
                var guild = client.GetGuild(448884032391086090);
                var GuildAccount = GuildAccounts.GetAccount(guild);

                var dmChannel = await Context.User.GetOrCreateDMChannelAsync();

                if (Context.Channel is IPrivateChannel)
                {
                    await dmChannel.SendMessageAsync($"🔗 Proszę, oto link do naszego serwera 🔗\n{GuildAccount.InviteLink}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{Messages.check} {Context.User.Mention}, wysłano link w wiadomości prywatnej.");
                    await dmChannel.SendMessageAsync($"🔗 Proszę, oto link do naszego serwera 🔗\n{GuildAccount.InviteLink}");
                }
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }
        }

        [Cooldown(2)]
        [Command("cytat")]
        [Alias("cytuj")]
        public async Task Cytat(IUser user, [Remainder]string cytat)
        {
            await Context.Message.DeleteAsync();

            if (cytat == "")
            {
                await ReplyAsync($"{Messages.wrong} {Context.User.Mention}, musisz wpisać tekst!");
                return;
            }

            await ReplyAsync($"{Context.User.Mention} cytuje użytkownika {user.Mention}\n*{cytat}*");
        }
    }
}
