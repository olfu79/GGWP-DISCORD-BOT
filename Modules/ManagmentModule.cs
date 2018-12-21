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
        [Alias("wycisz")]
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
    }
}
