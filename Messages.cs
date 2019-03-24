using System;
using System.Collections.Generic;
using System.Text;

using Discord.WebSocket;
using Discord;
using Discord.Commands;
using ggwp.Core.GuildAccounts;

namespace ggwp
{
    internal static class Messages
    {
        public static string coin = "<:coin:462351821910835200>";
        public static string check = "<:CheckMark:460770234177945610>";
        public static string wrong = "<:WrongMark:460770239286870017>";
        public static string vip = "<:supervip:462351820501549066>";
        public static string svip = "<:ultravip:462351820308873246>";

        public static string UnknownError = $"{wrong} Nieznany błąd!";

        public static string MentionError = $"{wrong} Musisz kogoś oznaczyć!";

        public static Embed GenerateWarnEmbed(IGuildUser warnedUser, IUser administrator,string DateTime, string warnnumbermessage, string reason = "Brak.")
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Ostrzeżenie.");
            eb.Author.WithIconUrl("https://i.imgur.com/yr1R5Ri.png");
            eb.AddField("Karany:", $"{warnedUser}", true);
            eb.AddField("Powód:", $"{reason}", true);
            eb.AddField("Liczba ostrzeżeń:", $"{warnnumbermessage}", true);
            eb.WithColor(new Color(255, 246, 0));
            eb.WithFooter($"Przez: {administrator} • {DateTime}");
            return eb.Build();
        }

