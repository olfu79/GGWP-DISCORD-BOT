using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using ggwp.Core.GuildAccounts;
using ggwp.Core.UserAccounts;

namespace ggwp.Services.Economy
{
    public static class EconomyService
    {
        public static async Task TransferMoney(IGuild guild, ISocketMessageChannel channel ,IMessage message, IGuildUser UserGivingMoney, IGuildUser UserReceivingMoney, ulong MoneyToTransfer)
        {
            await message.DeleteAsync();
            //Variables
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var ContextGuild = guild as SocketGuild;
            ulong BankChannelID = GuildAccount.BankChannelID;
            var BankChannel = ContextGuild.GetChannel(BankChannelID) as IMessageChannel;
            //Checking if user doing command on specified channel
            if (channel.Id != BankChannelID)
            {
                var ErrorMessage = await channel.SendMessageAsync(Messages.EconomyTransferCommandOnlyInBank(ContextGuild, BankChannelID));
                await Helpers.RemoveMessage(ErrorMessage);
                return;
            }
            //Transfer
            if (UserGivingMoney == UserReceivingMoney)//Error - user tried to give money himself
            {
                var ErrorMessage = await channel.SendMessageAsync(Messages.EconomyTransferCantGiveYourself);
                await Helpers.RemoveMessage(ErrorMessage);
            }
            else if (UserGivingMoney.IsBot)//Error - user is bot
            {
                var ErrorMessage = await channel.SendMessageAsync(Messages.EconomyTransferCantGiveBot);
                await Helpers.RemoveMessage(ErrorMessage);
            }
            else//Success - One more check
            {
                var UserGivingMoneyAccount = UserAccounts.GetAccount((SocketUser)UserGivingMoney);
                var UserReceivingMoneyAccount = UserAccounts.GetAccount((SocketUser)UserReceivingMoney);
                ulong MoneyBalanceGiver = UserGivingMoneyAccount.MoneyWallet;
                if (MoneyBalanceGiver < MoneyToTransfer)//Checking if user can afford this deal
                {
                    var ErrorMessage = await channel.SendMessageAsync(Messages.EconomyTransferNotEnoughMoney);
                    await Helpers.RemoveMessage(ErrorMessage);
                    return;
                }
                else//If so, deal is completed
                {
                    UserGivingMoneyAccount.MoneyWallet -= MoneyToTransfer;
                    UserReceivingMoneyAccount.MoneyAccount += MoneyToTransfer;

                    var SuccessMessage = await channel.SendMessageAsync(Messages.EconomyTransferCompleted(MoneyToTransfer, UserGivingMoney, UserReceivingMoney));
                    await Helpers.RemoveMessage(SuccessMessage);
                }
                UserAccounts.SaveAccounts();
            }
        }

        public static async Task BalanceCommandErrorMessage(IGuild guild, ISocketMessageChannel channel)
        {
            var GuildAccount = GuildAccounts.GetAccount(guild);
            ulong BankChannelID = GuildAccount.BankChannelID;

            var ErrorMessage = await channel.SendMessageAsync(Messages.EconomyBalanceCommandError(guild, BankChannelID));
            await Helpers.RemoveMessage(ErrorMessage);
        }

        public static async Task DailyCommandErrorMessage(IGuild guild, ISocketMessageChannel channel)
        {
            var GuildAccount = GuildAccounts.GetAccount(guild);
            ulong BankChannelID = GuildAccount.BankChannelID;

            var ErrorMessage = await channel.SendMessageAsync(Messages.EconomyDailyCommandError(guild, BankChannelID));
            await Helpers.RemoveMessage(ErrorMessage);
        }

        public static async Task<string> MysteryBox1(SocketGuild guild ,SocketReaction reaction)
        {
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);

            string reward = "";
            string coin = Messages.coin;

            Random rand1 = new Random();
            int RandomNumber = rand1.Next(0, 100);

