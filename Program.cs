using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using Discord;
using Discord.WebSocket;

using ggwp.Core;
using ggwp.Services.Managment_Methods;
using ggwp.Services.Reaction_Methods;
using ggwp.Core.UserAccounts;
using ggwp.Core.LevelingSystem;
using ggwp.Services.Weather;

namespace ggwp
{
    class Program
    {
        DiscordSocketClient _client;
        private IServiceProvider _services;

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
            _client.MessageReceived += Helpers.AntiSwear;
            _client.MessageReceived += Helpers.AntiAdvertisment;
            _client.MessageReceived += Helpers.MemesChannel;
            _client.MessageReceived += Helpers.CountingChannel;
            _client.ReactionAdded += Reaction_Added.ReactionReport;;
            _client.ReactionAdded += Reaction_Added.ReactionGames;
            _client.ReactionAdded += Reaction_Added.ReactionGames2;
            _client.ReactionAdded += Reaction_Added.ReactionSklep;
            _client.ReactionAdded += Reaction_Added.ReactionPlec;
            _client.ReactionAdded += Reaction_Added.ReactionPlec2;
            _client.ReactionAdded += Reaction_Added.ReactionReg;
            _client.ReactionAdded += Reaction_Added.ReactionWiek;
            _client.ReactionAdded += Reaction_Added.ReactionWiek2;
            _client.ReactionAdded += Reaction_Added.ReactionPomoc;
            _client.ReactionAdded += Reaction_Added.ReactionMeme;
            _client.ReactionAdded += Reaction_Added.ReactionCashmashine;
            _client.ReactionAdded += Reaction_Added.ReactionApproval;
            _client.ReactionAdded += Reaction_Added.ReactionProfile;
            _client.ReactionAdded += Reaction_Added.ReactionGambling;
            _client.ReactionAdded += Reaction_Added.ReactionFun1;
            _client.ReactionAdded += Reaction_Added.ReactionFun2;
            _client.ReactionAdded += Reaction_Added.ReactionFun3;
            _client.ReactionAdded += Reaction_Added.ReactionFun4;
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
            await Task.Delay(-1);
        }

        private async Task UserJoined(SocketGuildUser user)
        {
            var userAccount = UserAccounts.GetAccount(user);
            UserAccounts.SaveAccounts();
            var r1 = user.Guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 1/5");
            var r2 = user.Guild.Roles.FirstOrDefault(x => x.Id == 517062410050469898);
            var r3 = user.Guild.Roles.FirstOrDefault(x => x.Id == 548973612317671424);
            var r4 = user.Guild.Roles.FirstOrDefault(x => x.Id == 517063485364895783);
            var r5 = user.Guild.Roles.FirstOrDefault(x => x.Id == 517063595612307466);
            var r6 = user.Guild.Roles.FirstOrDefault(x => x.Id == 521721061008474113);
            var r7 = user.Guild.Roles.FirstOrDefault(x => x.Id == 521734161401249802);
            var r8 = user.Guild.Roles.FirstOrDefault(x => x.Id == 521734162437111821);
            var r9 = user.Guild.Roles.FirstOrDefault(x => x.Id == 556550338912452610);

            await user.AddRolesAsync(new[] { r1, r2, r3, r4, r5, r6, r7, r8, r9});
        }

        public static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.Message);
            return Task.CompletedTask;
        }
    }
}
