using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;

using Microsoft.Extensions.DependencyInjection;

using Discord;
using Discord.Commands;
using Discord.Net;
using Discord.Rest;
using Discord.WebSocket;

using ggwp.Core;
using ggwp.Modules;
using ggwp.Services.Managment_Methods;
using ggwp.Services.Reaction_Methods;
using ggwp.Core.UserAccounts;
using ggwp.Core.GuildAccounts;
using ggwp.Core.LevelingSystem;
using Discord.Addons.Interactive;
using ggwp.Services;
using ggwp.Services.Weather;

namespace ggwp
{
    class Program
    {
        DiscordSocketClient _client;
        private IServiceProvider _services;
        //Time variable
        readonly string time = DateTime.Now.ToString("dd.MM.yyyy");

        static void Main(string[] args)
        => new Program().StartAsync().GetAwaiter().GetResult();

        public async Task StartAsync()
        {
            if (Config.bot.token == "" || Config.bot.token == null) return;
            _client = new DiscordSocketClient(new DiscordSocketConfig
            {
                LogLevel = LogSeverity.Verbose
            });
            _client.Log += Log;
            _client.Ready += RepeatingTimer.StartTimer;
            _client.MessageReceived += AntiSwear;
            _client.MessageReceived += AntiAdvertisment;
            _client.MessageReceived += MemesChannel;
            _client.MessageReceived += CountingChannel;
            //_client.ReactionAdded += Reaction_Added.ReactionReport;;
            _client.ReactionAdded += Reaction_Added.ReactionGames;
            _client.ReactionAdded += Reaction_Added.ReactionSklep;
            _client.ReactionAdded += Reaction_Added.ReactionPlec;
            _client.ReactionAdded += Reaction_Added.ReactionReg;
            _client.ReactionAdded += Reaction_Added.ReactionWiek;
            _client.ReactionAdded += Reaction_Added.ReactionPomoc;
            _client.ReactionAdded += Reaction_Added.ReactionMeme;
            _client.ReactionAdded += Reaction_Added.ReactionCashmashine;
            _client.ReactionAdded += Reaction_Added.ReactionApproval;
            _client.ReactionAdded += Reaction_Added.ReactionProfile;
            _client.ReactionAdded += Reaction_Added.ReactionGambling;
            _client.ReactionAdded += Reaction_Added.ReactionFun1;
            _client.ReactionAdded += Reaction_Added.ReactionFun2;
            _client.UserJoined += UserJoined;
            Global.weatherService = new WeatherService();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton<LevelingHandle>()
                .AddSingleton<CommandHandler>()
                .AddSingleton<WeatherService>()
                .BuildServiceProvider();
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            Global.Client = _client;
            var commandHandler = _services.GetRequiredService<CommandHandler>();
            commandHandler.Initialize();
            var levelHandler = _services.GetRequiredService<LevelingHandle>();
            levelHandler.Initialize();
            //await ConsoleInput();
            await Task.Delay(-1);
        }

        private async Task CountingChannel(SocketMessage msg)
        {
            var channel = msg.Channel as IGuildChannel;
            var Guild = channel.Guild as SocketGuild;
            var GuildAccount = GuildAccounts.GetAccount(Guild);

            ulong CountingChannelID = GuildAccount.CountingChannelID;

            if (msg.Channel.Id == CountingChannelID)
            {
                if (msg.Author.IsBot) { return; }

                var CountingChannel = Guild.GetChannel(CountingChannelID) as IMessageChannel;

                if (!msg.Content.Any(Char.IsDigit))
                {
                    await msg.DeleteAsync();
                    var InfoMsg = await CountingChannel.SendMessageAsync("Na tym kanale można wysyłać tylko liczby.");
                    await Helpers.RemoveMessage(InfoMsg);
                }
            }
        }

