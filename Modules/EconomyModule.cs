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

using ggwp.Core.UserAccounts;
using ggwp.Services.Cooldown;

using Newtonsoft.Json;
using ggwp.Services.Economy;

namespace ggwp.Modules
{
    public class EconomyModule : ModuleBase<SocketCommandContext>
    {
        [Cooldown(5)]
        [Command("stankonta")]
        [Alias("kasa", "stan konta", "pieniadze", "pieniądze")]
        public async Task Balance()
        {           
            await EconomyService.BalanceCommandErrorMessage(Context.Guild, Context.Channel);
        }

        [Cooldown(5)]
        [Command("przelew")]
        [Alias("przelej", "przekaż")]
        public async Task TransferMoney(IGuildUser user, ulong MoneyToTransfer)
        {
            await EconomyService.TransferMoney(Context.Guild, Context.Channel, Context.Message, (IGuildUser)Context.User, user, MoneyToTransfer);
        }

        [Cooldown(5)]
        [Command("daily")]
        [Alias("dzienna", "free")]
        public async Task DailyMoney()
        {
            await EconomyService.DailyCommandErrorMessage(Context.Guild, Context.Channel);
        }
    }
}
