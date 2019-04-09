using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;

using ggwp.Core.UserAccounts;
using ggwp.Services;

using Newtonsoft.Json;
using ggwp.Services.Reaction_Methods;

namespace ggwp.Modules
{
    public class ReactionCommands : ModuleBase
    {
        [Command("a meme")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Meme()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Meme(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a sklep")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Shop()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Shop(Context.Guild, Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a bankomat")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Cashmachine()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Bank(Context.Message, Context.User, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver gry")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task GamesRoles()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Games(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a gry")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task GamesRoles2()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Games2(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a pomoc")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Help()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Help(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver plec")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Gender()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Gender(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a plec")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Gender2()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Gender2(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver wiek")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Age()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Age(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a wiek")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Age2()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Age2(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver regulamin")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Rules()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Rules(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a profil")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Profile()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Profile((ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }

        [Command("a gmbl", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Gambling()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Gambling(Context.Guild, (ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }

        [Command("a ver fun", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Fun()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Fun(Context.Guild, (ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }

        [Command("a fun", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Fun2()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await ReactionsService.Fun2(Context.Guild, (ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }
    }
}
