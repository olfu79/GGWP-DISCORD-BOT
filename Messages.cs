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
        public static string vip = "<:vip:560937493176909827>";
        public static string svip = "<:svip:560937492451426325>";
        public static string sponsor = "<:sponsor:560937492551827483>";
        public static string ban = "<:ban:560931842094530582>";

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

        public static string BankDailySuccess(IUser user, uint ammount)
        {
            string BankDailySuccess = $"{check} {user.Mention}, właśnie odebrałeś swoją dzienną nagrodę. Przelano **{ammount}** {coin} na twoje konto.";
            return BankDailySuccess;
        }

        public static string BankUserBalance(IUser user, string account, string wallet)
        {
            string BankUserBalance = $"💳 Na koncie posiadasz: **{account}** {coin}\n👛 W portfelu posiadasz: **{wallet}** {coin}";
            return BankUserBalance;
        }

        public static string WelcomeMessage(string guild, string user)
        {
            string WelcomeMessage = $"Witaj {user} na serwerze {guild}! Mamy nadzieje że będziesz się tu dobrze bawił/a :smile:";
            return WelcomeMessage;
        }

        public static Embed GenerateCommandsCategoriesEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("DOSTĘPNE KATEGORIE");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField(
                "👤 GRACZ\n" +
                "🎳 ZABAWA\n" +
                "💰 EKONOMIA\n" +
                "⛅ POGODA\n" +
                "🎵 MUZYKA\n" +
                "👻 AKINATOR\n", "​Wpisz !komendy <kategoria>");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        public static Embed GenerateCommandsGraczEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("LISTA KOMEND");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField("GRACZ", 
                "**Komenda**: `podanie <tekst>`\n**Opis**: jeśli jest rekrutacja, możesz wysłać swoje podanie w wiadomości prywatnej.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `propozycja <tekst>`\n**Opis**: możesz zaproponować zmiany na serwerze. Po napisaniu w wiadomości prywatnej, propozycja zostanie przekierowana do administracji i będzie oczekiwać na zatwierdzenie.\n**Aliasy**: `proponuj`\n\n" +
                "**Komenda**: `link`\n**Opis**: Uzyskaj zaproszenie na ten serwer. Możesz je później wysłać znajomym itp.\n**Aliasy**: `zaproszenie`, `zapro`, `invite`, `inv`\n\n" +
                "**Komenda**: `cytat <osoba> <tekst>`\n**Opis**: cytuje dowolną osobę.\n**Aliasy**: `cytuj`\n\n" +
                "**Komenda**: `pomoc`\n**Opis**: wyświetla pomoc.\n**Aliasy**: `help`\n\n" +
                "**Komenda**: `kalkulator <liczba 1> <operator> <liczba 2>`\n**Opis**: Poprostu kalkulator :)\n**Aliasy**: `kalk`, `calc`, `oblicz`, `przelicz`, `policz`\n\n");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        public static Embed GenerateCommandsFunEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("LISTA KOMEND");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField("ZABAWA",
                "**Komenda**: `8ball <pytanie>`\n**Opis**: magiczna kula, odpowie na twoje pytanie.\n**Aliasy**: `8 ball`, `8b`\n\n" +
                "**Komenda**: `kostka`\n**Opis**:  losuje liczbe od 1 do 6\n**Aliasy**: `kosc`, `kosci`, `kość`, `kości`\n\n" +
                "**Komenda**: `moneta`\n**Opis**: podrzuca monetą.\n**Aliasy**: `orzelreszka`, `orzel reszka`, `orzeł reszka`, `orzełreszka`, `coinflip`, `coin flip`, `flip coin`, `flipcoin`\n\n" +
                "**Komenda**: `emojify <tekst>`\n**Opis**: zamienia tekst na emoji.\n**Aliasy**: `emoji`\n\n" +
                "**Komenda**: `wyjdz <osoba>`\n**Opis**: każe wyjść danej osobie.\n**Aliasy**: `drzwi`, `wyjdź`, `door`, `doors`\n\n" +
                "**Komenda**: `reverse <tekst>`\n**Opis**:  zamienia tekst tak by był od tyłu.\n**Aliasy**: `odwróć`, `odwroc`, `odwroctekst`, `odwróćtekst`\n\n" +
                "**Komenda**: `iq <osoba>`\n**Opis**: podaje IQ danej osoby.\n**Aliasy**: `brak`");
            eb.AddField("​",
                "**Komenda**: `banan <osoba>`\n**Opis**: podaje długość banana danej osoby.\n**Aliasy**: `bananek`, `cm`\n\n" +
                "**Komenda**: `ocena <rzecz/przedmiot>`\n**Opis**: ocenia cokolwiek wpiszesz na ilość gwiazdek od 1 do 10\n**Aliasy**: `oceń`, `rate`, `ocen`\n\n" +
                "**Komenda**: `szip <osoba 1> <osoba 2>`\n**Opis**: szipuje ze sobą dwie osoby.\n**Aliasy**: `ship`, `szipuj`\n\n" +
                "**Komenda**: `pocisk <osoba>`\n**Opis**: disuje daną osobę w twoim imieniu\n**Aliasy**: `pocisnij`, `pociśnij`, `diss`, `dis`, `disuj`\n\n" +
                "**Komenda**: `ping`\n**Opis**: pinguje.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `wybierz <wybór1 | wybór2 | wybór 3 | itd...>`\n**Opis**: wybiera jedną z danych opcji.\n**Aliasy**: `choose`, `wybór`, `wybor`\n\n" +
                "**Komenda**: `kill <osoba>`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `zabij`, `murder`");
            eb.AddField("​",
                "**Komenda**: `facepalm`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `fp`\n\n" +
                "**Komenda**: `sleep`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `spać`, `spac`, `spij`, `śpij`, `spanie`, `spanko`\n\n" +
                "**Komenda**: `hej <gracz>`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `hi`, `cześć`, `czesc`, `elo`, `siema`, `siemka`, `yo`, `hay`\n\n" +
                "**Komenda**: `uderz <gracz>`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `hit`, `walnij`, `punch`\n\n" +
                "**Komenda**: `przytul <osoba>`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `hug`, `przytulas`\n\n" +
                "**Komenda**: `kopnij`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `kick`, `kop`\n\n" +
                "**Komenda**: `całus`\n**Opis**: wysyła śmieszny obrazek.\n**Aliasy**: `calus`, `kiss`, `pocałuj`, `pocaluj`, `cmok`\n\n");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        public static Embed GenerateCommandsMoneyEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("LISTA KOMEND");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField("PIENIĄDZE",
                "**Komenda**: `stankonta`\n**Opis**: Wyświetla informacje instruującą gdzie sprawdzić swój stan konta.\n**Aliasy**: `stan konta`, `kasa`, `money`, `pieniądze`, `pieniadze`\n\n" +
                "**Komenda**: `praca`\n**Opis**: Pozwala pracować i zarabiać pieniądze.\n**Aliasy**: `pracuj`, `job`\n\n" +
                "**Komenda**: `daily`\n**Opis**: Wyświetla informacje instruującą gdzie odebrać codzienną nagrodę.\n**Aliasy**: `dzienna`, `free`\n\n" +
                "**Komenda**: `przelew <osoba> <kwota>`\n**Opis**: Przelej daną kwotę pieniędzy danej osobie.\n**Aliasy**: `przelej`, `przekaż`, `plac`, `płać`, `pay`\n\n");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        public static Embed GenerateCommandsWeatherEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("LISTA KOMEND");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField("POGODA",
                "**Komenda**: `pogoda <miasto>`\n**Opis**: Wyświetla pogodę dla danego miasta.\n**Aliasy**: `weather`\n\n");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        public static Embed GenerateCommandsMusicEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("LISTA KOMEND");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField("MUZYKA (Dostępne po odblokowaniu \"dostępu do muzyki\" w sklepie.)",
                "**Komenda**: `play <nazwa utworu>`\n**Opis**: Puszcza dany utwór.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `skip`\n**Opis**: Przechodzi do następnego utworu.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `np`\n**Opis**: Wyświetla nazwe aktualne granego utworu.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `pause`\n**Opis**: Pauzuje aktualnie grany utwór.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `resume`\n**Opis**: Wznawia zpauzowany utwór.\n**Aliasy**: `brak`\n\n");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        public static Embed GenerateCommandsAkinatorEmbed()
        {
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("LISTA KOMEND");
            eb.Author.WithIconUrl("https://cdn3.iconfinder.com/data/icons/mobile-apps-settings-ii-flat-multicolor-background/2048/458_-_Language__input-512.png");
            eb.AddField("AKINATOR (Dostępne po odblokowaniu \"dostępu do akinatora\" w sklepie.)",
                "**Komenda**: `start`\n**Opis**: Rozpoczyna zabawę.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `stop`\n**Opis**: Zatrzymuje zabawę.\n**Aliasy**: `brak`\n\n" +
                "**Komenda**: `lang pl`\n**Opis**: Ustawia język na polski.\n**Aliasy**: `brak`\n\n");
            eb.WithColor(new Color(0, 129, 140));
            return eb.Build();
        }

        //Help answers
        public static string HelpChannel = $"<#521726999648010280>";
        public static string HelpMoney = $"**:moneybag: Jak zarabiać pieniądze?**\nZarabiać można na kilka sposobów:\n- Pisząc na czacie zdobywasz poziomy a wraz z nimi pieniądze.\n- Odbierając dzienne nagrody na kanale <#545278785625522194>\n- Grając w kasynie (Ruletka, Sloty, Coinflip\n- Wygrywając je na różnych konkursach i eventach)";
        public static string HelpOffend = $"**:zipper_mouth: Co zrobić jeśli ktoś mnie obraża?**\nJeśli ktoś Cię obraża bądź publikuje niestosowne treści poinformuj o tym administacje dodając emoji {ban} do jego wiadomości. Reakcja natychmiast zniknie więc nikt się nie dowie kto zgłosił daną wiadomość.";
        public static string HelpCandidate = $"**:hand_splayed: Jak kandydować do administracji?**\nJeśli chcesz kandydować do administracji musisz poczekać na **REKRUTACJE**. Wtedy piszesz podanie w wiadomości prywatnej bota komendą `!podanie [tekst]` i oczekujesz wyników :)";
        public static string HelpIdea = $"**:bulb: Mam pomysł na serwer gdzie to napisać?**\n Użyj komendy `!propozycja [tekst]` - Twoja propozycja zostanie przesłana do administracji, jeśli zostanie zatwierdzona, gracze będą mogli nad nią głosować.";
        public static string HelpPartner = $"**:star2: Chciał bym zostać partnerem? Jakie wymogi muszę spełniać?**\n Żeby zostać naszym partnerem, trzeba spełniać kilka wymogów:\n- Twój serwer musi mieć podobną tematkę\n- Liczba osób na Twoim serwerz musi być przynajmniej połową liczby osób z tego serwera.\n- Twój serwer musi posiadać specjalny kanał, na którym ten serwer zostanie zareklamowany.\n**Jeśli spełniasz powyższe warunki i chcesz nawiązać partnerstwo, napisz do <@&517061559105748993> lub <@&517061604928520202>**";
        public static string HelpInvite = $"**:incoming_envelope: W jaki sposób mogę zaprosić moich znajomych?**\nUżyj komendy `!link` lub `!zaproszenie` by otrzymać link z zaproszeniem w wiadomości prywatnej. Następnie go przekopiuj i podaj znajomemu :)";
        public static string HelpCommands = $"**:scroll: Gdzie znajdę listę komend?**\n Listę komend znajdziesz pod komendą: `!komendy`";
        public static string HelpVIP = $"**{vip} Wszystko o randze <@&517063123690061834>**\n**KUPNO:**\n- Możesz ją kupić w <#545279215025651735> za 5000{coin}\n**Przywileje:**\n- Złoty nick na czacie\n- Darmowa zmiana pseudonimu.\n- Zarobki z daily x2\n- Jego linki są embedowane.\n- Może używać zewnętrznych emoji.";
        public static string HelpSVIP = $"**{svip} Wszystko o randze <@&517063059659817000>**\n**KUPNO:**\n- Możesz ją kupić w <#545279215025651735> za 10000{coin}\n**Przywileje:**\n- Złoty nick na czacie\n- Darmowa zmiana pseudonimu.\n- Zarobki z daily x3\n- Może wysyłać pliki (w tym obrazki) a jego linki są embedowane.\n- Może wysyłać wiadomości TTS\n- Może używać zewnętrznych emoji.";
        public static string HelpSponsor = $"**{sponsor} Wszystko o randze <@&517062733699612684>**\n**KUPNO:**\n- Możesz ją kupić w sklepie internetowym za 10zł (wpisz `donate`)\n**Przywileje:**\n- Żółty nick na czacie\n- Darmowa zmiana pseudonimu.\n- Zarobki z daily x5\n- Może wysyłać pliki (w tym obrazki) a jego linki są embedowane.\n- Może wysyłać wiadomości TTS\n- Może używać zewnętrznych emoji.\n- Może oznaczać wszystkich\n- Posiada \"Priorytet Mówienia\" dzięki czemu gdy on mówi - wszyscy go słuchają ;)";
        public static string HelpAki = $"**:ghost: Mogę popisać z akinatorem?**\nTak! Jedyne czego potrzebujesz to rola **DOSTĘP DO AKINATORA**, którą możesz kupić w <#545279215025651735>";
        public static string HelpMusic = $"**:musical_note: Mogę posłuchać muzyki?**\nTak! Jedyne czego potrzebujesz to rola **DOSTĘP DO MUZYKI**, którą możesz kupić w <#545279215025651735>";
        public static string HelpYT = $"**<:blob_youtube:460770184689352705> Wszystko o rangach <@&517063084368723991> <@&517062956022890517> <@&517063026273157120>**\n<@&517063084368723991> - Minimum 300 subskrypcji. Przywileje: Te same co <@&517063123690061834>\n<@&517062956022890517> - Minimum 1000 subskrypcji. Przywileje: Te same co <@&517063059659817000>\n<@&517063026273157120> - Minimum 50 obserwujących. Przywileje: Te same co <@&517063059659817000>";
        public static string HelpOther = $"**​:helmet_with_cross: Potrzebuje innej pomocy. Mam sprawę do administracji.**\nZostał dla Ciebie utworzony specjalny kanał pomocy. Przejdź do niego, tam znajdziesz kolejne instrukcje.";
    }
}