        public static Embed GenerateKickEmbed(IGuildUser kickUser, IGuildUser administrator, string DateTime, string reason = "Brak.")
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Wyrzucenie.");
            eb.Author.WithIconUrl("https://i.imgur.com/vQkft1H.png");
            eb.AddField("Karany:", $"{kickUser}", true);
            eb.AddField("Powód:", $"{reason}", true);
            eb.WithColor(new Color(255, 136, 0));
            eb.WithFooter($"Przez: {administrator} • {DateTime}");
            return eb.Build();
        }

        public static Embed GenerateBanEmbed(IGuildUser banUser, IGuildUser administrator, string DateTime, string reason = "Brak.")
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Banicja.");
            eb.Author.WithIconUrl("https://i.imgur.com/vreZSYQ.png");
            eb.AddField("Karany:", $"{banUser}", true);
            eb.AddField("Powód:", $"{reason}", true);
            eb.WithColor(new Color(211, 6, 6));
            eb.WithFooter($"Przez: {administrator} • {DateTime}");
            return eb.Build();
        }

        public static Embed GenerateMuteEmbed(IGuildUser muteUser, IGuildUser administrator, string DateTime, int time, string reason = "Brak.")
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Wyciszenie.");
            eb.Author.WithIconUrl("https://i.imgur.com/pRbO5wz.png");
            eb.AddField("Karany:", $"{muteUser}", true);
            eb.AddField("Powód:", $"{reason}", true);
            eb.AddField("Czas:", $"{time} sekund", true);
            eb.WithColor(new Color(220, 0, 255));
            eb.WithFooter($"Przez: {administrator} • {DateTime}");
            return eb.Build();
        }

        public static Embed GeneratePromoteEmbed(IGuildUser user, IGuildUser administrator, IRole role, string DateTime, string reason = "Brak.")
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"Użytkownik {user} awansował!");
            eb.Author.WithIconUrl("https://i.imgur.com/z4ZrPhY.png");
            eb.AddField("Ranga:", $"{role.Mention}");
            eb.AddField("Powód:", $"{reason}", true);
            eb.WithColor(new Color(26, 219, 64));
            eb.WithFooter($"Przez: {administrator} • {DateTime}");
            return eb.Build();
        }

        public static Embed GenerateDemoteEmbed(IGuildUser user, IGuildUser administrator, IRole role, string DateTime, string reason = "Brak.")
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"Użytkownik {user} stracił rangę!");
            eb.Author.WithIconUrl("https://i.imgur.com/0v9N3Hn.png");
            eb.AddField("Ranga:", $"{role.Mention}");
            eb.AddField("Powód:", $"{reason}", true);
            eb.WithColor(new Color(29, 142, 229));
            eb.WithFooter($"Przez: {administrator} • {DateTime}");
            return eb.Build();
        }
        //Misc
        public static string MiscCooldown = "{wrong} Nie możesz użyć tej komendy przez: ";
        //Economy
        public static string EconomyBalanceCommandError(IGuild guild, ulong BankChannelID)
        {
            string EconomyBalanceCommandError = $"{wrong} Aby sprawdzić swój stan konta udaj się na kanał <#{BankChannelID}> i kliknij w odpowiednią reakcję.";
            return EconomyBalanceCommandError;
        }

        public static string EconomyDailyCommandError(IGuild guild, ulong BankChannelID)
        {
            string EconomyDailyCommandError = $"{wrong} Aby odebrać darmowe pieniądze udaj się na kanał <#{BankChannelID}> i kliknij w odpowiednią reakcję.";
            return EconomyDailyCommandError;
        }

        public static string EconomyTransferCommandOnlyInBank(IGuild guild, ulong BankChannelID)
        {
            string EconomyTransferCommandOnlyInBank = $"{wrong} Transfer pieniędzy możesz wykonywać tylko w <#{BankChannelID}>";
            return EconomyTransferCommandOnlyInBank;
        }

        public static string EconomyTransferCantGiveYourself = "{wrong} Nie możesz przekazać pieniędzy samemu sobie.";

        public static string EconomyTransferCantGiveBot = "{wrong} Nie możesz przekazać pieniędzy botowi.";

        public static string EconomyTransferNotEnoughMoney = "{wrong} Nie masz tyle pieniędzy w portfelu.";

        public static string EconomyTransferCompleted(ulong ammount, IGuildUser UserGiver, IGuildUser UserGetter)
        {
            string EconomyTransferCompleted = $"{check} Użytkownik {UserGiver.Mention} pomyślnie przetransferował {ammount.ToString()} {coin} użytkownikowi {UserGetter.Mention}.";
            return EconomyTransferCompleted;
        }
        //Shop
        public static string ShopPurchaseCompleated(IUser Customer, string item, ulong price)
        {
            string PurchaseCompleated = $"{check} Użytkownik {Customer.Mention} pomyślnie kupił **{item}** za {price} {coin}";
            return PurchaseCompleated;
        }

        public static string ShopEconomyWarnsError(IUser user, uint warns)
        {
            string EconomyWarnsError = $"{wrong} {user.Mention}, nie możesz kupić **UNWARN** ponieważ posiadasz **0** ostrzeżeń!";
            return EconomyWarnsError;
        }

        //Cashmashine
        public static string BankQuestionWithdraw = $"📥 Ile pieniędzy chciałbyś **wypłacić** z konta?";

        public static string BankQuestionDeposit = $"📤 Ile pieniędzy chciałbyś **wpłacić** na konto?";

        public static string BankErrorOutOfTime = $"{wrong} Sesja wygasła.";

        public static string BankErrorInsuficientFoundsWithdraw = $"{wrong} Nie posiadasz wystarczających środków na koncie.";

        public static string BankErrorInsuficientFoundsDeposit = $"{wrong} Nie posiadasz wystarczających środków w portfelu.";

        public static string BankErrorNoLetters = $"{wrong} Wpisz tylko cyfry, bez spacji i innych znaków.";

        public static string BankSuccessWithdraw(ulong ammount)
        {
            string BankSuccessWithdraw = $"**{check} Pomyślnie wypłacono {ammount} {coin} z konta.**";
            return BankSuccessWithdraw;
        }

        public static string BankSuccessDeposit(ulong ammount)
        {
            string BankSuccessDeposit = $"**{check} Pomyślnie wpłacono {ammount} {coin} na konto.**";
            return BankSuccessDeposit;
        }

        public static string BankDailyError(IUser user, string timeSpanString)
        {
            string EconomyDailyError = $"{wrong} {user.Mention}, kolejną dawkę pieniędzy możesz odebrać za **{timeSpanString}**.";
            return EconomyDailyError;
        }

        public static string BankDailySuccess(IUser user)
        {
            string BankDailySuccess = $"{check} {user.Mention}, właśnie odebrałeś swoją dzienną nagrodę. Przelano **250** {coin} na twoje konto.";
            return BankDailySuccess;
        }

        public static string BankUserBalance(IUser user, string account, string wallet)
        {
            string BankUserBalance = $"💳 Na koncie posiadasz: **{account}** {coin}\n👛 W portfelu posiadasz: **{wallet}** {coin}";
            return BankUserBalance;
        }

        //Welcome msg
        public static string WelcomeMessage(string guild, string user)
        {
            string WelcomeMessage = $"Witaj {user} na serwerze {guild}! Mamy nadzieje że będziesz się tu dobrze bawił/a :smile:";
            return WelcomeMessage;
        }
        //Help answers
        public static string HelpMoney = $":moneybag: Jak zarabiać pieniądze?\n";
        public static string HelpOffend = $":zipper_mouth: Co zrobić jeśli ktoś mnie obraża?\n";
        public static string HelpCandidate = $":hand_splayed: Jak kandydować do administracji?\n";
        public static string HelpIdea = $":bulb: Mam pomysł na serwer gdzie to napisać?\n";
        public static string HelpPartner = $":star2: Chciał bym zostać partnerem? Jakie wymogi muszę spełniać?\n";
        public static string HelpInvite = $":incoming_envelope: W jaki sposób mogę zaprosić moich znajomych?\n";
        public static string HelpCommands = $":scroll: Gdzie znajdę listę komend?\n";
        public static string HelpVIP = $"<:supervip:462351820501549066> Wszystko o randze <@&517063123690061834>\n";
        public static string HelpSVIP = $"<:ultravip:462351820308873246> Wszystko o randze <@&517063059659817000>\n";
        public static string HelpSponsor = $"<:sponsor:462351820006883340> Wszystko o randze <@&517062733699612684>\n";
        public static string HelpAki = $":ghost: Mogę popisać z akinatorem?\n";
        public static string HelpMusic = $":musical_note: Mogę posłuchać muzyki?\n";
        public static string HelpYT = $"<:blob_youtube:460770184689352705> Wszystko o rangach <@&517063084368723991> <@&517062956022890517> <@&517063026273157120>\n";
        public static string HelpOther = $"​:helmet_with_cross: Potrzebuje innej pomocy. Mam sprawę do administracji.\n";
    }
}