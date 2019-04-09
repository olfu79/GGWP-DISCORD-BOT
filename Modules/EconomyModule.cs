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
        [Alias("kasa", "stan konta", "pieniadze", "pieniądze", "money")]
        public async Task Balance()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await EconomyService.BalanceCommandErrorMessage(Context.Guild, Context.Channel);
        }

        [Cooldown(5)]
        [Command("przelew")]
        [Alias("przelej", "przekaż", "płać", "plac", "pay")]
        public async Task TransferMoney(IGuildUser user, ulong MoneyToTransfer)
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await EconomyService.TransferMoney(Context.Guild, Context.Channel, Context.Message, (IGuildUser)Context.User, user, MoneyToTransfer);
        }

        [Cooldown(5)]
        [Command("daily")]
        [Alias("dzienna", "free")]
        public async Task DailyMoney()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await EconomyService.DailyCommandErrorMessage(Context.Guild, Context.Channel);
        }

        [Command("userbalance")]
        [Alias("user balance", "userb", "usermoney", "user money", "userm")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task ManageMoney(string option, string option2, IUser user, uint money)
        {
            if (Context.Channel is IPrivateChannel)
                return;

            var UserAccount = UserAccounts.GetAccount(user);

            if(option == "add" || option == "dodaj")
            {
                try
                {
                    if (option2 == "konto" || option2 == "k")
                    {
                        UserAccount.MoneyAccount += money;
                        await Context.Channel.SendMessageAsync($"{Messages.check} Pomyślnie **dodano** {money}{Messages.coin} **na konto** użytkownika {user.Mention}");
                    }
                    else if (option2 == "portfel" || option2 == "p")
                    {
                        UserAccount.MoneyWallet += money;
                        await Context.Channel.SendMessageAsync($"{Messages.check} Pomyślnie **dodano** {money}{Messages.coin} **do portfela** użytkownika {user.Mention}");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync(Messages.UnknownError);
                    }
                    UserAccounts.SaveAccounts();
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync(Messages.UnknownError);
                }
            }
            else if (option == "take" || option == "wez")
            {
                try
                {
                    if (option2 == "konto" || option2 == "k")
                    {
                        UserAccount.MoneyAccount -= money;
                        await Context.Channel.SendMessageAsync($"{Messages.check} Pomyślnie **zabrano** {money}{Messages.coin} **z konta** użytkownika {user.Mention}");
                    }
                    else if (option2 == "portfel" || option2 == "p")
                    {
                        UserAccount.MoneyWallet -= money;
                        await Context.Channel.SendMessageAsync($"{Messages.check} Pomyślnie **zabrano** {money}{Messages.coin} **z portfela** użytkownika {user.Mention}");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync(Messages.UnknownError);
                    }
                    UserAccounts.SaveAccounts();
                }
                catch(Exception e)
                {
                    await Context.Channel.SendMessageAsync(Messages.UnknownError);
                }
            }
            else if (option == "set" || option == "ustaw")
            {
                try
                {
                    if (option2 == "konto" || option2 == "k")
                    {
                        UserAccount.MoneyAccount = money;
                        await Context.Channel.SendMessageAsync($"{Messages.check} Pomyślnie **ustawiono stan konta** użytkownika {user.Mention} na {money}{Messages.coin}");
                    }
                    else if (option2 == "portfel" || option2 == "p")
                    {
                        UserAccount.MoneyWallet = money;
                        await Context.Channel.SendMessageAsync($"{Messages.check} Pomyślnie **ustawiono stan portfela** użytkownika {user.Mention} na {money}{Messages.coin}");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync(Messages.UnknownError);
                    }
                    UserAccounts.SaveAccounts();
                }
                catch (Exception e)
                {
                    await Context.Channel.SendMessageAsync(Messages.UnknownError);
                }
            }
            else
            {
                await Context.Channel.SendMessageAsync(Messages.UnknownError);
            }
        }
    }
}
