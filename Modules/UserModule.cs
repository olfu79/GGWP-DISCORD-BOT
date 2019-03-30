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
using System.Linq;
using ggwp.Core.UserAccounts;

namespace ggwp.Modules
{
    public class User : ModuleBase<SocketCommandContext>
    {
        [Cooldown(60)]
        [Command("podanie")]
        public async Task Application([Remainder] string podanie)
        {
            var client = Context.Client as DiscordSocketClient;
            var guild = client.GetGuild(448884032391086090);
            var GuildAccount = GuildAccounts.GetAccount(guild);

            if (GuildAccount.Rekrutacja == false)
                await ReplyAsync($"{Messages.wrong} Aktualnie nie trwa rekrutacja.");
            else
            {
                try
                {
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
        }

        [Cooldown(30)]
        [Command("propozycja")]
        [Alias("proponuj")]
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

        [Cooldown(5)]
        [Command("pomoc")]
        [Alias("help")]
        public async Task Help()
        {
            await Context.Message.DeleteAsync();

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("POMOC");
            eb.Author.WithIconUrl("https://cdn2.iconfinder.com/data/icons/flat-style-svg-icons-part-1/512/confirmation_verification-512.png");
            eb.WithDescription($"📜 Lista komend dostępna pod `!komendy`\n❔ Częste pytania i kontakt z administracją na kanale {Messages.HelpChannel}");
            eb.WithColor(new Color(7, 116, 180));
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(5)]
        [Command("komendy")]
        [Alias("commands")]
        public async Task Commands(string option = null)
        {
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();

            if (Context.Channel is IPrivateChannel)
            {
                if (option is null)
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsCategoriesEmbed());
                else if (option.ToLower() == "gracz")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsGraczEmbed());
                else if (option.ToLower() == "zabawa" || option.ToLower() == "fun")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsFunEmbed());
                else if (option.ToLower() == "ekonomia" || option.ToLower() == "kasa")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMoneyEmbed());
                else if (option.ToLower() == "pogoda")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsWeatherEmbed());
                else if (option.ToLower() == "muzyka")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMusicEmbed());
                else if (option.ToLower() == "akinator" || option.ToLower() == "aki")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsAkinatorEmbed());
                else
                {
                    await ReplyAsync($"{Messages.wrong} {Context.User.Mention} Nie ma takiej kategorii!");
                    return;
                }
            }
            else
            {
                await Context.Message.DeleteAsync();

                if (option is null)
                    await Context.Channel.SendMessageAsync("", false, Messages.GenerateCommandsCategoriesEmbed());
                else if(option.ToLower() == "gracz")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsGraczEmbed());
                else if (option.ToLower() == "zabawa" || option.ToLower() == "fun")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsFunEmbed());
                else if (option.ToLower() == "ekonomia" || option.ToLower() == "kasa")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMoneyEmbed());
                else if (option.ToLower() == "pogoda")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsWeatherEmbed());
                else if (option.ToLower() == "muzyka")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMusicEmbed());
                else if (option.ToLower() == "akinator" || option.ToLower() == "aki")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsAkinatorEmbed());
                else
                {
                    await ReplyAsync($"{Messages.wrong} {Context.User.Mention} Nie ma takiej kategorii!");
                    return;
                }

                var msg = await ReplyAsync($"{Messages.check} {Context.User.Mention} Wysłano listę komend w wiadomości prywatnej.");
                await Helpers.RemoveMessage(msg);
            }
        }
        [Command("rozwiazano")]
        [Alias("rozwiązano", "solved", "zamknij", "close")]
        public async Task CloseHelpChannel(SocketGuildUser user = null)
        {
            var pomocnik = Context.Guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK");
            var pomocnikp = Context.Guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK+");
            var moderator = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MODERATOR");
            var admin = Context.Guild.Roles.FirstOrDefault(x => x.Name == "ADMIN");
            var wlascicel = Context.Guild.Roles.FirstOrDefault(x => x.Name == "WŁAŚCICIEL");

            UserAccount account;
            if(user is null)
                account = UserAccounts.GetAccount(Context.User);
            else if (user != null && (Context.User as SocketGuildUser).Roles.Contains(pomocnik) || (Context.User as SocketGuildUser).Roles.Contains(pomocnikp) || (Context.User as SocketGuildUser).Roles.Contains(moderator) || (Context.User as SocketGuildUser).Roles.Contains(admin) || (Context.User as SocketGuildUser).Roles.Contains(wlascicel))
                account = UserAccounts.GetAccount(user);
            else
            {
                await ReplyAsync($"{Messages.UnknownError}");
                return;
            }

            bool isHelp = account.HelpInProgress;
            ulong idHelp = account.HelpChannelID;

            if (isHelp == true && idHelp != 0)
            {
                var channel = Context.Guild.GetChannel(idHelp);
                await channel.DeleteAsync();
                account.HelpInProgress = false;
                account.HelpChannelID = 0;
                UserAccounts.SaveAccounts();
            }
            else
            {
                await ReplyAsync($"{Messages.wrong} Nie znaleziono kanału do zamknięcia.");
            }
        }
    }
}
