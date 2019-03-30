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
        public async Task Meme()
        {
            await ReactionsService.Meme(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a sklep")]
        public async Task Shop()
        {
            await ReactionsService.Shop(Context.Guild, Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a bankomat")]
        public async Task Cashmachine()
        {
            await ReactionsService.Bank(Context.Message, Context.User, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver gry")]
        public async Task GamesRoles()
        {
            await ReactionsService.Games(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a gry")]
        public async Task GamesRoles2()
        {
            await ReactionsService.Games2(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a pomoc")]
        public async Task Help()
        {
            await ReactionsService.Help(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver plec")]
        public async Task Gender()
        {
            await ReactionsService.Gender(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a plec")]
        public async Task Gender2()
        {
            await ReactionsService.Gender2(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a ver wiek")]
        public async Task Age()
        {
            await ReactionsService.Age(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a wiek")]
        public async Task Age2()
        {
            await ReactionsService.Age2(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a regulamin")]
        public async Task Rules()
        {
            await ReactionsService.Rules(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a profil")]
        public async Task Profile()
        {
            await ReactionsService.Profile((ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }

        [Command("a gmbl", RunMode = RunMode.Async)]
        public async Task Gambling()
        {
            await ReactionsService.Gambling(Context.Guild, (ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }

        [Command("a ver fun", RunMode = RunMode.Async)]
        public async Task Fun()
        {
            await ReactionsService.Fun(Context.Guild, (ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }

        [Command("a fun", RunMode = RunMode.Async)]
        public async Task Fun2()
        {
            await ReactionsService.Fun2(Context.Guild, (ISocketMessageChannel)Context.Channel, Context.User, Context.Message);
        }
    }
}
