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
using ggwp.Core.GuildAccounts;
using ggwp.Core.ReactionsSystem;
using System.Configuration;

namespace ggwp.Services.Reaction_Methods
{
    public static class ReactionsService
    {

        public static async Task Shop(IGuild guild, IMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var coin = Emote.Parse("<:coin:462351821910835200>");
            var vip = Emote.Parse("<:supervip:462351820501549066>");
            var svip = Emote.Parse("<:ultravip:462351820308873246>");
            var sponsor = Emote.Parse("<:sponsor:462351820006883340>");

            var one = new Emoji("\u0031\u20e3");
            var two = new Emoji("\u0032\u20e3");
            var three = new Emoji("\u0033\u20e3");
            var four = new Emoji("\u0034\u20e3");
            var five = new Emoji("\u0035\u20e3");
            var six = new Emoji("\u0036\u20e3");
            var seven = new Emoji("\u0037\u20e3");
            var eight = new Emoji("\u0038\u20e3");
            var nine = new Emoji("\u0039\u20e3");
            var left = new Emoji("◀");
            var right = new Emoji("▶");

            EmbedBuilder ebShop1 = new EmbedBuilder();
            ebShop1.WithAuthor("SKLEP");
            ebShop1.Author.WithIconUrl("http://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Shop-icon.png");
            ebShop1.WithDescription("Kliknij w odpowiednią reakcje by zakupić produkt.");
            ebShop1.AddField($":one: RANGA VIP {vip}", $"{coin} 100", true);
            ebShop1.AddField($":two: RANGA SVIP {svip}", $"{coin} 100", true);
            ebShop1.AddField($":three: WYBÓR MUZYKI :musical_note:", $"{coin} 100", true);
            ebShop1.AddField($":four: AKINATOR 👳", $"{coin} 100", true);
            ebShop1.AddField($":five: ZMIANA NICKU :label:", $"{coin} 100", true);
            ebShop1.AddField($":six: WŁASNY KANAŁ 🎙️", $"{coin} 100", true);
            ebShop1.AddField($":seven: MYSTERY BOX 1 📗", $"{coin} 1000", true);
            ebShop1.AddField($":eight: MYSTERY BOX 2 📘", $"{coin} 2000", true);
            ebShop1.AddField($":nine: MYSTERY BOX 3 📕", $"{coin} 3000", true);
            ebShop1.WithFooter("👆 Kliknij w odpowiednią reakcje by zakupić produkt. Użyj strzałek ◀ ▶ żeby zmienić stronę.");
            ebShop1.WithColor(new Color(34, 166, 192));

            RestUserMessage msg = await channel.SendMessageAsync("", false, ebShop1.Build());
            ReactionChannels.channels.shop = msg.Id;
            ReactionChannels.SaveChannels();

            GuildAccount.ShopPage = 1;

            await msg.AddReactionAsync(left);
            await msg.AddReactionAsync(one);
            await msg.AddReactionAsync(two);
            await msg.AddReactionAsync(three);
            await msg.AddReactionAsync(four);
            await msg.AddReactionAsync(five);
            await msg.AddReactionAsync(six);
            await msg.AddReactionAsync(seven);
            await msg.AddReactionAsync(eight);
            await msg.AddReactionAsync(nine);
            await msg.AddReactionAsync(right);
        }

