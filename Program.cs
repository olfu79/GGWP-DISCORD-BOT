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
using Discord.Addons.Interactive;
using ggwp.Services;

namespace ggwp
{
    class Program
    {
        DiscordSocketClient _client;
        CommandHandler _handler;
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
            //_client.Ready += RepeatingTimer.StartTimer;
            //_client.MessageReceived += AntiSwear;
            //_client.MessageReceived += AntiAdv;
            //_client.ReactionAdded += Reaction_Added.ReactionReport;
            _client.ReactionAdded += Reaction_Added.ReactionGames;
            _client.ReactionAdded += Reaction_Added.ReactionSklep;
            _client.ReactionAdded += Reaction_Added.ReactionPlec;
            _client.ReactionAdded += Reaction_Added.ReactionReg;
            _client.ReactionAdded += Reaction_Added.ReactionWiek;
            _client.ReactionAdded += Reaction_Added.ReactionPomoc;
            _client.ReactionAdded += Reaction_Added.ReactionMeme;
            _client.ReactionAdded += Reaction_Added.ReactionCashmashine;
            //_client.ReactionAdded += Reaction_Added.ReactionJackpot;
            _client.UserJoined += UserJoined;
            //Global.weatherService = new WeatherService();
            //_services = new ServiceCollection().AddSingleton<WeatherService>().BuildServiceProvider();
            _services = new ServiceCollection()
                .AddSingleton(_client)
                .AddSingleton<InteractiveService>()
                .BuildServiceProvider();
            await _client.LoginAsync(TokenType.Bot, Config.bot.token);
            await _client.StartAsync();
            Global.Client = _client;
            //_client.Ready += SetGame;
            _handler = new CommandHandler();
            await _handler.InitializeAsync(_client);
            //await ConsoleInput();
            await Task.Delay(-1);
        }

        private Task UserJoined(SocketGuildUser user)
        {
            var userAccount = UserAccounts.GetAccount(user);
            UserAccounts.SaveAccounts();
            return Task.CompletedTask;
            //daj role "nowy członek 1/4"
        }

        private async Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
        }
    }
}
