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

            var cs = Emote.Parse("<:csgo:460770281020063746>");
            var lol = Emote.Parse("<:lol:460770233326501898>");
            var pubg = Emote.Parse("<:pubg:460770295620304916>");
            var fortn = Emote.Parse("<:fortnite:460770233574227969>");
            var ov = Emote.Parse("<:overwatch:460770233297141771>");
            var roblx = Emote.Parse("<:roblox:460770244605116426>");
            var gta = Emote.Parse("<:gta:461586476182798336>");
            var mc = Emote.Parse("<:minecraft:461586466263531520>");
            var sims = Emote.Parse("<:sims:461586518214180864>");
            var rocklg = Emote.Parse("<:rocketleague:461586464787136512>");
            var unturned = Emote.Parse("<:unturned:461586456419368970>");
            var wow = Emote.Parse("<:wow:461586462475812895>");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Wybierz gry w które grasz klikając w odpowiednią reakcję.");
            eb.Author.WithIconUrl("https://us.123rf.com/450wm/epapijon/epapijon1608/epapijon160800097/63020831-information-icon-dark-circle-with-white-gamepad-and-shadow.jpg?ver=6");
            eb.AddField("​", $"{cs} - CS:GO\n\n{lol} - LOL\n\n{pubg} - PUBG\n\n{fortn} - Fortnite", true);
            eb.AddField("​", $"{ov} - Overwatch\n\n{roblx} - Roblox\n\n{gta} - GTA V\n\n{mc} - Minecraft", true);
            eb.AddField("​", $"{sims} - Simsy\n\n{rocklg} - Rocket League\n\n{unturned} - Unturned\n\n{wow} - World Of  Warcraft​", true);
            eb.WithColor(new Color(255, 255, 255));

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.games = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(cs);
            await msg.AddReactionAsync(lol);
            await msg.AddReactionAsync(pubg);
            await msg.AddReactionAsync(fortn);
            await msg.AddReactionAsync(ov);
            await msg.AddReactionAsync(roblx);
            await msg.AddReactionAsync(gta);
            await msg.AddReactionAsync(mc);
            await msg.AddReactionAsync(sims);
            await msg.AddReactionAsync(rocklg);
            await msg.AddReactionAsync(unturned);
            await msg.AddReactionAsync(wow);
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

            var m = new Emoji("👨");
            var k = new Emoji("👩");

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithTitle("​");
            eb.WithAuthor("Wybierz swoją płeć klikając w odpowiednią reakcje");    
            eb.Author.WithIconUrl("https://i.imgur.com/rwJ1dxk.png");
            eb.AddField("👦 Chłopak", "👨 Mężczyzna", true);
            eb.AddField("👧 Dziewczyna", "👩 Kobieta", true);
            eb.WithColor(Color.LighterGrey);

            RestUserMessage msg = await channel.SendMessageAsync("", false, eb.Build());
            ReactionChannels.channels.gender = msg.Id;
            ReactionChannels.SaveChannels();

            await msg.AddReactionAsync(m);
            await msg.AddReactionAsync(k);
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

            EmbedBuilder eb = new EmbedBuilder();
            eb.WithAuthor("Wybierz swój wiek klikając w odpowiednią reakcje");
            eb.Author.WithIconUrl("https://upload.wikimedia.org/wikipedia/commons/thumb/0/0e/Logo_anniversaire_rouge.svg/1024px-Logo_anniversaire_rouge.svg.png");
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
