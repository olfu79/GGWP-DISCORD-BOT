using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Numerics;

using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;

using ggwp.Core;
using ggwp.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using SixLabors.Shapes;
using System.Net;
using System.Net.Http;
using ggwp.Services.Cooldown;

namespace ggwp.Modules
{
    public class FunModule : ModuleBase
    {
        [Cooldown(10)]
        [Command("8ball")]
        [Alias("8 ball", "8b")]
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
                    "Chyba",
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
            eb.WithColor(new Discord.Color(0, 0, 0));
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(10)]
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
            eb.WithColor(new Discord.Color(255, 255, 255));
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(10)]
        [Command("moneta")]
        [Alias("orzelreszka", "orzel reszka", "orzeł reszka", "orzełreszka", "coinflip", "coin flip", "flip coin", "flipcoin")]
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
            eb.WithColor(Discord.Color.Gold);
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(5)]
        [Command("emojify")]
        [Alias("emoji")]
        public async Task Emotify([Remainder] string args)
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

        [Cooldown(5)]
        [Command("wyjdz")]
        [Alias("drzwi", "wyjdź", "door", "doors")]
        public async Task Doors(IUser user = null)
        {
            if(user is null)
            {
                var msg = await Context.Channel.SendMessageAsync(Messages.MentionError);
                await Helpers.RemoveMessage(msg);
                return;
            }
            else
            {
                await Context.Message.DeleteAsync();
                string reply = $"{user.Mention} 👉🚪";
                await Context.Channel.SendMessageAsync(reply);
            }
        }

        [Cooldown(5)]
        [Command("reverse")]
        [Alias("odwroc", "odwróć", "odwroctekst")]
        public async Task TextReverse([Remainder] string text)
        {
            string reversedString = new string(text.Reverse().ToArray());
            await ReplyAsync(reversedString);
        }

        [Cooldown(5)]
        [Command("iq")]
        public async Task IQtest(IUser user = null)
        {
            if (user is null)
                user = Context.User;

            await Context.Message.DeleteAsync();

            Random rand1 = new Random();
            int RandomNumber = rand1.Next(0, 110);

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("💡 Poziom Inteligencji");
            eb.WithDescription($"{user} ma **{RandomNumber}** IQ");
            eb.WithColor(Color.Blue);

            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(5)]
        [Command("banan")]
        [Alias("bananek", "cm")]
        public async Task PeePeeSize(IUser user = null)
        {
            if (user is null)
                user = Context.User;

            await Context.Message.DeleteAsync();

            Random rand1 = new Random();
            int RandomNumber = rand1.Next(0, 40);
            string scale = "";
            if (RandomNumber <= 5)
                scale = "ŒΞ8";
            else if (RandomNumber <= 10)
                scale = "ŒΞΞ8";
            else if (RandomNumber <= 15)
                scale = "ŒΞΞΞ8";
            else if (RandomNumber <= 20)
                scale = "ŒΞΞΞΞ8";
            else if (RandomNumber <= 25)
                scale = "ŒΞΞΞΞΞ8";
            else if (RandomNumber <= 30)
                scale = "ŒΞΞΞΞΞΞ8";
            else if (RandomNumber <= 35)
                scale = "ŒΞΞΞΞΞΞΞ8";
            else if (RandomNumber <= 40)
                scale = "ŒΞΞΞΞΞΞΞΞ8";

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("🍌 Długość banana");
            eb.WithDescription($"Długość banana {user.Username} wynosi **{RandomNumber} cm**");
            eb.WithColor(new Color(255, 240, 30));
            eb.AddField("Długość w skali 1:5", $"```{scale}```");
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(10)]
        [Command("ocen")]
        [Alias("oceń", "rate", "ocena")]
        public async Task Rate([Remainder] string text)
        {
            await Context.Message.DeleteAsync();

            Random rand1 = new Random();
            int RandomNumber = rand1.Next(1, 11);

            string ans = "";
            string o1 = "⭐✴✴✴✴✴✴✴✴✴";
            string o2 = "⭐⭐✴✴✴✴✴✴✴✴";
            string o3 = "⭐⭐⭐✴✴✴✴✴✴✴";
            string o4 = "⭐⭐⭐⭐✴✴✴✴✴✴";
            string o5 = "⭐⭐⭐⭐⭐✴✴✴✴✴";
            string o6 = "⭐⭐⭐⭐⭐⭐✴✴✴✴";
            string o7 = "⭐⭐⭐⭐⭐⭐⭐✴✴✴";
            string o8 = "⭐⭐⭐⭐⭐⭐⭐⭐✴✴";
            string o9 = "⭐⭐⭐⭐⭐⭐⭐⭐⭐✴";
            string o10 = "⭐⭐⭐⭐⭐⭐⭐⭐⭐⭐";

            switch (RandomNumber)
            {
                case 1:
                    ans = o1;
                    break;
                case 2:
                    ans = o2;
                    break;
                case 3:
                    ans = o3;
                    break;
                case 4:
                    ans = o4;
                    break;
                case 5:
                    ans = o5;
                    break;
                case 6:
                    ans = o6;
                    break;
                case 7:
                    ans = o7;
                    break;
                case 8:
                    ans = o8;
                    break;
                case 9:
                    ans = o9;
                    break;
                case 10:
                    ans = o10;
                    break;
                default:
                    ans = "Wystąpił błąd.";
                    break;
            }

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("🌟 Ocena");
            eb.WithDescription($"Oceniam **{text}** na **{RandomNumber}/10**");
            eb.AddField("Gwiazdki", $"{ans}");
            eb.WithColor(Color.Gold);

            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(10)]
        [Command("ship")]
        [Alias("szip", "szipuj")]
        public async Task Ship(SocketGuildUser user1, SocketGuildUser user2)
        {
            var firsthalf = (user1.Username.Substring(0, (user1.Username.Length / 2)));
            var lasthalf = user2.Username.Remove(0, (user2.Username.Length / 2));
            var combined = ($"{firsthalf}{lasthalf}").Replace(" ", "");
            await ReplyAsync($"{user1.Mention}, {user2.Mention} szipuje was 😍 💒 Od teraz nazywacie się **{combined}** ♥");
        }

        [Cooldown(5)]
        [Command("calc")]
        [Alias("kalk", "kalkulator", "calculate", "oblicz", "przelicz", "policz")]
        public async Task Calculate(double n1, string op, double n2)
        {
            string[] operations = { "+", "-", "*", "/", "^", "%" };

            double result = 0;
            double firstNumber = n1;
            double secondNumber = n2;

            string stringOperation = SetOperation();

            switch (stringOperation)
            {
                case "+":
                case "addition":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                case "soustraction":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                case "multiplication":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                case "division":
                    result = firstNumber / secondNumber;
                    break;
                case "^":
                case "exposant":
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
                case "%":
                case "reste":
                    result = firstNumber % secondNumber;
                    break;
            }

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Kalkulator");
            eb.Author.WithIconUrl("https://cdn0.iconfinder.com/data/icons/finance-icons-rounded/110/Calculator-512.png");
            eb.WithDescription($"```{firstNumber} {stringOperation} {secondNumber} = {result}```");
            eb.WithColor(Color.DarkBlue);
            await ReplyAsync("", false, eb.Build());

            double SetNumber(string outputText)
            {
                double parse;
                ReplyAsync(outputText);
                string tempInput = op;
                while (!double.TryParse(tempInput, out parse))
                {
                    ReplyAsync($"{Messages.wrong} Nieprawidłowy znak lub liczba!");
                    ReplyAsync(outputText);
                    tempInput = op;
                }
                return double.Parse(tempInput);
            }

            bool IsValidOperation(string input)
            {
                return operations.Contains(input);
            }

            string SetOperation()
            {
                string tempInput = op;
                while (!IsValidOperation(tempInput))
                {
                    ReplyAsync($"{Messages.wrong} Nieprawidłowy znak lub liczba!");
                    tempInput = op;
                }
                return tempInput;
            }
        }

        [Cooldown(3)]
        [Command("pocisk")]
        [Alias("pocisnij", "pociśnij", "diss", "dis", "disuj")]
        public async Task Diss(IUser user)
        {
            await Context.Message.DeleteAsync();
            if (user == null) return;

            string UserAvatar = Context.User.GetAvatarUrl();
            string DisAvatar = user.GetAvatarUrl();
            string username = Context.User.Username;

            string[] ans = new string[] {
                    "Gdzie byłeś jak rozum rozdawali?",
                    "Jesteś taki gruby, że jak spadasz z łóżka to z dwóch stron.",
                    "Zakryj twarz! Po co Ci dwie dupy.",
                    "Powtórz bo się nie równo oplułeś.",
                    "Gdybym miał dupę jak Ty mordę to by mi kibel z domu uciekł.",
                    "Jesteś sam czy z zespołem Downa?",
                    "Z czego rżysz? Siano widzisz, czy konia masz w rodzinie?",
                    "Tobie chyba na mózgu wszy w hokeja grają?",
                    "Przestań mówić, bo mi cukier spada we krwi.",
                    "Jak cię widzę, to mi oczy ketchupem zachodzą.",
                    "Opowiedz nam o swoim wypadku.",
                    "Nie śpij na boku, bo mózg wypadnie ci przez ucho!",
                    "Mógłbyś wyjść? Potrzebuję świeżego powietrza!",
                    "Idź policz do dziesięciu. Przyda mi się godzina spokoju",
                    "Jak do mnie mówisz to zdejmij wargę z nosa.",
                    "Błysk twojej głupoty mnie oślepia.",
                    "Spadaj na drzewo dokończyć ewolucję.",
                    "Idę po śrubokręt, bo widzę, że się rozkręcasz.",
                    "A ty to jakiej płci jesteś?",
                    "Debilizm to twoja cecha wrodzona czy nabyta?",
                    "Jak można mówic tyle głupstw na sekundę? Uczysz się ich na pamięć?"
                };
            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"{Context.User.Username}: {user.Username} {ans[new Random().Next(ans.Length)]}");
            eb.Author.WithIconUrl(UserAvatar);
            eb.WithColor(Discord.Color.DarkRed);
            await ReplyAsync("", false, eb.Build());
        }

        [Cooldown(5)]
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync($"🏓 pong!");
        }

        [Cooldown(5)]
        [Command("wybierz")]
        [Alias("choose", "wybór", "wybor")]
        public async Task Pick([Remainder] string message)
        {
            string UserAvatar = Context.User.GetAvatarUrl();
            string BotAvatar = Context.Client.CurrentUser.GetAvatarUrl();

            try
            {
                var option = message.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                var rand = new Random();
                var selection = option[rand.Next(0, option.Length)];

                var embed = new EmbedBuilder();
                embed.WithAuthor($"{Context.User.Username} wybierz spośród: {message.Replace(" | ", ", ").Replace("| ", ", ").Replace(" |", ", ").Replace("|", ", ")}");
                embed.Author.WithIconUrl(UserAvatar);
                embed.WithFooter($"Okej, wybieram: {selection}");
                embed.Footer.WithIconUrl(BotAvatar);
                embed.WithColor(new Discord.Color(255, 0, 94));


                await ReplyAsync("", false, embed.Build());
            }
            catch
            {
                await ReplyAsync(Messages.UnknownError);
            }
        }

        [Cooldown(10)]
        [Command("kill")]
        [Alias("zabij", "murder")]
        public async Task PictureKill(IUser user)
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");
            await ImageBuilders.GetUserAvatar(user, "Fun/Avatars/User2.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User2.png", "Fun/Avatars/User2r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/kill.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User2r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(960, 540))
            {
                img2.Mutate(o => o.Resize(new Size(114, 114)));
                img3.Mutate(o => o.Resize(new Size(90, 90)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(658, 55))
                    .DrawImage(img3, 1f, new Point(100, 154))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(10)]
        [Command("facepalm")]
        [Alias("fp")]
        public async Task PictureFacepalm()
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/fp1.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Bg/fp2.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(751, 577))
            {
                img3.Mutate(o => o.Resize(new Size(300, 300)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img3, 1f, new Point(179, 1))
                    .DrawImage(img2, 1f, new Point(0, 0))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(10)]
        [Command("sleep")]
        [Alias("spać", "spac", "spij", "śpij", "spanie", "spanko")]
        public async Task PictureSleep()
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/sleep.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(600, 400))
            {
                img2.Mutate(o => o.Resize(new Size(204, 204)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(195, -1))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(5)]
        [Command("hi")]
        [Alias("hej", "cześć", "czesc", "elo", "siema", "siemka", "yo", "hay")]
        public async Task PictureWelcome(IUser user)
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");
            await ImageBuilders.GetUserAvatar(user, "Fun/Avatars/User2.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User2.png", "Fun/Avatars/User2r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/hi.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User2r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(2000, 1127))
            {
                img2.Mutate(o => o.Resize(new Size(291, 291)));
                img3.Mutate(o => o.Resize(new Size(200, 200)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(315, 63))
                    .DrawImage(img3, 1f, new Point(1264, 367))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(10)]
        [Command("hit")]
        [Alias("uderz", "punch", "walnij")]
        public async Task PictureHit(IUser user)
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");
            await ImageBuilders.GetUserAvatar(user, "Fun/Avatars/User2.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User2.png", "Fun/Avatars/User2r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/hit.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User2r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(468, 287))
            {
                img2.Mutate(o => o.Resize(new Size(90, 90)));
                img3.Mutate(o => o.Resize(new Size(100, 100)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(339, 52))
                    .DrawImage(img3, 1f, new Point(42, 17))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(10)]
        [Command("hug")]
        [Alias("przytul", "przytulas")]
        public async Task PictureHug(IUser user)
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");
            await ImageBuilders.GetUserAvatar(user, "Fun/Avatars/User2.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User2.png", "Fun/Avatars/User2r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/hug.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User2r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(760, 507))
            {
                img2.Mutate(o => o.Resize(new Size(122, 122)));
                img3.Mutate(o => o.Resize(new Size(124, 124)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(411, 114))
                    .DrawImage(img3, 1f, new Point(298, 112))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(10)]
        [Command("kopnij")]
        [Alias("kick", "kop")]
        public async Task PictureKick(IUser user)
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");
            await ImageBuilders.GetUserAvatar(user, "Fun/Avatars/User2.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User2.png", "Fun/Avatars/User2r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/kick.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User2r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(500, 385))
            {
                img2.Mutate(o => o.Resize(new Size(32, 32)));
                img3.Mutate(o => o.Resize(new Size(32, 32)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(233, 35))
                    .DrawImage(img3, 1f, new Point(111, 95))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }

        [Cooldown(10)]
        [Command("kiss")]
        [Alias("pocałuj", "pocaluj", "całus", "calus", "cmok")]
        public async Task PictureKiss(IUser user)
        {
            await ImageBuilders.GetUserAvatar(Context.User, "Fun/Avatars/User1.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User1.png", "Fun/Avatars/User1r.png");
            await ImageBuilders.GetUserAvatar(user, "Fun/Avatars/User2.png");
            await ImageBuilders.MakeImageRound("Fun/Avatars/User2.png", "Fun/Avatars/User2r.png");

            using (Image<Rgba32> img1 = SixLabors.ImageSharp.Image.Load("Fun/Bg/kiss.jpg"))
            using (Image<Rgba32> img2 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User1r.png"))
            using (Image<Rgba32> img3 = SixLabors.ImageSharp.Image.Load("Fun/Avatars/User2r.png"))
            using (Image<Rgba32> outputImage = new Image<Rgba32>(750, 400))
            {
                img2.Mutate(o => o.Resize(new Size(218, 218)));
                img3.Mutate(o => o.Resize(new Size(218, 218)));

                outputImage.Mutate(o => o
                    .DrawImage(img1, 1f, new Point(0, 0))
                    .DrawImage(img2, 1f, new Point(402, 29))
                    .DrawImage(img3, 1f, new Point(180, 67))
                );

                outputImage.Save("Fun/FunPic.png");
                await Context.Channel.SendFileAsync("Fun/FunPic.png");
            }
        }
    }
}
