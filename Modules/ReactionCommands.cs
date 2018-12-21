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
        ////PRZYWOŁUJEMY TYLKO METODY KTÓRE BĘDĄ W Reaction Methods!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        [Command("a meme")]
        public async Task Meme()//sklep: sklep z itemami
        {
            await ReactionsService.Meme(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a sklep")]
        public async Task Shop()//sklep: sklep z itemami
        {
            await ReactionsService.Shop(Context.Guild ,Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a coinflip")]
        public async Task Coinflip()//kasyno: coinflip
        {
        }

        [Command("a ruletka")]
        public async Task Rulette()//kasyno: ruletka
        {
        }

        [Command("a bankomat")]
        public async Task Cashmachine()//bankomat: daily, wpłać, wypłać, stankonta
        {
            await ReactionsService.Bank(Context.Message, Context.User, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a gry")]
        public async Task GamesRoles()
        {
            await ReactionsService.Games(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a pomoc")]
        public async Task Help()//pomoc: lista komend pv, kanał pomocy, informacje o rangach, zaproszenie - link na serwer, statystyka gracza
        {
            await ReactionsService.Help(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a plec")]
        public async Task Gender()
        {
            await ReactionsService.Gender(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a wiek")]
        public async Task Age()
        {
            await ReactionsService.Age(Context.Message, (ISocketMessageChannel)Context.Channel);
        }

        [Command("a regulamin")]
        public async Task Rules()
        {
            await ReactionsService.Rules(Context.Message, (ISocketMessageChannel)Context.Channel);
        }
    }
}
