using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using ggwp.Core.LevelingSystem;
using ggwp.Core.UserAccounts;

namespace ggwp
{
    class CommandHandler
    {
        DiscordSocketClient _client;
        CommandService _service;

        public CommandHandler(DiscordSocketClient client)
        {
            _client = client;
        }

        public void Initialize()
        {
            _service = new CommandService();
            _service.AddModulesAsync(Assembly.GetEntryAssembly());
            _client.MessageReceived += HandleCommandAsync;
        }

        public async Task HandleCommandAsync(SocketMessage s)
        {
            // Handle Commands
            if (!(s is SocketUserMessage msg)) return;
            var context = new SocketCommandContext(_client, msg);
            if (context.User.IsBot) return;

            // Mute
            var userAccount = UserAccounts.GetAccount(context.User);
            if (CheckIfMuted(context.User) == true)
            {
                await context.Message.DeleteAsync();
                return;
            }

            /*// Leveling up
            if (msg.Channel is SocketDMChannel) return;
            try
            {
                bool GiveXP = true; var UserMessages = (await msg.Channel.GetMessagesAsync
                (msg, Direction.Before, 2)
                .FlattenAsync())
                .Where(x => x.Author == msg.Author);
                foreach (var message in UserMessages)
                { if (message.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(10))) { GiveXP = false; } }
                if (GiveXP) { Leveling.UserSentMessage((SocketGuildUser)context.User, (SocketTextChannel)context.Channel, context.Message); }
            }
            catch { }*/

            // Error System
            int argPos = 0;
            if (msg.HasStringPrefix(Config.bot.cmdPrefix, ref argPos)
                || msg.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {

                var cmdSearchResult = _service.Search(context, argPos);

                if (!cmdSearchResult.IsSuccess) return;
                #pragma warning disable CS4014
                var executionTask = _service.ExecuteAsync(context, argPos);
                executionTask.ContinueWith(task =>
                {
                    if (task.Result.IsSuccess || task.Result.Error == CommandError.UnknownCommand) return;
                    const string errTemplate = "{0}, {1}.";
                    var errMessage = string.Format(errTemplate, context.User.Mention, task.Result.ErrorReason);
                    context.Channel.SendMessageAsync(errMessage);

                });
            }
        }
        private bool CheckIfMuted(SocketUser contextUser)
        {
            UserAccount account = UserAccounts.GetAccount(contextUser);
            return account.UnmuteTime - DateTime.Now >= TimeSpan.Zero;
        }
    }
}
