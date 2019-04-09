using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;

using ggwp.Core;
using ggwp.Services.Cooldown;
using ggwp.Core.GuildAccounts;
using System.Linq;
using ggwp.Core.UserAccounts;

namespace ggwp.Modules
{
    public class User : ModuleBase<SocketCommandContext>
    {
        [Cooldown(60)]
        [Command("podanie")]
        public async Task Application([Remainder] string podanie)
        {
            var client = Context.Client as DiscordSocketClient;
            var guild = client.GetGuild(448884032391086090);
            var GuildAccount = GuildAccounts.GetAccount(guild);

            if (GuildAccount.Rekrutacja == false)
                await ReplyAsync($"{Messages.wrong} Aktualnie nie trwa rekrutacja.");
            else
            {
                try
                {
                    var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
                    var admChannel = guild.GetChannel(GuildAccount.AdmChannelID) as ITextChannel;
                    var nie = Emote.Parse(Messages.wrong);
                    var tak = Emote.Parse(Messages.check);

                    if (Context.Channel is IPrivateChannel)
                    {
                        EmbedBuilder eb = new EmbedBuilder();
                        eb.WithAuthor(Context.User.Username);
                        eb.Author.WithIconUrl(Context.User.GetAvatarUrl());
                        eb.WithTitle("Podanie");
                        eb.WithDescription(podanie);
                        eb.WithColor(Color.Blue);
                        eb.WithCurrentTimestamp();
                        var msg = await admChannel.SendMessageAsync("", false, eb.Build());
                        await msg.AddReactionAsync(tak);
                        await msg.AddReactionAsync(nie);
                        await dmChannel.SendMessageAsync($"{Messages.check} Podanie zostało dostarczone do administracji. Jeśli uda Ci się przejść do kolejnego etapu ktoś z administracji Cię poinformuje.");
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync("Napisz swoje podanie pod komendą `!podanie [treść]` w wiadomości prywatnej do bota.\n**Nie pisz podań do członków administracji!**");
                        await dmChannel.SendMessageAsync("`!podanie [treść]` aby napisać podanie :)");
                    }
                }
                catch
                {
                    await ReplyAsync(Messages.UnknownError);
                }
            }
        }

        [Cooldown(30)]
        [Command("propozycja")]
        [Alias("proponuj")]
        public async Task Suggestion([Remainder] string propozycja)
        {
            try
            {
                var client = Context.Client as DiscordSocketClient;
                var guild = client.GetGuild(448884032391086090);
                var GuildAccount = GuildAccounts.GetAccount(guild);

                var dmChannel = await Context.User.GetOrCreateDMChannelAsync();
                var sugChannel = guild.GetChannel(GuildAccount.SuggestionsChannelID) as ITextChannel;
                var admChannel = guild.GetChannel(GuildAccount.AdmChannelID) as ITextChannel;

                var nie = Emote.Parse(Messages.wrong);
                var ok = new Emoji("🆗");

                if (Context.Channel is IPrivateChannel)
                {
                    //Building and sending message
                    EmbedBuilder eb = new EmbedBuilder();
                    eb.WithAuthor(Context.User.Username);
                    eb.Author.WithIconUrl(Context.User.GetAvatarUrl());
                    eb.WithTitle("Propozycja");
                    eb.WithDescription(propozycja);
                    eb.WithColor(Color.Green);
                    eb.WithCurrentTimestamp();
                    var msg = await admChannel.SendMessageAsync("", false, eb.Build());
                    await msg.AddReactionAsync(nie);
                    await msg.AddReactionAsync(ok);
                    //Response
                    await dmChannel.SendMessageAsync($"{Messages.check} Propozycja została wysłana pomyślnie.");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{Messages.wrong}Swoją propozycję napisz w wiadomości prywatnej.");
                    await dmChannel.SendMessageAsync("`!propozycja [treść]` aby napisać propozycje :)");
                }
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }
        }

