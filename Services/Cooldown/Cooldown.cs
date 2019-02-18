using Discord;
using Discord.Commands;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

//
//todo odpowiedz jezeli cooldown.
//

namespace ggwp.Services.Cooldown
{
    public class Cooldown : PreconditionAttribute
    {
        TimeSpan CooldownLength { get; set; }
        bool AdminsAreLimited { get; set; }
        readonly ConcurrentDictionary<CooldownInfo, DateTime> _cooldowns = new ConcurrentDictionary<CooldownInfo, DateTime>();

        public Cooldown(int seconds, bool adminsAreLimited = false)
        {
            CooldownLength = TimeSpan.FromSeconds(seconds);
            AdminsAreLimited = adminsAreLimited;
        }

        public struct CooldownInfo
        {
            public ulong UserId { get; }
            public int CommandHashCode { get; }

            public CooldownInfo(ulong userId, int commandHashCode)
            {
                UserId = userId;
                CommandHashCode = commandHashCode;
            }
        }

        public override Task<PreconditionResult> CheckPermissionsAsync(ICommandContext context, CommandInfo command, IServiceProvider services)
        {
            if (!AdminsAreLimited && context.User is IGuildUser user && user.GuildPermissions.Administrator)
                return Task.FromResult(PreconditionResult.FromSuccess());

            var key = new CooldownInfo(context.User.Id, command.GetHashCode());

            if (_cooldowns.TryGetValue(key, out DateTime endsAt))
            {
                var difference = endsAt.Subtract(DateTime.UtcNow);

                if (difference.Ticks > 0)
                {
                    return Task.FromResult(PreconditionResult.FromError($"Możesz użyć tej komendy znów za: {difference.ToString(@"mm\:ss")}"));
                }

                var time = DateTime.UtcNow.Add(CooldownLength);
                _cooldowns.TryUpdate(key, time, endsAt);
            }
            else
            {
                _cooldowns.TryAdd(key, DateTime.UtcNow.Add(CooldownLength));
            }

            return Task.FromResult(PreconditionResult.FromSuccess());
        }
    }
}