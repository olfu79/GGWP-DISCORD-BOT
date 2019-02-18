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
            eb.WithColor(Discord.Color.Gold);
            await ReplyAsync("", false, eb.Build());
        }

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

        [Command("test")]
        public async Task test()
        {
            var s1 = "      )   \n    .-'-. \n   (     )\n    `-=-' ".Split("\n");

            var s2 = "      )   \n    .-'-. \n   (/////)\n    `-=-' ".Split("\n");

            var s3 = "     _o_  \n    (   ) \n    )   ( \n   '-'o'-'".Split("\n");

            //siedem
            //"    _____ \n   /__   /\n     /  / \n    /__/  "
            //winogrono
            //"   |\\     \n   \\|_\\_  \n    (_)_) \n      (_) "
            //gwiazdka
            //"   __/^\\__\n   \\  *  /\n    >   < \n   /.-^-.\\"
            //puste
            //"      )   \n    .-'-. \n   (     )\n    `-=-' "
            //pełne
            //"      )   \n    .-'-. \n   (/////)\n    `-=-' "
            //batonik
            //"    _____ \n   |=====|\n   |B A R|\n   |_____|"
            //dzwonek
            //"     _o_  \n    (   ) \n    )   ( \n   '-'o'-'"

            StringBuilder sb = new StringBuilder("");

            for (var i = 0; i < s1.Length && i < s2.Length && i < s3.Length; i++)
            {
                sb.Append($"{s1[i]} {s2[i]} {s3[i]}\n");
            }
            await Context.Channel.SendMessageAsync($"```{sb}```");
        }

        [Command("ship")]
        [Alias("szip")]
        public async Task Ship(SocketGuildUser user1, SocketGuildUser user2)
        {
            var firsthalf = (user1.Username.Substring(0, (user1.Username.Length / 2)));
            var lasthalf = user2.Username.Remove(0, (user2.Username.Length / 2));
            var combined = ($"{firsthalf}{lasthalf}").Replace(" ", "");
            await ReplyAsync($"{user1.Mention}, {user2.Mention} szipuje was 😍 💒 Od teraz nazywacie się **{combined}** ♥");
        }

        [Command("pocisk")]
        [Alias("pocisnij", "pociśnij", "diss", "dis")]
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

        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync($"🏓 pong!");
        }

        [Command("wybierz")]
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
                //err message here
            }
        }

        [Command("kill")]
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

        [Command("fp")]
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

        [Command("slp")]
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

        [Command("hi")]
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

        [Command("hit")]
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

        [Command("hug")]
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

        [Command("kick")]
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

        [Command("kiss")]
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