        public static async Task Fun(IGuild guild, ISocketMessageChannel channel, IUser user, IUserMessage message)
        {
            await message.DeleteAsync();
            var GuildAccount = GuildAccounts.GetAccount(guild);

            var e1 = new Emoji("💁");
            var e2 = new Emoji("😁");
            var e3 = new Emoji("😻");
            var e4 = new Emoji("😎");
            var e5 = new Emoji("😏");
            var e6 = new Emoji("😘");
            var e7 = new Emoji("😜");
            var e8 = new Emoji("💬");
            var e9 = new Emoji("🙄");
            var e10 = new Emoji("😠");
            var e11 = new Emoji("🚬");
            var e12 = new Emoji("☁");
            var e13 = new Emoji("🍾");
            var e14 = new Emoji("👥");
            var e15 = new Emoji("😈");
            var e16 = new Emoji("👫");
            var e17 = new Emoji("😝");
            var e18 = new Emoji("🤸");
            var e19 = new Emoji("🍞");
            var e20 = new Emoji("🌜");
            var e21 = new Emoji("🌅");
            var e22 = new Emoji("🍎");
            var e23 = new Emoji("😋");
            var e24 = new Emoji("😊");
            var e25 = new Emoji("👤");
            var e26 = new Emoji("🤔");
            var e27 = new Emoji("🥊");
            var e28 = new Emoji("😉");
            var e29 = new Emoji("🛋");
            var e30 = new Emoji("🖼");
            var e31 = new Emoji("🎧");
            var e32 = new Emoji("📟");
            var e33 = new Emoji("🎟");
            var e34 = new Emoji("🛠");
            var e35 = new Emoji("⛹");
            var e36 = new Emoji("💅");
            var e37 = new Emoji("🛌");
            var e38 = new Emoji("⚱");
            var e39 = new Emoji("➡");

            EmbedBuilder eb1 = new EmbedBuilder();
            eb1.WithAuthor("Role 4Fun");
            eb1.Author.WithIconUrl("https://media.istockphoto.com/vectors/beach-ball-icon-vector-illustration-vector-id953517418?k=6&m=953517418&s=612x612&w=0&h=gR-OnMknySzJkaRDwig6gf84FnrSYeYgnv3zNzOtN4I=");
            eb1.AddField("Zareaguj aby wybrać.", $"<@&556548939860410381>\n<@&556548940766380032>\n<@&556548941584269343>\n<@&556548942389706782>\n<@&556548942674788354>\n<@&556548945325719564>\n<@&556548945376182273> \n<@&556548945594023996>\n<@&556552307647578115>\n<@&556548947217350670>\n<@&556548947435323393>\n<@&556548949096398850>\n<@&556548949381480479>\n<@&556548951059464212>\n<@&556548951126441990>\n<@&556548952892375080>\n<@&556548954272169995>\n<@&556548955719073802>\n<@&556548956025258074>\n<@&556548957531013133>", true);
            eb1.WithColor(Color.Green);

            RestUserMessage msg1 = await channel.SendMessageAsync("", false, eb1.Build());
            ReactionChannels.channels.fun1 = msg1.Id;
            ReactionChannels.SaveChannels();

            await msg1.AddReactionAsync(e1);
            await msg1.AddReactionAsync(e2);
            await msg1.AddReactionAsync(e3);
            await msg1.AddReactionAsync(e4);
            await msg1.AddReactionAsync(e5);
            await msg1.AddReactionAsync(e6);
            await msg1.AddReactionAsync(e7);
            await msg1.AddReactionAsync(e8);
            await msg1.AddReactionAsync(e9);
            await msg1.AddReactionAsync(e10);
            await msg1.AddReactionAsync(e11);
            await msg1.AddReactionAsync(e12);
            await msg1.AddReactionAsync(e13);
            await msg1.AddReactionAsync(e14);
            await msg1.AddReactionAsync(e15);
            await msg1.AddReactionAsync(e16);
            await msg1.AddReactionAsync(e17);
            await msg1.AddReactionAsync(e18);
            await msg1.AddReactionAsync(e19);
            await msg1.AddReactionAsync(e20);

            EmbedBuilder eb2 = new EmbedBuilder();
            eb2.WithAuthor("Role 4Fun");
            eb2.Author.WithIconUrl("https://media.istockphoto.com/vectors/beach-ball-icon-vector-illustration-vector-id953517418?k=6&m=953517418&s=612x612&w=0&h=gR-OnMknySzJkaRDwig6gf84FnrSYeYgnv3zNzOtN4I=");
            eb2.AddField("Zareaguj aby wybrać.", $"<@&556548959724896256>\n<@&556548960781729805>\n<@&556548962115649537>\n<@&556548963474604033>\n<@&556548964841685013>\n<@&556548966125142066>\n<@&556548967350009868>\n<@&556548968700706816>\n<@&556548970164387874>\n<@&556548970755653652>\n<@&556548972248956933>\n<@&556548973003931668>\n<@&556548974253834254>\n<@&556548975990145034>\n<@&556548976300654720>\n<@&556548977936302090>\n<@&556548979098386434>\n<@&556548980780040202>", true);
            eb2.WithColor(Color.Green);

            RestUserMessage msg2 = await channel.SendMessageAsync("", false, eb2.Build());
            ReactionChannels.channels.fun2 = msg2.Id;
            ReactionChannels.SaveChannels();

            await msg2.AddReactionAsync(e21);
            await msg2.AddReactionAsync(e22);
            await msg2.AddReactionAsync(e23);
            await msg2.AddReactionAsync(e24);
            await msg2.AddReactionAsync(e25);
            await msg2.AddReactionAsync(e26);
            await msg2.AddReactionAsync(e27);
            await msg2.AddReactionAsync(e28);
            await msg2.AddReactionAsync(e29);
            await msg2.AddReactionAsync(e30);
            await msg2.AddReactionAsync(e31);
            await msg2.AddReactionAsync(e32);
            await msg2.AddReactionAsync(e33);
            await msg2.AddReactionAsync(e34);
            await msg2.AddReactionAsync(e35);
            await msg2.AddReactionAsync(e36);
            await msg2.AddReactionAsync(e37);
            await msg2.AddReactionAsync(e38);
            await msg2.AddReactionAsync(e39);
        }

