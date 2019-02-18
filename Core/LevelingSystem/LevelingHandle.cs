using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

using Discord;
using Discord.Commands;
using Discord.WebSocket;

using ggwp.Core.UserAccounts;
using ggwp.Core.LevelingSystem;

namespace ggwp.Core.LevelingSystem
{
    public class LevelingHandle
    {
        DiscordSocketClient _client;

        public LevelingHandle(DiscordSocketClient client)
        {
            _client = client;
        }

        public void Initialize()
        {
            _client.MessageReceived += HandleLevelingAsync;
        }

        public async Task HandleLevelingAsync(SocketMessage msg)
        {
            if (msg.Author.IsBot) return;

            if (msg.Channel is SocketDMChannel) return;
            try
            {
                bool GiveXP = true;
                var UserMessages = (await msg.Channel.GetMessagesAsync(msg, Direction.Before, 2)
                .FlattenAsync())
                .Where(x => x.Author == msg.Author);

                foreach (var message in UserMessages)
                {
                    if (message.CreatedAt >= DateTimeOffset.UtcNow.Subtract(TimeSpan.FromSeconds(10)))
                    {
                        GiveXP = false;
                    }
                }

                if (GiveXP)
                {
                    Leveling.UserSentMessage((SocketGuildUser)msg.Author, (SocketTextChannel)msg.Channel, msg as SocketUserMessage);
                }
            }
            catch(Exception e)
            {
            }
        }
    }
}