        [Cooldown(20)]
        [Command("link")]
        [Alias("zaproszenie", "zapro", "invite", "inv")]
        public async Task Invitation()
        {
            try
            {
                var client = Context.Client as DiscordSocketClient;
                var guild = client.GetGuild(448884032391086090);
                var GuildAccount = GuildAccounts.GetAccount(guild);

                var dmChannel = await Context.User.GetOrCreateDMChannelAsync();

                if (Context.Channel is IPrivateChannel)
                {
                    await dmChannel.SendMessageAsync($"🔗 Proszę, oto link do naszego serwera 🔗\n{GuildAccount.InviteLink}");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"{Messages.check} {Context.User.Mention}, wysłano link w wiadomości prywatnej.");
                    await dmChannel.SendMessageAsync($"🔗 Proszę, oto link do naszego serwera 🔗\n{GuildAccount.InviteLink}");
                }
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }
        }

        [Cooldown(2)]
        [Command("cytat")]
        [Alias("cytuj")]
        public async Task Cytat(IUser user, [Remainder]string cytat)
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await Context.Message.DeleteAsync();

            if (cytat == "")
            {
                await ReplyAsync($"{Messages.wrong} {Context.User.Mention}, musisz wpisać tekst!");
                return;
            }

            await ReplyAsync($"{Context.User.Mention} cytuje użytkownika {user.Mention}\n*{cytat}*");
        }

        [Cooldown(5)]
        [Command("pomoc")]
        [Alias("help")]
        public async Task Help()
        {
            await Context.Message.DeleteAsync();

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("POMOC");
            eb.Author.WithIconUrl("https://cdn2.iconfinder.com/data/icons/flat-style-svg-icons-part-1/512/confirmation_verification-512.png");
            eb.WithDescription($"📜 Lista komend dostępna pod `!komendy`\n❔ Częste pytania i kontakt z administracją na kanale {Messages.HelpChannel}");
            eb.WithColor(new Color(7, 116, 180));
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(5)]
        [Command("akomendy")]
        [Alias("acommands", "a komendy", "a commands")]
        [RequireUserPermission(GuildPermission.ManageNicknames)]
        public async Task AdminCommands(string option = null)
        {
            if (Context.Channel is IPrivateChannel)
                return;

            var dmChannel = Context.Channel;

            await Context.Message.DeleteAsync();

            if (option is null)
                await dmChannel.SendMessageAsync("", false, Messages.GenerateAdminCommandsCategoriesEmbed());
            else if (option.ToLower() == "pomocnik")
                await dmChannel.SendMessageAsync("", false, Messages.GenerateAdminCommandsPomocnikEmbed());
            else if (option.ToLower() == "pomocnik+")
                await dmChannel.SendMessageAsync("", false, Messages.GenerateAdminCommandsPomocnikPlusEmbed());
            else if (option.ToLower() == "moderator")
                await dmChannel.SendMessageAsync("", false, Messages.GenerateAdminCommandsModEmbed());
            else if (option.ToLower() == "admin")
                await dmChannel.SendMessageAsync("", false, Messages.GenerateAdminCommandsAdminEmbed());
            else if (option.ToLower() == "reakcje")
                await dmChannel.SendMessageAsync("", false, Messages.GenerateAdminCommandsReactionsEmbed());
            else
            {
                await ReplyAsync($"{Messages.wrong} {Context.User.Mention} Nie ma takiej kategorii!");
                return;
            }
        }

        [Cooldown(5)]
        [Command("komendy")]
        [Alias("commands")]
        public async Task Commands(string option = null)
        {
            var dmChannel = await Context.User.GetOrCreateDMChannelAsync();

            if (Context.Channel is IPrivateChannel)
            {
                if (option is null)
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsCategoriesEmbed());
                else if (option.ToLower() == "gracz")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsGraczEmbed());
                else if (option.ToLower() == "zabawa" || option.ToLower() == "fun")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsFunEmbed());
                else if (option.ToLower() == "ekonomia" || option.ToLower() == "kasa")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMoneyEmbed());
                else if (option.ToLower() == "pogoda")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsWeatherEmbed());
                else if (option.ToLower() == "muzyka")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMusicEmbed());
                else if (option.ToLower() == "akinator" || option.ToLower() == "aki")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsAkinatorEmbed());
                else
                {
                    await ReplyAsync($"{Messages.wrong} {Context.User.Mention} Nie ma takiej kategorii!");
                    return;
                }
            }
            else
            {
                await Context.Message.DeleteAsync();

                if (option is null)
                    await Context.Channel.SendMessageAsync("", false, Messages.GenerateCommandsCategoriesEmbed());
                else if (option.ToLower() == "gracz")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsGraczEmbed());
                else if (option.ToLower() == "zabawa" || option.ToLower() == "fun")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsFunEmbed());
                else if (option.ToLower() == "ekonomia" || option.ToLower() == "kasa")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMoneyEmbed());
                else if (option.ToLower() == "pogoda")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsWeatherEmbed());
                else if (option.ToLower() == "muzyka")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsMusicEmbed());
                else if (option.ToLower() == "akinator" || option.ToLower() == "aki")
                    await dmChannel.SendMessageAsync("", false, Messages.GenerateCommandsAkinatorEmbed());
                else
                {
                    await ReplyAsync($"{Messages.wrong} {Context.User.Mention} Nie ma takiej kategorii!");
                    return;
                }

                var msg = await ReplyAsync($"{Messages.check} {Context.User.Mention} Wysłano listę komend w wiadomości prywatnej.");
                await Helpers.RemoveMessage(msg);
            }
        }

        [Command("praca")]
        [Alias("pracuj", "job")]
        public async Task Job()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await Context.Message.DeleteAsync();

            string GoodEvent;
            string BadEvent;
            const int OrderValue = 20;
            int award = 0;

            string[] jobs = { "doradzca finansowy", "projektant", "bankier", "fryzjer", "policjant", "strażak", "złodziej", "listonosz", "grabarz", "kasjer", "kucharz", "kelner", "lekarz", "informatyk", "ochroniarz", "prawnik", "taksówkarz", "mechanik", "diler narkotyków", "nauczyciel", "ksiądz", "dziennikarz", "kierowca tira", "pilot samolotu", "prostytutka", "tancerz", "wokalista", "żołnierz", "trener", "tatuażysta", "kurier" };

            Random rand = new Random();

            string RandomJob = jobs[rand.Next(jobs.Length)];
            int NumberOfOrders = rand.Next(1, 15);
            int IsAdditionalEvent = rand.Next(0,2);
            int AdditionaEventAward = rand.Next(5, 30);

            award += NumberOfOrders * OrderValue;

            if (RandomJob == "doradzca finansowy")
            {
                GoodEvent = "Dzięki współpracy z bankiem zarobiłeś dodatkowe pieniądze.";
                BadEvent = "Klinet był niezadowolony z wizyty.";
            }
            else if (RandomJob == "projektant")
            {
                GoodEvent = "Klientom spodobały się twoje innowacyjne pomysły.";
                BadEvent = "Wylałeś kawę na plany.";
            }
            else if (RandomJob == "bankier")
            {
                GoodEvent = "Dostałeś premię za nadgodziny.";
                BadEvent = "Nie miły klient złożył na Ciebie doniesienie.";
            }
            else if (RandomJob == "fryzjer")
            {
                GoodEvent = "Klinet miał dobry dzień i dał spory napiwek.";
                BadEvent = "Klientowi nie spodobała się fryzura.";
            }
            else if (RandomJob == "policjant")
            {
                GoodEvent = "Za szybkie złapanie złodzieja dostałeś premię.";
                BadEvent = "Zostałeś pobity i okradziony.";
            }
            else if (RandomJob == "strażak")
            {
                GoodEvent = "Podczas gaszenia starej stodoły znalazłeś na ziemi złoty naszyjnik.";
                BadEvent = "Ogień spalił Twoje ubrania.";
            }
            else if (RandomJob == "złodziej")
            {
                GoodEvent = "W portfelu który okradłeś był plik banknotów.";
                BadEvent = "Zostałeś przyłapany przez starszą panią.";
            }
            else if (RandomJob == "listonosz")
            {
                GoodEvent = "Szybko rozniosłeś listy i dostałeś premię.";
                BadEvent = "Zgubiłeś cenny list i musisz pokryć jego koszty.";
            }
            else if (RandomJob == "grabarz")
            {
                GoodEvent = "Otrzymałeś dodatkową zapłatę od rodziny zmarłego.";
                BadEvent = "Przypadkowo przebiłeś trumnę, musisz pokryć koszta naprawy.";
            }
            else if (RandomJob == "kasjer")
            {
                GoodEvent = "Bogaty człowiek zapłacił banknotem 200zł i powiedział, że reszty nie trzeba.";
                BadEvent = "Z kasy znikło kilka banknotów, musisz ponieść konsekwencje.";
            }
            else if (RandomJob == "kucharz")
            {
                GoodEvent = "Zostałeś uznany przez krytyka kulinarnego, dostajesz premię.";
                BadEvent = "W zupie był włos. Musisz zwrócić koszty posiłku.";
            }
            else if (RandomJob == "kelner")
            {
                GoodEvent = "Dostałeś spory napiwek.";
                BadEvent = "Byłeś nie miły i szef uciął Ci pensje.";
            }
            else if (RandomJob == "lekarz")
            {
                GoodEvent = "Dostałeś premię za przeprowadzoną operacje.";
                BadEvent = "Nie udało Ci się uratować człowieka. Zostało Ci potrącone z pensji.";
            }
            else if (RandomJob == "informatyk")
            {
                GoodEvent = "Sprzedałeś swój program za duże pieniądze.";
                BadEvent = "Twój projekt ma opóźnienia. Musisz zapłacić za wydłużenie terminu.";
            }
            else if (RandomJob == "ochroniarz")
            {
                GoodEvent = "Dostałeś łapówkę.";
                BadEvent = "Zostałeś brutalnie pobity.";
            }
            else if (RandomJob == "prawnik")
            {
                GoodEvent = "Twój klient za obronienia go przed sądem dał Ci premię.";
                BadEvent = "Zgubiłeś ważne dokumenty.";
            }
            else if (RandomJob == "taksówkarz")
            {
                GoodEvent = "Dostałeś napiwek.";
                BadEvent = "Klienci ubrudzili Twoją taksówkę.";
            }
            else if (RandomJob == "mechanik")
            {
                GoodEvent = "Pomyślnie przeprowadziłeś naprawę silnika i dostałeś premię.";
                BadEvent = "Musiałeś domówić daną część mechaniczną. Jej koszty przesyłki z zagranicy są spore.";
            }
            else if (RandomJob == "diler narkotyków")
            {
                GoodEvent = "Sprzedałeś narkoryki z dużym zyskiem.s";
                BadEvent = "Klient wisi Ci z hajsem, szef się zdenerwował.";
            }
            else if (RandomJob == "nauczyciel")
            {
                GoodEvent = "Za zajęcia wyrównawcze dostałeś dodatkowe pieniądze.";
                BadEvent = "Gdy dyrektor dowiedział się, że bijesz uczniów, obciął Twoją pensję.";
            }
            else if (RandomJob == "ksiądz")
            {
                GoodEvent = "Dostałeś sporo pieniędzy na tace.";
                BadEvent = "Nie dostałeś nic na tacę, ponieważ prowadziłeś mszę dla dzieci.";
            }
            else if (RandomJob == "dziennikarz")
            {
                GoodEvent = "Dostałeś premię za przeprowadzony wywiad.";
                BadEvent = "Zaliczyłeś wpadkę \"na żywo\".";
            }
            else if (RandomJob == "kierowca tira")
            {
                GoodEvent = "Szybko dostarczyłeś towar i dostajesz premię.";
                BadEvent = "Prawie spowodowałeś wypadek.";
            }
            else if (RandomJob == "pilot samolotu")
            {
                GoodEvent = "Podróż była bardzo spokojna. Dostajesz premię.";
                BadEvent = "Prawie rozbiłeś samolot.";
            }
            else if (RandomJob == "prostytutka")
            {
                GoodEvent = "Klient był zadowolony z usług. Dostajesz premię.";
                BadEvent = "Klient był rozczarowany i zapłacił mniej.";
            }
            else if (RandomJob == "tancerz")
            {
                GoodEvent = "Twój występ bardzo się spodobał, dostałeś wiele cennych rzeczy na scenie.";
                BadEvent = "Ludziom się nie spodobał Twój występ, rządajązwrotu pieniędzy.";
            }
            else if (RandomJob == "wokalista")
            {
                GoodEvent = "Twój występ bardzo się spodobał, dostałeś wiele cennych rzeczy na scenie.";
                BadEvent = "Ludziom się nie spodobał Twój występ, rządajązwrotu pieniędzy.";
            }
            else if (RandomJob == "żołnierz")
            {
                GoodEvent = "Zabiłeś wrogiego snajpera, otrzymujesz premię.";
                BadEvent = "Zgubiłeś swoją broń, musisz kupić nową.";
            }
            else if (RandomJob == "trener")
            {
                GoodEvent = "Twoja drużna zwyciężyła ligę.";
                BadEvent = "Twoja drużyna spadła na ostanie miejsce w lidze.";
            }
            else if (RandomJob == "tatuażysta")
            {
                GoodEvent = "Dostałeś dodatkową kasę za fajny tatuaż.";
                BadEvent = "Popsułeś tatuaż, klient jest niezadowolony.";
            }
            else if (RandomJob == "kurier")
            {
                GoodEvent = "Dostałeś premię za szybką dostawę.";
                BadEvent = "Zgubiłeś paczkę i musisz ponieść jej koszta.";
            }
            else
            {
                GoodEvent = "Błąd.";
                BadEvent = "Błąd.";
            }

            var result = Services.Job.GetOrder((SocketGuildUser)Context.User, (uint)award);
            if (result.Success)
            {
                if (IsAdditionalEvent == 0)
                {
                    award += AdditionaEventAward;
                    var msg = await Context.Channel.SendMessageAsync($"Wykonałeś **{NumberOfOrders}** zleceń.\n```diff\nPoszedłeś pracować jako {RandomJob}\n+ Na wykonywaniu pracy zarobiłeś: {OrderValue * NumberOfOrders}$C\n\nDodatkowe eventy:\n+ {GoodEvent}```**Zarobione pieniądze:** {award}{Messages.coin}");
                    await Helpers.RemoveMessage(msg, 6);
                }
                else if (IsAdditionalEvent == 1)
                {
                    award -= AdditionaEventAward;
                    var msg = await Context.Channel.SendMessageAsync($"Wykonałeś **{NumberOfOrders}** zleceń.\n```diff\nPoszedłeś pracować jako {RandomJob}\n+ Na wykonywaniu pracy zarobiłeś: {OrderValue * NumberOfOrders}$C\n\nDodatkowe eventy:\n- {BadEvent}```**Zarobione pieniądze:** {award}{Messages.coin}");
                    await Helpers.RemoveMessage(msg, 6);
                }
                else
                {
                    var msg = await Context.Channel.SendMessageAsync($"Wykonałeś **{NumberOfOrders}** zleceń.\n```diff\nPoszedłeś pracować jako {RandomJob}\n+ Na wykonywaniu pracy zarobiłeś: {OrderValue * NumberOfOrders}$C```**Zarobione pieniądze:** {award}{Messages.coin}");
                    await Helpers.RemoveMessage(msg, 6);
                }
                var UserAccount = UserAccounts.GetAccount(Context.User);
                UserAccount.MoneyAccount += (uint)award;
            }
            else
            {
                string timeSpanString = string.Format("{0:%h} godzin {0:%m} minut {0:%s} sekund", result.RefreshTimeSpan);
                var msg = await Context.Channel.SendMessageAsync($"{Messages.wrong} {Context.User.Mention}, kolejną pracę możesz wykonać za **{timeSpanString}**.");
                await Helpers.RemoveMessage(msg, 6);
            }
        }

        [Command("temat")]
        [Alias("losujtemat", "losuj temat")]
        public async Task Topic()
        {
            if (Context.Channel is IPrivateChannel)
                return;

            await Context.Message.DeleteAsync();

            string[] questions = 
                {
                    "Jaki był ostatni zabawny film, który widziałeś?",
                    "Co robisz, aby pozbyć się stresu?",
                    "Kto jest twoim ulubionym artystą estradowym (komik, muzyk, aktor itp.)?",
                    "Jaki jest Twój ulubiony sposób na spędzanie czasu?",
                    "Masz jakieś zwięrzęta domowe? Jak się nazywają?",
                    "Gdzie poszedłeś/poszłaś w zeszły weekend? Co zrobiłeś/aś?",
                    "Co zamierzasz robić w ten weekend?",
                    "Co robiłeś na ostatnich wakacjach?",
                    "Czy jesteś bardzo aktywny, czy wolisz odpoczywać w wolnym czasie?",
                    "Co robisz, gdy spotykasz się ze znajomymi?",
                    "Kim jest twój najstarszy przyjaciel? Gdzie go spotkałeś?",
                    "Jaka jest najlepsza / najgorsza rzecz w twojej pracy / szkole?",
                    "Gdybyś miał wybrać obojętnie jaką piosenkę, jaka byłaby to piosenka? Czemu?",
                    "Co tak naprawdę robiłeś, kiedy byłeś dzieckiem?",
                    "Gdybyś mógł wybrać jakiekolwiek zwierze do życia z tobą, jakie zwierzę wybrałbyś?",
                    "Jakie trzy słowa najlepiej Cię opisują?",
                    "Jak wyglądałby twój idealny weekend?",
                    "Co myślisz o tatuażach? Czy masz jakieś?",
                    "Jaki jest twój ulubiony numer? Czemu?",
                    "Czy kiedykolwiek uratowałeś życie zwierzęciu? A co z życiem człowieka?",
                    "Czy jesteś bardzo zorganizowaną osobą?",
                    "Czy rozmawiałeś kiedyś z naprawdę dużą grupą ludzi? Jak poszło?",
                    "Jakie jest najdziwniejsze marzenie, jakie kiedykolwiek miałeś?",
                    "Kto w twoim życiu przynosi Ci największą radość?",
                    "Kto miał największy wpływ na to kim jesteś?",
                    "Jaki jest najbardziej denerwujący nawyk, który można mieć?",
                    "Gdzie jest najpiękniejsze miejsce, w którym byłeś?",
                    "Czy jest coś czego nienawidzisz ale chciałbyś to kochać?",
                    "W jaki sposób się relaksujesz?",
                    "Gdybyś był w zespole, to jaką muzykę byś grał?",
                    "Jaka jest Twoja ulubiona pora roku? Czemu?",
                    "Gdyby powstał film o twoim życiu, to jaki aktor/aktorka by cię zagrała?",
                    "Gdybyś był warzywem, to jakim?",
                    "Jeśli obudziłbyś się jutro jako zwierzę, jakim zwierzęciem chciał byś być?",
                    "Gdybyś mógł mieszkać gdziekolwiek na tej planecie i zabrać ze sobą coś, co kochasz, gdzie byś zdecydował się żyć?",
                    "Jaka jest Twoja najcenniejsza umiejętność?",
                    "Jak myślisz, jaki jest najlepszy wiek do zawarcia małżeństwa?",
                    "Jaki jest Twój ulubiony smak gumy do żucia?",
                    "Jaka jest Twoja wymarzona praca?",
                    "Jaką pierwszą rzecz kupiłeś po pierwszej wypłacie?",
                    "Jakie jest najlepsze miejsce na pizzę, w którym kiedykolwiek byłeś?"
            };
            Random rand = new Random();
            string RandomQuestion = questions[rand.Next(questions.Length)];
            await Context.Channel.SendMessageAsync($"```fix\n{RandomQuestion}```");
        }

        [Command("rozwiazano")]
        [Alias("rozwiązano", "solved", "zamknij", "close")]
        public async Task CloseHelpChannel(SocketGuildUser user = null)
        {
            if (Context.Channel is IPrivateChannel)
                return;

            var pomocnik = Context.Guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK");
            var pomocnikp = Context.Guild.Roles.FirstOrDefault(x => x.Name == "POMOCNIK+");
            var moderator = Context.Guild.Roles.FirstOrDefault(x => x.Name == "MODERATOR");
            var admin = Context.Guild.Roles.FirstOrDefault(x => x.Name == "ADMIN");
            var wlascicel = Context.Guild.Roles.FirstOrDefault(x => x.Name == "WŁAŚCICIEL");

            UserAccount account;
            if(user is null)
                account = UserAccounts.GetAccount(Context.User);
            else if (user != null && (Context.User as SocketGuildUser).Roles.Contains(pomocnik) || (Context.User as SocketGuildUser).Roles.Contains(pomocnikp) || (Context.User as SocketGuildUser).Roles.Contains(moderator) || (Context.User as SocketGuildUser).Roles.Contains(admin) || (Context.User as SocketGuildUser).Roles.Contains(wlascicel))
                account = UserAccounts.GetAccount(user);
            else
            {
                await ReplyAsync($"{Messages.UnknownError}");
                return;
            }

            bool isHelp = account.HelpInProgress;
            ulong idHelp = account.HelpChannelID;

            if (isHelp == true && idHelp != 0)
            {
                var channel = Context.Guild.GetChannel(idHelp);
                await channel.DeleteAsync();
                account.HelpInProgress = false;
                account.HelpChannelID = 0;
                UserAccounts.SaveAccounts();
            }
            else
            {
                await ReplyAsync($"{Messages.wrong} Nie znaleziono kanału do zamknięcia.");
            }
        }
    }
}