        public static async Task Gambling(IGuild guild, ISocketMessageChannel channel, IUser user, IUserMessage message)
        {
            await message.DeleteAsync();
            var GuildAccount = GuildAccounts.GetAccount(guild);

            var one = new Emoji("❤");
            var two = new Emoji("💛");
            var three = new Emoji("💚");
            var four = new Emoji("💙");
            var five = new Emoji("💜");
            var six = new Emoji("🖤");
            var left = new Emoji("◀");
            var right = new Emoji("▶");

            EmbedBuilder eb = new EmbedBuilder();
            // eb.Author.WithIconUrl(avatar);
            eb.AddField("Sloty", $"```,```");
            eb.WithColor(Color.DarkGrey);

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.gambling = msg.Id;
            ReactionChannels.SaveChannels();

            GuildAccount.GamblingPage = 1;

            await msg.AddReactionAsync(left);
            await msg.AddReactionAsync(one);
            await msg.AddReactionAsync(two);
            await msg.AddReactionAsync(three);
            await msg.AddReactionAsync(four);
            await msg.AddReactionAsync(five);
            await msg.AddReactionAsync(six);
            await msg.AddReactionAsync(right);
        }

        public static async Task Profile(ISocketMessageChannel channel, IUser user, IMessage message)
        {
            await message.DeleteAsync();

            var account = UserAccounts.GetAccount(user);

            string avatar = user.GetAvatarUrl();
            string userlvl = account.LevelNumber.ToString();
            string userexp = account.XP.ToString();
            string username = user.Username;
            string moneyw = account.MoneyWallet.ToString();
            string moneyac = account.MoneyAccount.ToString();
            string NoWarns = account.Warns.ToString();

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor($"Kliknij aby załadować swój profil");
            eb.Author.WithIconUrl("https://cdn4.iconfinder.com/data/icons/social-messaging-ui-color-squares-01/3/30-512.png");
            eb.WithThumbnailUrl("https://cdn4.iconfinder.com/data/icons/social-messaging-ui-color-squares-01/3/30-512.png");
            eb.AddField("Nazwa:", "-", true);
            eb.AddField("Liczba ostrzeżeń:", "-", true);
            eb.AddField("Poziom:", "-", true);
            eb.AddField("Exp:", "-", true);
            eb.AddField("Portfel:", "-", true);
            eb.AddField("Konto:", "-", true);
            eb.WithColor(Color.DarkGrey);

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.profile = msg.Id;
            ReactionChannels.SaveChannels();

            var reaction = new Emoji("🚹");
            await msg.AddReactionAsync(reaction);
        }

        public static async Task Meme(IUserMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var tuple = await Helpers.GetMeme();
            string MemeUrl = tuple.url;
            string MemeAlt = tuple.alt;

            var meme = new Emoji("🤣");
            var joke = new Emoji("🍞");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle(MemeAlt);
            eb.WithImageUrl(MemeUrl);
            eb.WithColor(Color.Gold);

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.meme = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(meme);
            await msg.AddReactionAsync(joke);
        }

        public static async Task Bank(IMessage message, IUser user, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var daily = new Emoji("🆓");
            var balance = new Emoji("💳");
            var withdraw = new Emoji("📥");
            var deposit = new Emoji("📤");

            var ebBank = new EmbedBuilder()
                .WithColor(new Color(147, 159, 168))
                .WithAuthor(author =>
                {
                    author
                        .WithName("BANKOMAT")
                        .WithIconUrl("https://cdn4.iconfinder.com/data/icons/banking-and-finance/500/atm-cash-machine-512.png");
                })
                .WithTitle("​")
                .WithDescription("🆓 Aby odebrać darmowe pieniądze.\n" +
                "💳 Aby sprawdzić stan konta.\n" +
                "📥 Aby wypłacić pieniądze z konta.\n" +
                "📤 Aby wpłacić pieniądze na konto.");

            RestUserMessage msg = await channel.SendMessageAsync("", false, ebBank.Build());
            ReactionChannels.channels.bank = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(daily);
            await msg.AddReactionAsync(balance);
            await msg.AddReactionAsync(withdraw);
            await msg.AddReactionAsync(deposit);
        }