        private async Task MemesChannel(SocketMessage msg)
        {
            var channel = msg.Channel as IGuildChannel;
            var Guild = channel.Guild as SocketGuild;
            var GuildAccount = GuildAccounts.GetAccount(Guild);

            ulong MemesChannelID = GuildAccount.MemesChannelID;

            if (msg.Channel.Id == MemesChannelID)
            {
                if (msg.Author.IsBot) { return; }

                var MemesChannel = Guild.GetChannel(MemesChannelID) as IMessageChannel;

                if (!msg.Attachments.Any())
                {
                    await msg.DeleteAsync();
                    var InfoMsg = await MemesChannel.SendMessageAsync($"{Messages.wrong} Na tym kanale można wysyłać tylko obrazki.");
                    await Helpers.RemoveMessage(InfoMsg);
                }
                else
                {
                    var attachments = msg.Attachments;
                    foreach (var attachment in attachments)
                    {
                        if (attachment.Filename.EndsWith(".jpg") || attachment.Filename.EndsWith(".jpeg") || attachment.Filename.EndsWith(".png") || attachment.Filename.EndsWith(".gif") || attachment.Filename.EndsWith(".bmp"))
                        {
                            var like = new Emoji("👍");
                            var dislike = new Emoji("👎");
                            var MemeMessage = msg as IUserMessage;
                            await MemeMessage.AddReactionAsync(like);
                            await MemeMessage.AddReactionAsync(dislike);
                        }
                        else
                        {
                            await msg.DeleteAsync();
                            var InfoMsg = await MemesChannel.SendMessageAsync($"{Messages.wrong} Na tym kanale nie można wysyłać innych plików niż obrazki.");
                            await Helpers.RemoveMessage(InfoMsg);
                        }
                    }
                }
            }
        }

        private Task UserJoined(SocketGuildUser user)
        {
            var userAccount = UserAccounts.GetAccount(user);
            UserAccounts.SaveAccounts();
            var r1 = user.Guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 1/5");
            user.AddRoleAsync(r1);
            return Task.CompletedTask;
        }

        private async Task AntiSwear(SocketMessage arg)
        {
            if (arg.Author.IsBot) return;
            if (Global.Swearwords.Any(word => arg.Content.ToLower().Contains(word)) == false) return;
            {
                if (arg.Channel is SocketDMChannel) return;
                await arg.DeleteAsync();
                var msg = await arg.Channel.SendMessageAsync($":angry: {arg.Author.Mention} Nie przeklinaj! :zipper_mouth:");
                await Helpers.RemoveMessage(msg, 5);
            }
        }

        private async Task AntiAdvertisment(SocketMessage msg)
        {
            var guildChannel = msg.Channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            var user = msg.Author as SocketGuildUser;
            var rola = guild.Roles.FirstOrDefault(x => x.Id == 446765076490223618);

            if (msg.Author.IsBot) return;
            if (Global.Advertismentwords.Any(word => msg.Content.ToLower().Contains(word)) == false || msg.Content.Contains("discord.gg/xXKrd5R") || user.Roles.Contains(rola)) return;
            {
                var pamietaj = Emote.Parse("<:thinksmart:460770233171443713>");
                await msg.DeleteAsync();
                var MessageToRemove = await msg.Channel.SendMessageAsync($":rage: {msg.Author.Mention} Reklamowanie cudzych serwerów nie jest dozwolone! :warning: Dopisuję ostrzeżenie.\n{pamietaj} Pamiętaj że nasz serwer ma tylko jedno oficjalne zaproszenie.\n:anger_right: Wpisz `!zaproszenie` aby je otrzymać.");
                await Helpers.RemoveMessage(MessageToRemove, 5);
                var uslessmsg = await msg.Channel.SendMessageAsync(".");

                string reason = "Reklamowanie innych serwerów discord.";
                var administrator = Global.Client.CurrentUser;

                await ManagmentService.Warn(guild, uslessmsg, user, administrator, reason);
            }
        }

        public static async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