            if (RandomNumber <= 25)
            {// Nothing
                reward = "0";
                return reward;
            }
            if (RandomNumber <= 50)
            {// Money 0 to 1000
                Random randS = new Random();
                int result = randS.Next(0, 1001);
                reward = $"{result.ToString()}{coin}";

                UserAccount.MoneyWallet += (ulong)result;
                return reward;
            }
            if(RandomNumber <= 65)
            {// Animal - fish
                reward = "RYBĘ 🐟";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐟");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if(RandomNumber <= 80)
            {//Vehicle - bike
                reward = "ROWER 🚲";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🚲");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 100)
            {// Money 1000 to 2000
                Random randB = new Random();
                int result = randB.Next(1000, 2001);
                reward = $"{result.ToString()}{coin}";

                UserAccount.MoneyWallet += (ulong)result;
                return reward;
            }
            return reward;
        }

        public static async Task<string> MysteryBox2(SocketGuild guild, SocketReaction reaction)
        {
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);

            string reward = "";
            string coin = Messages.coin;

            Random rand1 = new Random();
            int RandomNumber = rand1.Next(0, 100);

            if (RandomNumber <= 25)
            {// Nothing
                reward = "0";
                return reward;
            }
            if (RandomNumber <= 50)
            {// Money 500 to 2000
                Random randS = new Random();
                int result = randS.Next(500, 2001);
                reward = $"{result.ToString()}{coin}";

                UserAccount.MoneyWallet += (ulong)result;
                return reward;
            }
            if (RandomNumber <= 65)
            { // Money 2000 to 3500
                Random randB = new Random();
                int result = randB.Next(2000, 3501);
                reward = $"{result.ToString()}{coin}";

                UserAccount.MoneyWallet += (ulong)result;
                return reward;
            }
            if (RandomNumber <= 70)
            { // Vip Role
                reward = $"RANGA VIP {Messages.vip}";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "VIP");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 80)
            { // Nick Role
                reward = "ZMIANĘ NICKU 🏷️";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🏷️");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 85)
            { // Aki Role
                reward = "DOSTĘP DO AKINATORA 👳";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "👳");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 90)
            { // Music Role
                reward = "DOSTĘP DO MUZYKI 🎵";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🎵");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 91)
            { // Animal: fish
                reward = "RYBĘ 🐟";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐟");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 92)
            { // Animal: chamster
                reward = "CHOMIKA 🐹";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐹");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 93)
            { // Animal: dog
                reward = "PIESKA 🐶";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐶");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 94)
            { // Animal: cat
                reward = "KOTKA 🐱";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐱");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 95)
            { // Animal: horse
                reward = "KONIA 🐴";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐴");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 97)
            { // Vehicle: bike
                reward = "ROWER 🚲";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🚲");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 99)
            { // Vehicle: car
                reward = "SAMOCHÓD 🚗";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🚗");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 100)
            { // Vehicle: sailboat
                reward = "ŻAGLÓWKĘ ⛵";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "⛵");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }

            return reward;
        }

        public static async Task<string> MysteryBox3(SocketGuild guild, SocketReaction reaction)
        {
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);

            string reward = "";
            string coin = Messages.coin;

            Random rand1 = new Random();
            int RandomNumber = rand1.Next(0, 100);

            if (RandomNumber <= 25)
            {// Nothing
                reward = "0";
                return reward;
            }
            if (RandomNumber <= 50)
            {// Money 1500 to 3000
                Random randS = new Random();
                int result = randS.Next(1500, 3001);
                reward = $"{result.ToString()}{coin}";

                UserAccount.MoneyWallet += (ulong)result;
                return reward;
            }
            if (RandomNumber <= 65)
            { // Money 3000 to 5000
                Random randB = new Random();
                int result = randB.Next(3000, 5001);
                reward = $"{result.ToString()}{coin}";

                UserAccount.MoneyWallet += (ulong)result;
                return reward;
            }
            if (RandomNumber <= 75)
            { // Vip Role
                reward = $"RANGA VIP {Messages.vip}";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "VIP");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 81)
            { // Svip role
                reward = $"RANGA SVIP {Messages.svip}";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "SVIP");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 86)
            { // Music Role
                reward = "DOSTĘP DO MUZYKI 🎵";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🎵");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 91)
            { // Aki Role
                reward = "DOSTĘP DO AKINATORA 👳";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "👳");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 92)
            { // Animal: dog
                reward = "PIESKA 🐶";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐶");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 93)
            { // Animal: cat
                reward = "KOTKA 🐱";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐱");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 94)
            { // Animal: horse
                reward = "KONIA 🐴";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐴");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 95)
            { // Animal: penguin
                reward = "PINGWINKA 🐧";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐧");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 96)
            { // Animal: panda
                reward = "PANDĘ 🐼";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🐼");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 97)
            { // Vehicle: car
                reward = "SAMOCHÓD 🚗";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🚗");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 98)
            { // Vehicle: sailboat
                reward = "ŻAGLÓWKĘ ⛵";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "⛵");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 99)
            { // Vehicle: train
                reward = "POCIĄG 🚂";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🚂");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }
            if (RandomNumber <= 100)
            { // Vehicle: motorbike
                reward = "MOTOCYKL 🏍️";

                var RoleToAdd = guild.Roles.FirstOrDefault(x => x.Name == "🏍️");
                var CastUser = (SocketGuildUser)reaction.User;
                await CastUser.AddRoleAsync(RoleToAdd);
                return reward;
            }

            return reward;
        }
    }
}
