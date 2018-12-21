using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;

using ggwp.Core;
using ggwp.Services;

namespace ggwp.Modules
{
    public class FunModule : ModuleBase
    {
        [Command("8ball")]
        [Alias("8 ball")]
        public async Task Eightball([Remainder] string question)
        {
            await Context.Message.DeleteAsync();
            if (question == null) return;

            string UserAvatar = Context.User.GetAvatarUrl();
            string BotAvatar = Context.Client.CurrentUser.GetAvatarUrl();
            string username = Context.User.Username;

            string[] ans = new string[] {
                    "Może..",
                    "Nie myśl o tym.",
                    "Bez wachania",
                    "Tak, zdecydowanie",
                    "Mam pewne wątpliwości",
                    "Wydaje mi się że tak",
                    "chyba",
                    "Nie",
                    "Tak",
                    "Jest to prawdopodobne",
                    "Nie wydaje mi się",
                    "Zapytaj ponownie później",
                    "Lepiej żebym nie mówił",
                    "Nie mogę tego przewidzieć",
                    "Ty no nie wiem :D",
                    "Nie licz na to",
                    "Moja odpowiedź brzmi: NIE",
                    "Moje źródła donoszą że nie",
                    "Raczej nie",
                    "Niemożliwe!"
                };
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"{question}");
            eb.Author.WithIconUrl(UserAvatar);
            eb.WithFooter($"{ans[new Random().Next(ans.Length)]}");
            eb.Footer.WithIconUrl($"{BotAvatar}");
            eb.WithColor(new Color(0, 0, 0));
            await ReplyAsync("", false, eb.Build());
        }

        [Command("kostka")]
        [Alias("kosc", "kosci", "kość", "kości")]
        public async Task Kosc()
        {
            await Context.Message.DeleteAsync();

            var userName = Context.User.Username;
            var userAvatar = Context.User.GetAvatarUrl();

            string[] numbers = new string[] { "1", "2", "3", "4", "5", "6" };
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"{userName} rzuca kostką...");
            eb.Author.WithIconUrl(userAvatar);
            eb.WithFooter("Wypada " + $"{numbers[new Random().Next(numbers.Length)]}" + " oczek");
            eb.Footer.WithIconUrl("https://gilkalai.files.wordpress.com/2017/09/dice.png?w=640");
            eb.WithColor(new Color(255, 255, 255));
            await ReplyAsync("", false, eb.Build());
        }

        [Command("moneta")]
        [Alias("orzelreszka", "orzel reszka", "orzeł reszka", "orzełreszka")]
        public async Task Moneta()
        {
            await Context.Message.DeleteAsync();

            string[] flip = new string[] { "Orzeł", "Reszka" };

            var userName = Context.User.Username;
            var userAvatar = Context.User.GetAvatarUrl();

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"{userName} podrzuca monetę...");
            eb.Author.WithIconUrl(userAvatar);
            eb.WithFooter("Wypada " + $"{flip[new Random().Next(flip.Length)]}");
            eb.Footer.WithIconUrl("https://opengameart.org/sites/default/files/Coin_0.png");
            eb.WithColor(Color.Gold);
            await ReplyAsync("", false, eb.Build());
        }

        [Command("emojify")]
        [Alias("emoji")]
        public async Task NewEmotify([Remainder] string args)
        {
            await Context.Message.DeleteAsync();
            string[] convertorArray = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var pattern = new Regex("^[a-zA-Z]*$", RegexOptions.Compiled);
            args = args.ToLower();
            var convertedText = "";
            foreach (char c in args)
                if (c.ToString() == "\\")
                    convertedText += "\\";
                else if (c.ToString() == "\n") convertedText += "\n";
                else if (pattern.IsMatch(c.ToString())) convertedText += $":regional_indicator_{c}:";
                else if (char.IsDigit(c)) convertedText += $":{convertorArray[(int)char.GetNumericValue(c)]}:";
                else convertedText += c;
            await ReplyAsync(convertedText);
        }
    }
}