        public static async Task Coinflip()
        {

        }
        public static async Task Roulette()
        {

        }
        public static async Task Games(IMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var r1 = Emote.Parse("<:apex:558758045354557440>");
            var r2 = Emote.Parse("<:fortnite:558758045359013889>");
            var r3 = Emote.Parse("<:lol:558758048454279189>");
            var r4 = Emote.Parse("<:minecraft:558758045723918347>");
            var r5 = Emote.Parse("<:csgo:558758045455351828>");
            var r6 = Emote.Parse("<:ov:558758045396631552>");
            var r7 = Emote.Parse("<:wow:558758046629888020>");
            var r8 = Emote.Parse("<:hearthstone:558759198511464448>");
            var r9 = Emote.Parse("<:heroes7:558760033001799680>");
            var r10 = Emote.Parse("<:wot:558758046067589130>");
            var r11 = Emote.Parse("<:rocketleague:558758050521939969>");
            var r12 = Emote.Parse("<:fifa:558758047544246312>");
            var r13 = Emote.Parse("<:unturned:558758045409345570>");
            var r14 = Emote.Parse("<:roblox:558758045560078346>");
            var r15 = Emote.Parse("<:forest:558758050970730498>");
            var r16 = Emote.Parse("<:rdr2:558758046021451796>");
            var r17 = Emote.Parse("<:gta:558976208067493888>");
            var r18 = Emote.Parse("<:ets2:558758049456586855>");
            var r19 = Emote.Parse("<:pubg:558971721194143744>");
            var r20 = new Emoji("➡");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("GRY");
            eb.WithTitle("Wybierz gry w które grasz klikając w odpowiednią reakcję.");
            eb.Author.WithIconUrl("https://us.123rf.com/450wm/epapijon/epapijon1608/epapijon160800097/63020831-information-icon-dark-circle-with-white-gamepad-and-shadow.jpg?ver=6");
            eb.AddField("​", $"{r1} APEX LEGENDS\n{r4} MINECRAFT\n{r7} WORLD OF WARCRAFT\n{r10} WORLD OF TANKS\n{r13} UNTURNED\n{r16} RDR 2\n{r19} PUBG\n", true);
            eb.AddField("​", $"{r2} FORTNITE\n{r5} CS:GO\n{r8} HEARTHSTONE\n{r11} ROCKET LEAGUE\n{r14} ROBLOX\n{r17} GTA V", true);
            eb.AddField("​", $"{r3} LOL\n{r6} OVERWATCH\n{r9} HEROES VII\n{r12} FIFA\n{r15} THE FOREST\n{r18} ETS2​", true);
            eb.WithColor(new Color(255, 255, 255));

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.games = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(r1);
            await msg.AddReactionAsync(r4);
            await msg.AddReactionAsync(r7);
            await msg.AddReactionAsync(r10);
            await msg.AddReactionAsync(r13);
            await msg.AddReactionAsync(r16);
            await msg.AddReactionAsync(r19);
            await msg.AddReactionAsync(r2);
            await msg.AddReactionAsync(r5);
            await msg.AddReactionAsync(r8);
            await msg.AddReactionAsync(r11);
            await msg.AddReactionAsync(r14);
            await msg.AddReactionAsync(r17);
            await msg.AddReactionAsync(r3);
            await msg.AddReactionAsync(r6);
            await msg.AddReactionAsync(r9);
            await msg.AddReactionAsync(r12);
            await msg.AddReactionAsync(r15);
            await msg.AddReactionAsync(r18);
            await msg.AddReactionAsync(r20);

        }
        public static async Task Help(IMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var e1 = new Emoji("💰");
            var e2 = new Emoji("🤐");
            var e3 = new Emoji("✋");
            var e4 = new Emoji("💡");
            var e5 = new Emoji("🌟");
            var e6 = new Emoji("📨");
            var e7 = new Emoji("📜");
            var e8 = Emote.Parse("<:supervip:462351820501549066>");
            var e9 = Emote.Parse("<:ultravip:462351820308873246>");
            var e10 = Emote.Parse("<:sponsor:462351820006883340>");
            var e11 = new Emoji("👻");
            var e12 = new Emoji("🎵");
            var e13 = Emote.Parse("<:blob_youtube:460770184689352705>");
            var e14 = new Emoji("⛑");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Pomoc");
            eb.Author.WithIconUrl("https://cdn0.iconfinder.com/data/icons/social-messaging-ui-color-shapes/128/add-circle-green-512.png");
            eb.AddField("​", $":moneybag: Jak zarabiać pieniądze?\n:zipper_mouth: Co zrobić jeśli ktoś mnie obraża?\n:hand_splayed: Jak kandydować do administracji?\n:bulb: Mam pomysł na serwer gdzie to napisać?\n:star2: Chciał bym zostać partnerem? Jakie wymogi muszę spełniać?\n:incoming_envelope:  W jaki sposób mogę zaprosić moich znajomych?\n:scroll: Gdzie znajdę listę komend?\n{e8} Wszystko o randze <@&517063123690061834>\n{e9} Wszystko o randze <@&517063059659817000>\n{e10} Wszystko o randze <@&517062733699612684>\n:ghost: Mogę popisać z akinatorem?\n:musical_note: Mogę posłuchać muzyki?\n{e13} Wszystko o <@&517063084368723991> <@&517062956022890517> <@&517063026273157120>\n​:helmet_with_cross: Potrzebuje innej pomocy. Mam sprawę do administracji.");
            eb.WithColor(new Color(72, 158, 0));
            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.help = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(e1);
            await msg.AddReactionAsync(e2);
            await msg.AddReactionAsync(e3);
            await msg.AddReactionAsync(e4);
            await msg.AddReactionAsync(e5);
            await msg.AddReactionAsync(e6);
            await msg.AddReactionAsync(e7);
            await msg.AddReactionAsync(e8);
            await msg.AddReactionAsync(e9);
            await msg.AddReactionAsync(e10);
            await msg.AddReactionAsync(e13);
            await msg.AddReactionAsync(e11);
            await msg.AddReactionAsync(e12);
            await msg.AddReactionAsync(e14);
        }
        public static async Task Gender(IMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var m = new Emoji("🚹");
            var k = new Emoji("🚺");
            var arrow = new Emoji("➡");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("​");
            eb.WithAuthor("PŁEĆ\n");
            eb.Author.WithIconUrl("https://i.imgur.com/rwJ1dxk.png");
            eb.WithTitle("Wybierz swoją płeć klikając w odpowiednią reakcje");
            eb.WithDescription("🚹 Mężczyzna\n\n🚺 Kobieta");
            eb.WithColor(Color.LighterGrey);

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.gender = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(m);
            await msg.AddReactionAsync(k);
            await msg.AddReactionAsync(arrow);
        }
        public static async Task Age(IMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var r1 = new Emoji("\u0031\u20e3");
            var r2 = new Emoji("\u0032\u20e3");
            var r3 = new Emoji("\u0033\u20e3");
            var r4 = new Emoji("\u0034\u20e3");
            var r5 = new Emoji("\u0035\u20e3");
            var r6 = new Emoji("\u0036\u20e3");
            var r7 = new Emoji("➡");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("WIEK");
            eb.Author.WithIconUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Logo_anniversaire_rouge.svg/1024px-Logo_anniversaire_rouge.svg.png");
            eb.WithTitle("Wybierz swój wiek klikając w odpowiednią reakcje");
            eb.AddField("​", ":one: 13 lat\n\n:two: 14 lat\n\n:three: 15 lat​", true);
            eb.AddField("​", ":four: 16 lat​\n\n:five: 17 lat\n\n:six: 18+ lat", true);
            eb.WithColor(new Color(185, 43, 43));

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.age = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(r1);
            await msg.AddReactionAsync(r2);
            await msg.AddReactionAsync(r3);
            await msg.AddReactionAsync(r4);
            await msg.AddReactionAsync(r5);
            await msg.AddReactionAsync(r6);
            await msg.AddReactionAsync(r7);
        }

        public static async Task Rules(IMessage message, ISocketMessageChannel channel)
        {
            await message.DeleteAsync();

            var nie = Emote.Parse("<:WrongMark:460770239286870017>");
            var tak = Emote.Parse("<:CheckMark:460770234177945610>");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("​");
            eb.WithAuthor("Czy zapoznałeś się i akceptujesz regulamin?");
            eb.Author.WithIconUrl("https://i.imgur.com/C0jZgFX.png");
            eb.AddField($"{nie} Nie, nie akceptuje", "​");
            eb.AddField($"{tak} Tak, zapoznałem się i akceptuje.", "​");
            eb.WithColor(new Color(32, 163, 102));

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.rules = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(nie);
            await msg.AddReactionAsync(tak);
        }
    }
}
