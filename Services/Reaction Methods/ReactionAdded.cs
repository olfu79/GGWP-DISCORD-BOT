using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Rest;
using Discord.WebSocket;
using ggwp.Core.GuildAccounts;
using ggwp.Core.ReactionsSystem;
using ggwp.Core.UserAccounts;
using ggwp.Services.Economy;

namespace ggwp.Services.Reaction_Methods
{
    public static class Reaction_Added
    {
        /*internal static Task ReactionReport(Cacheable<IUserMessage, ulong> arg1, ISocketMessageChannel arg2, SocketReaction arg3)
        {
            throw new NotImplementedException();
        }*/

        public static async Task ReactionGames(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.games)
            {

                var ReactionUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;

                var account = UserAccounts.GetAccount(reaction.User.Value);

                var msg = await cache.GetOrDownloadAsync();

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    var guildUser = (SocketGuildUser)reaction.User;

                    if (reaction.Emote.Name == "apex")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "APEX");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "minecraft")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "MINECRAFT");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "wow")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "WORLD OF WARCRAFT");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "wot")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "WORLD OF TANKS");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "unturned")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "UNTURNED");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "rdr2")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "RDR 2");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "pubg")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "PUBG");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "fortnite")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "FORTNITE");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "csgo")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "CS:GO");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "hearthstone")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "HEARTHSTONE");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "rocketleague")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "ROCKET LEAGUE");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "roblox")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "ROBLOX");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "gta")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "GTA V");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "lol")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "LOL");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "ov")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "OVERWATCH");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "heroes7")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "HEROES 7");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "fifa")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "FIFA 19");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "forest")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "THE FOREST");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "ets2")
                    {
                        var r = guild.Roles.FirstOrDefault(x => x.Name == "ETS 2");

                        if (ReactionUser.Roles.Contains(r))
                            await guildUser.RemoveRoleAsync(r);
                        else
                            await guildUser.AddRoleAsync(r);
                    }
                    else if (reaction.Emote.Name == "➡")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 4/5");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 5/5");

                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.AddRoleAsync(r2);
                    }
                }
            }
        }

        public static async Task ReactionFun1(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.fun1)
            {
                var ReactionUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();
                var account = UserAccounts.GetAccount(reaction.User.Value);

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    var guildUser = (SocketGuildUser)reaction.User;

                    if (reaction.Emote.Name == "💁")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "💁 Atencjusz");

                        if (ReactionUser.Roles.Contains(r1))
                            await guildUser.RemoveRoleAsync(r1);
                        else
                            await guildUser.AddRoleAsync(r1);
                    }
                    else if (reaction.Emote.Name == "😁")
                    {
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "😁 Śmieszek");

                        if (ReactionUser.Roles.Contains(r2))
                            await guildUser.RemoveRoleAsync(r2);
                        else
                            await guildUser.AddRoleAsync(r2);
                    }
                    else if (reaction.Emote.Name == "😻")
                    {
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "😻 Słodziak");

                        if (ReactionUser.Roles.Contains(r3))
                            await guildUser.RemoveRoleAsync(r3);
                        else
                            await guildUser.AddRoleAsync(r3);
                    }
                    else if (reaction.Emote.Name == "😎")
                    {
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "😎 Kozak");

                        if (ReactionUser.Roles.Contains(r4))
                            await guildUser.RemoveRoleAsync(r4);
                        else
                            await guildUser.AddRoleAsync(r4);
                    }
                    else if (reaction.Emote.Name == "😏")
                    {
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "😏 Zboczony");

                        if (ReactionUser.Roles.Contains(r5))
                            await guildUser.RemoveRoleAsync(r5);
                        else
                            await guildUser.AddRoleAsync(r5);
                    }
                    else if (reaction.Emote.Name == "😘")
                    {
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "😘 Podrywacz");

                        if (ReactionUser.Roles.Contains(r6))
                            await guildUser.RemoveRoleAsync(r6);
                        else
                            await guildUser.AddRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "😜")
                    {
                        var r7 = guild.Roles.FirstOrDefault(x => x.Name == "😜 Głupek");

                        if (ReactionUser.Roles.Contains(r7))
                            await guildUser.RemoveRoleAsync(r7);
                        else
                            await guildUser.AddRoleAsync(r7);
                    }
                    else if (reaction.Emote.Name == "💬")
                    {
                        var r8 = guild.Roles.FirstOrDefault(x => x.Name == "💬 Gaduła");

                        if (ReactionUser.Roles.Contains(r8))
                            await guildUser.RemoveRoleAsync(r8);
                        else
                            await guildUser.AddRoleAsync(r8);
                    }
                    else if (reaction.Emote.Name == "🙄")
                    {
                        var r9 = guild.Roles.FirstOrDefault(x => x.Name == "🙄 Maruda");

                        if (ReactionUser.Roles.Contains(r9))
                            await guildUser.RemoveRoleAsync(r9);
                        else
                            await guildUser.AddRoleAsync(r9);
                    }
                    else if (reaction.Emote.Name == "😠")
                    {
                        var r10 = guild.Roles.FirstOrDefault(x => x.Name == "😠 Nerwus");

                        if (ReactionUser.Roles.Contains(r10))
                            await guildUser.RemoveRoleAsync(r10);
                        else
                            await guildUser.AddRoleAsync(r10);
                    }
                    else if (reaction.Emote.Name == "🚬")
                    {
                        var r11 = guild.Roles.FirstOrDefault(x => x.Name == "🚬 Palacz");

                        if (ReactionUser.Roles.Contains(r11))
                            await guildUser.RemoveRoleAsync(r11);
                        else
                            await guildUser.AddRoleAsync(r11);
                    }
                    else if (reaction.Emote.Name == "☁")
                    {
                        var r12 = guild.Roles.FirstOrDefault(x => x.Name == "☁ Vaper");

                        if (ReactionUser.Roles.Contains(r12))
                            await guildUser.RemoveRoleAsync(r12);
                        else
                            await guildUser.AddRoleAsync(r12);
                    }
                    else if (reaction.Emote.Name == "🍾")
                    {
                        var r13 = guild.Roles.FirstOrDefault(x => x.Name == "🍾 Alkoholik");

                        if (ReactionUser.Roles.Contains(r13))
                            await guildUser.RemoveRoleAsync(r13);
                        else
                            await guildUser.AddRoleAsync(r13);
                    }
                    else if (reaction.Emote.Name == "👥")
                    {
                        var r14 = guild.Roles.FirstOrDefault(x => x.Name == "👥 Nolife");

                        if (ReactionUser.Roles.Contains(r14))
                            await guildUser.RemoveRoleAsync(r14);
                        else
                            await guildUser.AddRoleAsync(r14);
                    }
                    else if (reaction.Emote.Name == "😈")
                    {
                        var r15 = guild.Roles.FirstOrDefault(x => x.Name == "😈 Diabełek");

                        if (ReactionUser.Roles.Contains(r15))
                            await guildUser.RemoveRoleAsync(r15);
                        else
                            await guildUser.AddRoleAsync(r15);
                    }
                    else if (reaction.Emote.Name == "👫")
                    {
                        var r16 = guild.Roles.FirstOrDefault(x => x.Name == "👫 Przyjacielski");

                        if (ReactionUser.Roles.Contains(r16))
                            await guildUser.RemoveRoleAsync(r16);
                        else
                            await guildUser.AddRoleAsync(r16);
                    }
                    else if (reaction.Emote.Name == "😝")
                    {
                        var r17 = guild.Roles.FirstOrDefault(x => x.Name == "😝 Pozytywnie walnięty");

                        if (ReactionUser.Roles.Contains(r17))
                            await guildUser.RemoveRoleAsync(r17);
                        else
                            await guildUser.AddRoleAsync(r17);
                    }
                    else if (reaction.Emote.Name == "🤸")
                    {
                        var r18 = guild.Roles.FirstOrDefault(x => x.Name == "🤸 Kierownik imprezy");

                        if (ReactionUser.Roles.Contains(r18))
                            await guildUser.RemoveRoleAsync(r18);
                        else
                            await guildUser.AddRoleAsync(r18);
                    }
                    else if (reaction.Emote.Name == "🍞")
                    {
                        var r19 = guild.Roles.FirstOrDefault(x => x.Name == "🍞 Memiarz");

                        if (ReactionUser.Roles.Contains(r19))
                            await guildUser.RemoveRoleAsync(r19);
                        else
                            await guildUser.AddRoleAsync(r19);
                    }
                    else if (reaction.Emote.Name == "🌜")
                    {
                        var r20 = guild.Roles.FirstOrDefault(x => x.Name == "🌜 Nocny marek");

                        if (ReactionUser.Roles.Contains(r20))
                            await guildUser.RemoveRoleAsync(r20);
                        else
                            await guildUser.AddRoleAsync(r20);
                    }
                }
            }
        }

        public static async Task ReactionFun2(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.fun2)
            {
                var ReactionUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();
                var account = UserAccounts.GetAccount(reaction.User.Value);

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    var guildUser = (SocketGuildUser)reaction.User;

                    if (reaction.Emote.Name == "🌅")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "🌅 Ranny Ptaszek");

                        if (ReactionUser.Roles.Contains(r1))
                            await guildUser.RemoveRoleAsync(r1);
                        else
                            await guildUser.AddRoleAsync(r1);
                    }
                    else if (reaction.Emote.Name == "🍎")
                    {
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "🍎 Fit Człowiek");

                        if (ReactionUser.Roles.Contains(r2))
                            await guildUser.RemoveRoleAsync(r2);
                        else
                            await guildUser.AddRoleAsync(r2);
                    }
                    else if (reaction.Emote.Name == "😋")
                    {
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "😋 Wiecznie głodny");

                        if (ReactionUser.Roles.Contains(r3))
                            await guildUser.RemoveRoleAsync(r3);
                        else
                            await guildUser.AddRoleAsync(r3);
                    }
                    else if (reaction.Emote.Name == "😊")
                    {
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "😊 Miła osóbka");

                        if (ReactionUser.Roles.Contains(r4))
                            await guildUser.RemoveRoleAsync(r4);
                        else
                            await guildUser.AddRoleAsync(r4);
                    }
                    else if (reaction.Emote.Name == "👤")
                    {
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "👤 Samotnik");

                        if (ReactionUser.Roles.Contains(r5))
                            await guildUser.RemoveRoleAsync(r5);
                        else
                            await guildUser.AddRoleAsync(r5);
                    }
                    else if (reaction.Emote.Name == "🤔")
                    {
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "🤔 200IQ");

                        if (ReactionUser.Roles.Contains(r6))
                            await guildUser.RemoveRoleAsync(r6);
                        else
                            await guildUser.AddRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "🥊")
                    {
                        var r7 = guild.Roles.FirstOrDefault(x => x.Name == "🥊 Fajter");

                        if (ReactionUser.Roles.Contains(r7))
                            await guildUser.RemoveRoleAsync(r7);
                        else
                            await guildUser.AddRoleAsync(r7);
                    }
                    else if (reaction.Emote.Name == "😉")
                    {
                        var r8 = guild.Roles.FirstOrDefault(x => x.Name == "😉 Wyluzowany");

                        if (ReactionUser.Roles.Contains(r8))
                            await guildUser.RemoveRoleAsync(r8);
                        else
                            await guildUser.AddRoleAsync(r8);
                    }
                    else if (reaction.Emote.Name == "🛋")
                    {
                        var r9 = guild.Roles.FirstOrDefault(x => x.Name == "🛋 Projektant");

                        if (ReactionUser.Roles.Contains(r9))
                            await guildUser.RemoveRoleAsync(r9);
                        else
                            await guildUser.AddRoleAsync(r9);
                    }
                    else if (reaction.Emote.Name == "🖼")
                    {
                        var r10 = guild.Roles.FirstOrDefault(x => x.Name == "🖼 Grafik");

                        if (ReactionUser.Roles.Contains(r10))
                            await guildUser.RemoveRoleAsync(r10);
                        else
                            await guildUser.AddRoleAsync(r10);
                    }
                    else if (reaction.Emote.Name == "🎧")
                    {
                        var r11 = guild.Roles.FirstOrDefault(x => x.Name == "🎧 Muzyk");

                        if (ReactionUser.Roles.Contains(r11))
                            await guildUser.RemoveRoleAsync(r11);
                        else
                            await guildUser.AddRoleAsync(r11);
                    }
                    else if (reaction.Emote.Name == "📟")
                    {
                        var r12 = guild.Roles.FirstOrDefault(x => x.Name == "📟 Hacker");

                        if (ReactionUser.Roles.Contains(r12))
                            await guildUser.RemoveRoleAsync(r12);
                        else
                            await guildUser.AddRoleAsync(r12);
                    }
                    else if (reaction.Emote.Name == "🎟")
                    {
                        var r13 = guild.Roles.FirstOrDefault(x => x.Name == "🎟 Kolekcjoner");

                        if (ReactionUser.Roles.Contains(r13))
                            await guildUser.RemoveRoleAsync(r13);
                        else
                            await guildUser.AddRoleAsync(r13);
                    }
                    else if (reaction.Emote.Name == "🛠")
                    {
                        var r14 = guild.Roles.FirstOrDefault(x => x.Name == "🛠 Majster");

                        if (ReactionUser.Roles.Contains(r14))
                            await guildUser.RemoveRoleAsync(r14);
                        else
                            await guildUser.AddRoleAsync(r14);
                    }
                    else if (reaction.Emote.Name == "⛹")
                    {
                        var r15 = guild.Roles.FirstOrDefault(x => x.Name == "⛹ Sportowiec");

                        if (ReactionUser.Roles.Contains(r15))
                            await guildUser.RemoveRoleAsync(r15);
                        else
                            await guildUser.AddRoleAsync(r15);
                    }
                    else if (reaction.Emote.Name == "💅")
                    {
                        var r16 = guild.Roles.FirstOrDefault(x => x.Name == "💅 Model");

                        if (ReactionUser.Roles.Contains(r16))
                            await guildUser.RemoveRoleAsync(r16);
                        else
                            await guildUser.AddRoleAsync(r16);
                    }
                    else if (reaction.Emote.Name == "🛌")
                    {
                        var r17 = guild.Roles.FirstOrDefault(x => x.Name == "🛌 Śpioch");

                        if (ReactionUser.Roles.Contains(r17))
                            await guildUser.RemoveRoleAsync(r17);
                        else
                            await guildUser.AddRoleAsync(r17);
                    }
                    else if (reaction.Emote.Name == "⚱")
                    {
                        var r18 = guild.Roles.FirstOrDefault(x => x.Name == "⚱ Dzban");

                        if (ReactionUser.Roles.Contains(r18))
                            await guildUser.RemoveRoleAsync(r18);
                        else
                            await guildUser.AddRoleAsync(r18);
                    }
                    else if (reaction.Emote.Name == "➡")
                    {
                        var rUnverified = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 5/5");
                        var rUser = guild.Roles.FirstOrDefault(x => x.Name == "UŻYTKOWNIK");

                        await guildUser.RemoveRoleAsync(rUnverified);
                        await guildUser.AddRoleAsync(rUser);
                    }
                }
            }
        }

        public static async Task ReactionGambling(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.gambling)
            {
                //main vars
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();
                var UserToAddRoleTo = (SocketGuildUser)reaction.User;
                //accounts
                var GuildAccount = GuildAccounts.GetAccount(guild);
                var UserAccount = UserAccounts.GetAccount(reaction.User.Value);

                //msg sloty
                EmbedBuilder slots = new EmbedBuilder();
                slots.AddField("Sloty", $"```,```");
                slots.WithColor(Color.DarkBlue);
                //msg ruletka
                EmbedBuilder rulette = new EmbedBuilder();
                rulette.AddField("Ruletka", $"```,```");
                rulette.WithColor(Color.DarkGreen);
                //msg coinflip
                EmbedBuilder coinflip = new EmbedBuilder();
                coinflip.AddField("Coinflip", $"```,```");
                coinflip.WithColor(Color.Gold);

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                    //slots stuff
                    var o1 = "    _____       \n   /__   /      \n     /  /       \n    /__/        ".Split("\n");
                    var o2 = "   |\\           \n   \\|_\\_        \n    (_)_)       \n      (_)       ".Split("\n");
                    var o3 = "   __/^\\__      \n   \\  *  /      \n    >   <       \n   /.-^-.\\      ".Split("\n");
                    var o4 = "      )         \n    .-'-.       \n   (     )      \n    `-=-'       ".Split("\n");
                    var o5 = "      )         \n    .-'-.       \n   (/////)      \n    `-=-'       ".Split("\n");
                    var o6 = "    _____       \n   |=====|      \n   |B A R|      \n   |_____|      ".Split("\n");
                    var o7 = "     _o_        \n    (   )       \n    )   (       \n   '-'o'-'      ".Split("\n");

                    uint m1 = 2;
                    uint m2 = 4;
                    uint m3 = 8;
                    uint m4 = 10;
                    uint m5 = 15;
                    uint m6 = 20;
                    uint m7 = 25;

                    var figures = new List<string[]> { o1, o2, o3, o4, o5, o6, o7 };

                    Random rnd = new Random();
                    var n1 = rnd.Next(figures.Count());
                    var n2 = rnd.Next(figures.Count());
                    var n3 = rnd.Next(figures.Count());

                    var s1 = figures[n1];
                    var s2 = figures[n2];
                    var s3 = figures[n3];

                    StringBuilder sb = new StringBuilder("");

                    for (var i = 0; i < s1.Length && i < s2.Length && i < s3.Length; i++)
                    {
                        sb.Append($"{s1[i]} {s2[i]} {s3[i]}\n");
                    }

                    EmbedBuilder fslots = new EmbedBuilder();
                    fslots.AddField("🎰 JEDNORĘKI BANDYTA ", $"```yaml\n{sb}```");
                    fslots.AddField("Nagrody:", "\u0037\u20e3 x2 | 🍇 x4 | ⭐ x8 | 🍑 x10 | 🍊 x15 | 🍫 x20 | 🔔 x25", true);
                    fslots.AddField("Cennik:", "❤ 100 | 💛 500 | 💚 1000 | 💙 5000 | 💜 10 000 | 🖤 50 000 ", true);
                    fslots.WithColor(Color.DarkBlue);
                    //ruletka stuff
                    uint roulettemultiplier = 1;
                    uint option = 0;
                    uint userchoice = 0;
                    string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                    string colors = "";

                    var red = Emote.Parse("<:red:546427447797612546>");
                    var green = Emote.Parse("<:green:546426978820030464>");

                    EmbedBuilder frulette = new EmbedBuilder();
                    frulette.AddField("🏵 RULETKA ", $"\n{colors}");
                    frulette.AddField("Nagrody:", $"{red} x2 | ⬛ x2 │ {green} x25", true);
                    frulette.AddField("Cennik:", "❤ 100 | 💛 500 | 💚 1000 | 💙 5000 | 💜 10 000 | 🖤 50 000 ", true);
                    frulette.WithColor(Color.DarkGreen);

                    //coinflip stuff

                    //bones stuff

                    if (reaction.Emote.Name == "◀")
                    {
                        if (GuildAccount.GamblingPage == 1)
                        {
                            await msg.ModifyAsync(message =>
                            {
                                message.Content = "";
                                message.Embed = null;
                                message.Embed = slots.Build();
                            });
                            GuildAccount.GamblingPage = 3;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            await msg.ModifyAsync(message =>
                            {
                                message.Content = "";
                                message.Embed = null;
                                message.Embed = rulette.Build();
                            });
                            GuildAccount.GamblingPage = 1;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            await msg.ModifyAsync(message =>
                            {
                                message.Content = "";
                                message.Embed = null;
                                message.Embed = coinflip.Build();
                            });
                            GuildAccount.GamblingPage = 2;
                            GuildAccounts.SaveAccounts();
                        }
                    }
                    else if (reaction.Emote.Name == "▶")
                    {
                        if (GuildAccount.GamblingPage == 1)
                        {
                            await msg.ModifyAsync(message =>
                            {
                                message.Content = "";
                                message.Embed = null;
                                message.Embed = rulette.Build();
                            });
                            GuildAccount.GamblingPage = 2;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            await msg.ModifyAsync(message =>
                            {
                                message.Content = "";
                                message.Embed = null;
                                message.Embed = coinflip.Build();
                            });
                            GuildAccount.GamblingPage = 3;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            await msg.ModifyAsync(message =>
                            {
                                message.Content = "";
                                message.Embed = null;
                                message.Embed = slots.Build();
                            });
                            GuildAccount.GamblingPage = 1;
                            GuildAccounts.SaveAccounts();
                        }
                    }
                    else if (reaction.Emote.Name == "❤")
                    {
                        ulong bid = 100;

                        if (GuildAccount.GamblingPage == 1)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = fslots.Build();
                                });

                                ulong reward = 0;

                                // 3 liczby
                                if (s1 == s2 && s2 == s3)
                                {
                                    if (s1 == o1)
                                        reward = bid * m1;
                                    if (s1 == o2)
                                        reward = bid * m2;
                                    if (s1 == o3)
                                        reward = bid * m3;
                                    if (s1 == o4)
                                        reward = bid * m4;
                                    if (s1 == o5)
                                        reward = bid * m5;
                                    if (s1 == o6)
                                        reward = bid * m6;
                                    if (s1 == o7)
                                        reward = bid * m7;
                                }
                                // 2 liczby
                                else if (s1 == s2 || s1 == s3 || s2 == s3)
                                {
                                    if (s1 == o1 || s2 == o1)
                                        reward = bid * m1 / 2;
                                    if (s1 == o2 || s2 == o2)
                                        reward = bid * m2 / 2;
                                    if (s1 == o3 || s2 == o3)
                                        reward = bid * m3 / 2;
                                    if (s1 == o4 || s2 == o4)
                                        reward = bid * m4 / 2;
                                    if (s1 == o5 || s2 == o5)
                                        reward = bid * m5 / 2;
                                    if (s1 == o6 || s2 == o6)
                                        reward = bid * m6 / 2;
                                    if (s1 == o7 || s2 == o7)
                                        reward = bid * m7 / 2;
                                }

                                UserAccount.MoneyWallet += reward;

                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingRoulette(channel, reaction, msg, bid);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingCoinflip(channel, reaction, msg, bid);
                            }
                        }
                    }
                    else if (reaction.Emote.Name == "💛")
                    {
                        ulong bid = 500;

                        if (GuildAccount.GamblingPage == 1)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = fslots.Build();
                                });

                                ulong reward = 0;

                                // 3 liczby
                                if (s1 == s2 && s2 == s3)
                                {
                                    if (s1 == o1)
                                        reward = bid * m1;
                                    if (s1 == o2)
                                        reward = bid * m2;
                                    if (s1 == o3)
                                        reward = bid * m3;
                                    if (s1 == o4)
                                        reward = bid * m4;
                                    if (s1 == o5)
                                        reward = bid * m5;
                                    if (s1 == o6)
                                        reward = bid * m6;
                                    if (s1 == o7)
                                        reward = bid * m7;
                                }
                                // 2 liczby
                                else if (s1 == s2 || s1 == s3 || s2 == s3)
                                {
                                    if (s1 == o1 || s2 == o1)
                                        reward = bid * m1 / 2;
                                    if (s1 == o2 || s2 == o2)
                                        reward = bid * m2 / 2;
                                    if (s1 == o3 || s2 == o3)
                                        reward = bid * m3 / 2;
                                    if (s1 == o4 || s2 == o4)
                                        reward = bid * m4 / 2;
                                    if (s1 == o5 || s2 == o5)
                                        reward = bid * m5 / 2;
                                    if (s1 == o6 || s2 == o6)
                                        reward = bid * m6 / 2;
                                    if (s1 == o7 || s2 == o7)
                                        reward = bid * m7 / 2;
                                }

                                UserAccount.MoneyWallet += reward;

                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingRoulette(channel, reaction, msg, bid);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingCoinflip(channel, reaction, msg, bid);
                            }
                        }
                    }
                    else if (reaction.Emote.Name == "💚")
                    {
                        ulong bid = 1000;

                        if (GuildAccount.GamblingPage == 1)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = fslots.Build();
                                });

                                ulong reward = 0;

                                // 3 liczby
                                if (s1 == s2 && s2 == s3)
                                {
                                    if (s1 == o1)
                                        reward = bid * m1;
                                    if (s1 == o2)
                                        reward = bid * m2;
                                    if (s1 == o3)
                                        reward = bid * m3;
                                    if (s1 == o4)
                                        reward = bid * m4;
                                    if (s1 == o5)
                                        reward = bid * m5;
                                    if (s1 == o6)
                                        reward = bid * m6;
                                    if (s1 == o7)
                                        reward = bid * m7;
                                }
                                // 2 liczby
                                else if (s1 == s2 || s1 == s3 || s2 == s3)
                                {
                                    if (s1 == o1 || s2 == o1)
                                        reward = bid * m1 / 2;
                                    if (s1 == o2 || s2 == o2)
                                        reward = bid * m2 / 2;
                                    if (s1 == o3 || s2 == o3)
                                        reward = bid * m3 / 2;
                                    if (s1 == o4 || s2 == o4)
                                        reward = bid * m4 / 2;
                                    if (s1 == o5 || s2 == o5)
                                        reward = bid * m5 / 2;
                                    if (s1 == o6 || s2 == o6)
                                        reward = bid * m6 / 2;
                                    if (s1 == o7 || s2 == o7)
                                        reward = bid * m7 / 2;
                                }

                                UserAccount.MoneyWallet += reward;

                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingRoulette(channel, reaction, msg, bid);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingCoinflip(channel, reaction, msg, bid);
                            }
                        }
                    }
                    else if (reaction.Emote.Name == "💙")
                    {
                        ulong bid = 5000;

                        if (GuildAccount.GamblingPage == 1)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = fslots.Build();
                                });

                                ulong reward = 0;

                                // 3 liczby
                                if (s1 == s2 && s2 == s3)
                                {
                                    if (s1 == o1)
                                        reward = bid * m1;
                                    if (s1 == o2)
                                        reward = bid * m2;
                                    if (s1 == o3)
                                        reward = bid * m3;
                                    if (s1 == o4)
                                        reward = bid * m4;
                                    if (s1 == o5)
                                        reward = bid * m5;
                                    if (s1 == o6)
                                        reward = bid * m6;
                                    if (s1 == o7)
                                        reward = bid * m7;
                                }
                                // 2 liczby
                                else if (s1 == s2 || s1 == s3 || s2 == s3)
                                {
                                    if (s1 == o1 || s2 == o1)
                                        reward = bid * m1 / 2;
                                    if (s1 == o2 || s2 == o2)
                                        reward = bid * m2 / 2;
                                    if (s1 == o3 || s2 == o3)
                                        reward = bid * m3 / 2;
                                    if (s1 == o4 || s2 == o4)
                                        reward = bid * m4 / 2;
                                    if (s1 == o5 || s2 == o5)
                                        reward = bid * m5 / 2;
                                    if (s1 == o6 || s2 == o6)
                                        reward = bid * m6 / 2;
                                    if (s1 == o7 || s2 == o7)
                                        reward = bid * m7 / 2;
                                }

                                UserAccount.MoneyWallet += reward;

                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingRoulette(channel, reaction, msg, bid);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingCoinflip(channel, reaction, msg, bid);
                            }
                        }
                    }
                    else if (reaction.Emote.Name == "💜")
                    {
                        ulong bid = 10000;

                        if (GuildAccount.GamblingPage == 1)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = fslots.Build();
                                });

                                ulong reward = 0;

                                // 3 liczby
                                if (s1 == s2 && s2 == s3)
                                {
                                    if (s1 == o1)
                                        reward = bid * m1;
                                    if (s1 == o2)
                                        reward = bid * m2;
                                    if (s1 == o3)
                                        reward = bid * m3;
                                    if (s1 == o4)
                                        reward = bid * m4;
                                    if (s1 == o5)
                                        reward = bid * m5;
                                    if (s1 == o6)
                                        reward = bid * m6;
                                    if (s1 == o7)
                                        reward = bid * m7;
                                }
                                // 2 liczby
                                else if (s1 == s2 || s1 == s3 || s2 == s3)
                                {
                                    if (s1 == o1 || s2 == o1)
                                        reward = bid * m1 / 2;
                                    if (s1 == o2 || s2 == o2)
                                        reward = bid * m2 / 2;
                                    if (s1 == o3 || s2 == o3)
                                        reward = bid * m3 / 2;
                                    if (s1 == o4 || s2 == o4)
                                        reward = bid * m4 / 2;
                                    if (s1 == o5 || s2 == o5)
                                        reward = bid * m5 / 2;
                                    if (s1 == o6 || s2 == o6)
                                        reward = bid * m6 / 2;
                                    if (s1 == o7 || s2 == o7)
                                        reward = bid * m7 / 2;
                                }

                                UserAccount.MoneyWallet += reward;

                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingRoulette(channel, reaction, msg, bid);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingCoinflip(channel, reaction, msg, bid);
                            }
                        }
                    }
                    else if (reaction.Emote.Name == "🖤")
                    {
                        ulong bid = 50000;

                        if (GuildAccount.GamblingPage == 1)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = fslots.Build();
                                });

                                ulong reward = 0;

                                // 3 liczby
                                if (s1 == s2 && s2 == s3)
                                {
                                    if (s1 == o1)
                                        reward = bid * m1;
                                    if (s1 == o2)
                                        reward = bid * m2;
                                    if (s1 == o3)
                                        reward = bid * m3;
                                    if (s1 == o4)
                                        reward = bid * m4;
                                    if (s1 == o5)
                                        reward = bid * m5;
                                    if (s1 == o6)
                                        reward = bid * m6;
                                    if (s1 == o7)
                                        reward = bid * m7;
                                }
                                // 2 liczby
                                else if (s1 == s2 || s1 == s3 || s2 == s3)
                                {
                                    if (s1 == o1 || s2 == o1)
                                        reward = bid * m1 / 2;
                                    if (s1 == o2 || s2 == o2)
                                        reward = bid * m2 / 2;
                                    if (s1 == o3 || s2 == o3)
                                        reward = bid * m3 / 2;
                                    if (s1 == o4 || s2 == o4)
                                        reward = bid * m4 / 2;
                                    if (s1 == o5 || s2 == o5)
                                        reward = bid * m5 / 2;
                                    if (s1 == o6 || s2 == o6)
                                        reward = bid * m6 / 2;
                                    if (s1 == o7 || s2 == o7)
                                        reward = bid * m7 / 2;
                                }

                                UserAccount.MoneyWallet += reward;

                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 2)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingRoulette(channel, reaction, msg, bid);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, bid);
                            if (BalanceCheck == false)
                                return;
                            else
                            {
                                _ = HandleReactionGamblingCoinflip(channel, reaction, msg, bid);
                            }

                        }
                    }
                }
            }
        }

        public static async Task ReactionCashmashine(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.bank)
            {
                var msg = await cache.GetOrDownloadAsync();

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "📥")//wypłata do portfela
                    {
                        _ = HandleReactionCashmashineAsyncWithdraw(channel, reaction);

                    }
                    else if (reaction.Emote.Name == "📤")//wpłata na konto
                    {
                        _ = HandleReactionCashmashineAsyncDeposit(channel, reaction);
                    }
                    else if (reaction.Emote.Name == "🆓")//Daily money
                    {
                        var result = Daily.GetDaily(reaction.User.Value);
                        if (result.Success)
                        {
                            var MessageSuccess = await channel.SendMessageAsync(Messages.BankDailySuccess(reaction.User.Value));
                            await Helpers.RemoveMessage(MessageSuccess);
                        }
                        else
                        {
                            string timeSpanString = string.Format("{0:%h} godzin {0:%m} minut {0:%s} sekund", result.RefreshTimeSpan);
                            var MessageError = await channel.SendMessageAsync(Messages.BankDailyError(reaction.User.Value, timeSpanString));
                            await Helpers.RemoveMessage(MessageError);
                        }
                    }
                    else if (reaction.Emote.Name == "💳")//balance check
                    {
                        var UserAccount = UserAccounts.GetAccount(reaction.User.Value);
                        string MoneyAccount = UserAccount.MoneyAccount.ToString();
                        string MoneyWallet = UserAccount.MoneyWallet.ToString();
                        var MessageReturn = await channel.SendMessageAsync(Messages.BankUserBalance(reaction.User.Value, MoneyAccount, MoneyWallet));
                        await Helpers.RemoveMessage(MessageReturn, 4);
                    }
                }
            }
        }

        private static async Task HandleReactionCashmashineAsyncWithdraw(ISocketMessageChannel channel, SocketReaction reaction)
        {
            //variables
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);
            ulong x;
            //initial message
            var msg1 = await channel.SendMessageAsync(Messages.BankQuestionWithdraw);
            //awaiting users message
            var result = await AwaitForUserMessage.AwaitMessage(reaction.UserId, channel.Id, 5000);
            //Checking if its timeout
            if(result is null)
            {
                var msg2 = await channel.SendMessageAsync(Messages.BankErrorOutOfTime);
                await Helpers.RemoveMessage(msg2);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            string value = result.Content;

            if (!value.Any(z => Char.IsDigit(z)))
            {
                var msg3 = await channel.SendMessageAsync(Messages.BankErrorNoLetters);
                await Helpers.RemoveMessage(msg3);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            bool TryParseResult = await Helpers.TryToParse(value);
            if (TryParseResult is true)
            {
                x = ulong.Parse(value);
            }
            else
            {
                var msg4 = await channel.SendMessageAsync(Messages.BankErrorNoLetters);
                await Helpers.RemoveMessage(msg4);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            if (x > UserAccount.MoneyAccount)
            {
                var msg5 = await channel.SendMessageAsync(Messages.BankErrorInsuficientFoundsWithdraw);
                await Helpers.RemoveMessage(msg5);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }
            var msg6 = await channel.SendMessageAsync(Messages.BankSuccessWithdraw(x));
            await Helpers.RemoveMessage(msg6);
            await Helpers.RemoveMessage((IUserMessage)result, 0);
            await Helpers.RemoveMessage(msg1, 0);
            //wypłaca
            UserAccount.MoneyAccount -= x;
            UserAccount.MoneyWallet += x;
            UserAccounts.SaveAccounts();
        }

        private static async Task HandleReactionCashmashineAsyncDeposit(ISocketMessageChannel channel, SocketReaction reaction)
        {
            //variables
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);
            ulong x;
            //initial message
            var msg1 = await channel.SendMessageAsync(Messages.BankQuestionDeposit);
            //awaiting users message
            var result = await AwaitForUserMessage.AwaitMessage(reaction.UserId, channel.Id, 5000);
            //Checking if its timeout
            if (result is null)
            {
                var msg2 = await channel.SendMessageAsync(Messages.BankErrorOutOfTime);
                await Helpers.RemoveMessage(msg2);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            string value = result.Content;

            if (!value.Any(z => Char.IsDigit(z)))
            {
                var msg3 = await channel.SendMessageAsync(Messages.BankErrorNoLetters);
                await Helpers.RemoveMessage(msg3);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            bool TryParseResult = await Helpers.TryToParse(value);
            if(TryParseResult is true)
            {
                x = ulong.Parse(value);
            }
            else
            {
                var msg4 = await channel.SendMessageAsync(Messages.BankErrorNoLetters);
                await Helpers.RemoveMessage(msg4);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            if (x > UserAccount.MoneyWallet)
            {
                var msg5 = await channel.SendMessageAsync(Messages.BankErrorInsuficientFoundsDeposit);
                await Helpers.RemoveMessage(msg5);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }
            var msg6 = await channel.SendMessageAsync(Messages.BankSuccessDeposit(x));
            await Helpers.RemoveMessage(msg6);
            await Helpers.RemoveMessage((IUserMessage)result, 0);
            await Helpers.RemoveMessage(msg1, 0);
            //wypłaca
            UserAccount.MoneyWallet -= x;
            UserAccount.MoneyAccount += x;
            UserAccounts.SaveAccounts();
        }

        private static async Task HandleReactionGamblingRoulette(ISocketMessageChannel channel, SocketReaction reaction, IUserMessage msg, ulong bid)
        {
            //main vars
            var guildChannel = channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            //accounts
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);

            //msg ruletka
            EmbedBuilder rulette = new EmbedBuilder();
            rulette.AddField("Ruletka", $"```,```");
            rulette.WithColor(Color.DarkGreen);

            //rulette stuff
            uint roulettemultiplier = 1;
            uint option = 0;
            uint userchoice = 0;
            string depmessage = "㊙ Przepraszam, wystąpił błąd.";
            string colors = "";

            var red = Emote.Parse("<:red:546427447797612546>");
            var green = Emote.Parse("<:green:546426978820030464>");

            Random rndom = new Random();
            var r = rndom.Next(1, 100);

            if (r < 49)
            {
                roulettemultiplier = 2;
                option = 1;
                colors = $"{red}{red}:black_large_square::black_large_square:{red}{red}║:black_large_square::black_large_square:║{red}{red}:black_large_square::black_large_square:{red}{red}\n{red}{red}:black_large_square::black_large_square:{red}{red}║:black_large_square::black_large_square:║{red}{red}:black_large_square::black_large_square:{red}{red}";
            }
            else if (r > 49 && r < 99)
            {
                option = 2;
                roulettemultiplier = 2;
                colors = $":black_large_square::black_large_square:{red}{red}:black_large_square::black_large_square:║{red}{red}║:black_large_square::black_large_square:{red}{red}:black_large_square::black_large_square:\n:black_large_square::black_large_square:{red}{red}:black_large_square::black_large_square:║{red}{red}║:black_large_square::black_large_square:{red}{red}:black_large_square::black_large_square:";
            }
            else
            {
                option = 3;
                roulettemultiplier = 25;
                colors = $":black_large_square::black_large_square:{red}{red}:black_large_square::black_large_square:║{green}{green}║{red}{red}:black_large_square::black_large_square:{red}{red}\n:black_large_square::black_large_square:{red}{red}:black_large_square::black_large_square:║{green}{green}║{red}{red}:black_large_square::black_large_square:{red}{red}";
            }

            EmbedBuilder frulette = new EmbedBuilder();
            frulette.AddField("🏵 RULETKA ", $"\n{colors}");
            frulette.AddField("Nagrody:", $"{red} x2 | ⬛ x2 │ {green} x25", true);
            frulette.AddField("Cennik:", "❤ 100 | 💛 500 | 💚 1000 | 💙 5000 | 💜 10 000 | 🖤 50 000 ", true);
            frulette.WithColor(Color.DarkGreen);

            //initial message
            var msg1 = await channel.SendMessageAsync($"**Wybierz kolor:**\n{red} - `red` / `r` / `czerwony` / `czerw`\n:black_large_square: - `black` / `b` / `czarny` / `czar`\n{green} - `green` / `g` / `zielony` / `ziel`");
            //awaiting users message
            var result = await AwaitForUserMessage.AwaitMessage(reaction.UserId, channel.Id, 5000);
            //Checking if its timeout
            if (result is null)
            {
                var msg2 = await channel.SendMessageAsync($"{Messages.wrong} Twój czas na wybór minął. Pieniądze nie zostały pobrane. Spróbuj ponownie.");
                await Helpers.RemoveMessage(msg2);
                await Helpers.RemoveMessage(msg1, 0);
                return;
            }

            Global.GamblingRouletteChoice = result.Content;

            if (Global.GamblingRouletteChoice == "b" || Global.GamblingRouletteChoice == "black" || Global.GamblingRouletteChoice == "czarny" || Global.GamblingRouletteChoice == "czar")
                userchoice = 1;
            else if (Global.GamblingRouletteChoice == "r" || Global.GamblingRouletteChoice == "red" || Global.GamblingRouletteChoice == "czerwony" || Global.GamblingRouletteChoice == "czerw")
                userchoice = 2;
            else if (Global.GamblingRouletteChoice == "g" || Global.GamblingRouletteChoice == "green" || Global.GamblingRouletteChoice == "zielony" || Global.GamblingRouletteChoice == "ziel")
                userchoice = 3;

            string ChosenColor = "";
            string PickedColor = "";

            if (userchoice == 1)
                ChosenColor = ":black_large_square:";
            else if (userchoice == 2)
                ChosenColor = $"{red}";
            else if (userchoice == 3)
                ChosenColor = $"{green}";

            if (option == 1)
                PickedColor = ":black_large_square:";
            else if (option == 2)
                PickedColor = $"{red}";
            else if (option == 3)
                PickedColor = $"{green}";

            if (userchoice == 0)
            {
                await Helpers.RemoveMessage(msg1, 0);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                depmessage = $"{Messages.wrong} Nie ma takiej opcji. Pieniądze nie zostały pobrane. Spróbuj ponownie.";
                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                await Helpers.RemoveMessage(MsgToRemove, 5);
                return;
            }
            else
            {
                await Helpers.RemoveMessage(msg1, 0);
                await Helpers.RemoveMessage((IUserMessage)result, 0);
                var msg6 = await channel.SendMessageAsync($"{Messages.check} Pomyślnie wybrano kolor {ChosenColor}. Kręcę ruletką!");
                await Helpers.RemoveMessage(msg6);
            }

            UserAccount.MoneyWallet -= bid;

            await msg.ModifyAsync(message =>
            {
                message.Content = $"";
                message.Embed = null;
                message.Embed = frulette.Build();
            });

            ulong reward = bid * roulettemultiplier;

            string comparison = $"**Wylosowany kolor:** {PickedColor}\n**Wybrałeś:** {ChosenColor}";
            var comp = await channel.SendMessageAsync(comparison);
            await Task.Delay(1500);

            if (option == userchoice)
            {
                UserAccount.MoneyWallet += reward;
                depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                await Helpers.RemoveMessage(comp, 3);
                await Helpers.RemoveMessage(MsgToRemove, 1);
            }
            else
            {
                depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                await Helpers.RemoveMessage(comp, 3);
                await Helpers.RemoveMessage(MsgToRemove, 1);
            }
        }

        private static async Task HandleReactionGamblingCoinflip(ISocketMessageChannel channel, SocketReaction reaction, IUserMessage msg, ulong bid)
        {
            //main vars
            var guildChannel = channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            //accounts
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var UserAccount = UserAccounts.GetAccount(reaction.User.Value);

            //msg coinflip
            EmbedBuilder rulette = new EmbedBuilder();
            rulette.AddField("Coinflip", $"```,```");
            rulette.WithColor(Color.Gold);

            //coinflip stuff
            string depmessage = "㊙ Przepraszam, wystąpił błąd.";

            string pic = "";
            string HorT = "";

            string heads = "https://i.imgur.com/JC9V4mn.png";
            string tails = "https://i.imgur.com/rnonsta.png";
            string drawing = "https://thumbs.gfycat.com/BabyishShrillKomododragon-small.gif";

            Random rndom = new Random();
            var r = rndom.Next(0, 2);

            if (r == 1)
            {
                pic = heads;
                HorT = "Orzeł";
            }
            else
            {
                pic = tails;
                HorT = "Reszka";
            }


            EmbedBuilder f1coinflip = new EmbedBuilder();
            f1coinflip.WithThumbnailUrl(drawing);
            f1coinflip.WithTitle($"{Messages.coin} Coinflip");
            f1coinflip.WithDescription("**Losowanie...**");
            f1coinflip.AddField("Nagrody:", $"{Messages.coin} Orzeł - wygrana, {Messages.coin} Reszka - przegrana", true);
            f1coinflip.AddField("Cennik:", "❤ 100 | 💛 500 | 💚 1000 | 💙 5000 | 💜 10 000 | 🖤 50 000 ", true);
            f1coinflip.WithColor(Color.Gold);

            await msg.ModifyAsync(message =>
            {
                message.Content = $"";
                message.Embed = null;
                message.Embed = f1coinflip.Build();
            });

            UserAccount.MoneyWallet -= bid;

            ulong reward = bid * 2;

            await Task.Delay(2000);

            EmbedBuilder f2coinflip = new EmbedBuilder();
            f2coinflip.WithThumbnailUrl(pic);
            f2coinflip.WithTitle($"{Messages.coin} Coinflip");
            f2coinflip.WithDescription($"\n**Wypada:** {HorT}\n");
            f2coinflip.AddField("Nagrody:", $"🏆 Orzeł - wygrana || 😟 Reszka - przegrana\n", true);
            f2coinflip.AddField("Cennik:", "❤ 100 | 💛 500 | 💚 1000 | 💙 5000 | 💜 10 000 | 🖤 50 000 ", true);
            f2coinflip.WithColor(Color.Gold);

            await msg.ModifyAsync(message =>
            {
                message.Content = $"";
                message.Embed = null;
                message.Embed = f2coinflip.Build();
            });

            if (r == 1)
            {
                UserAccount.MoneyWallet += reward;
                depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wypada orzeł, wygrałeś {reward} {Messages.coin}";
                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                await Helpers.RemoveMessage(MsgToRemove);
            }
            else
            {
                depmessage = $"😢 Niestety {reaction.User.Value.Username}, wypada reszka. Nic nie wygrałeś. Spróbuj ponownie.";
                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                await Helpers.RemoveMessage(MsgToRemove);
            }
        }

        public static async Task ReactionMeme(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.meme)
            {
                var msg = await cache.GetOrDownloadAsync();

                string MemeUrl = "";
                string MemeAlt = "";

                try
                {
                    var tuple = await Helpers.GetMeme();
                    MemeUrl = tuple.url;
                    MemeAlt = tuple.alt;
                }
                catch(Exception e)
                {

                }

                string JokeUrl = await Helpers.GetJoke();

                EmbedBuilder ebMeme = new EmbedBuilder();
                ebMeme.WithTitle(MemeAlt);
                ebMeme.WithImageUrl(MemeUrl);
                ebMeme.WithColor(Color.Gold);

                EmbedBuilder ebJoke = new EmbedBuilder();
                ebJoke.WithTitle("");
                ebJoke.WithImageUrl(JokeUrl);
                ebJoke.WithColor(Color.Gold);

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "🤣")
                    {
                        await msg.ModifyAsync(mmessage =>
                        {
                            mmessage.Content = "";
                            mmessage.Embed = null;
                            mmessage.Embed = ebMeme.Build();
                        });
                    }
                    else if (reaction.Emote.Name == "🍞")
                    {
                        await msg.ModifyAsync(mmessage =>
                        {
                            mmessage.Content = "";
                            mmessage.Embed = null;
                            mmessage.Embed = ebJoke.Build();
                        });
                    }
                }
            }
        }

        public static async Task ReactionSklep(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.shop)
            {
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();
                var UserToAddRoleTo = (SocketGuildUser)reaction.User;
                //accounts
                var GuildAccount = GuildAccounts.GetAccount(guild);
                var UserAccount = UserAccounts.GetAccount(reaction.User.Value);
                //emojis
                var coin = Emote.Parse("<:coin:462351821910835200>");
                var vip = Emote.Parse("<:supervip:462351820501549066>");
                var svip = Emote.Parse("<:ultravip:462351820308873246>");
                var sponsor = Emote.Parse("<:sponsor:462351820006883340>");
                //roles
                var RoleVIP = guild.Roles.FirstOrDefault(x => x.Name == "VIP");
                var RoleSVIP = guild.Roles.FirstOrDefault(x => x.Name == "SVIP");
                var RoleMusic = guild.Roles.FirstOrDefault(x => x.Name == "🎵");
                var RoleNickname = guild.Roles.FirstOrDefault(x => x.Name == "🏷️");
                var RoleAkinator = guild.Roles.FirstOrDefault(x => x.Name == "👳");
                //Animals - A
                var RoleA1 = guild.Roles.FirstOrDefault(x => x.Name == "🐟");
                var RoleA2 = guild.Roles.FirstOrDefault(x => x.Name == "🐹");
                var RoleA3 = guild.Roles.FirstOrDefault(x => x.Name == "🐶");
                var RoleA4 = guild.Roles.FirstOrDefault(x => x.Name == "🐱");
                var RoleA5 = guild.Roles.FirstOrDefault(x => x.Name == "🐴");
                var RoleA6 = guild.Roles.FirstOrDefault(x => x.Name == "🐧");
                var RoleA7 = guild.Roles.FirstOrDefault(x => x.Name == "🐼");
                var RoleA8 = guild.Roles.FirstOrDefault(x => x.Name == "🦅");
                var RoleA9 = guild.Roles.FirstOrDefault(x => x.Name == "🦄");
                //Vechicles - V
                var RoleV1 = guild.Roles.FirstOrDefault(x => x.Name == "🚲");
                var RoleV2 = guild.Roles.FirstOrDefault(x => x.Name == "🚗");
                var RoleV3 = guild.Roles.FirstOrDefault(x => x.Name == "⛵");
                var RoleV4 = guild.Roles.FirstOrDefault(x => x.Name == "🚂");
                var RoleV5 = guild.Roles.FirstOrDefault(x => x.Name == "🏍️");
                var RoleV6 = guild.Roles.FirstOrDefault(x => x.Name == "🏎️");
                var RoleV7 = guild.Roles.FirstOrDefault(x => x.Name == "🚁");
                var RoleV8 = guild.Roles.FirstOrDefault(x => x.Name == "✈️");
                var RoleV9 = guild.Roles.FirstOrDefault(x => x.Name == "🚀");



                EmbedBuilder ebShop1 = new EmbedBuilder();
                ebShop1.WithAuthor("SKLEP - Ogólne");
                ebShop1.Author.WithIconUrl("http://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Shop-icon.png");
                ebShop1.WithDescription("Strona 1/3");
                ebShop1.AddField($":one: RANGA VIP {vip}", $"{coin} 5000", true);
                ebShop1.AddField($":two: RANGA SVIP {svip}", $"{coin} 10 000", true);
                ebShop1.AddField($":three: WYBÓR MUZYKI :musical_note:", $"{coin} 5000", true);
                ebShop1.AddField($":four: AKINATOR 👳", $"{coin} 5000", true);
                ebShop1.AddField($":five: ZMIANA NICKU :label:", $"{coin} 1000", true);
                ebShop1.AddField($":six: UNWARN ⚠", $"{coin} 5000", true);
                ebShop1.AddField($":seven: MYSTERY BOX 1 📗", $"{coin} 1000", true);
                ebShop1.AddField($":eight: MYSTERY BOX 2 📘", $"{coin} 2000", true);
                ebShop1.AddField($":nine: MYSTERY BOX 3 📕", $"{coin} 3000", true);
                ebShop1.WithFooter("👆 Kliknij w odpowiednią reakcje by zakupić produkt. Użyj strzałek ◀ ▶ żeby zmienić stronę.");
                ebShop1.WithColor(new Color(34, 166, 192));

                EmbedBuilder ebShop2 = new EmbedBuilder();
                ebShop2.WithAuthor("SKLEP - Zwierzaki");
                ebShop2.Author.WithIconUrl("http://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Shop-icon.png");
                ebShop2.WithDescription("Strona 2/3");
                ebShop2.AddField($":one: RYBKA 🐟", $"{coin} 500", true);
                ebShop2.AddField($":two: CHOMICZEK 🐹", $"{coin} 1000", true);
                ebShop2.AddField($":three: PIESEK 🐶", $"{coin} 2000", true);
                ebShop2.AddField($":four: KOTEK 🐱", $"{coin} 2000", true);
                ebShop2.AddField($":five: KOŃ 🐴", $"{coin} 4000", true);
                ebShop2.AddField($":six: PINGWINEK 🐧", $"{coin} 6000", true);
                ebShop2.AddField($":seven: PANDA 🐼", $"{coin} 10 000", true);
                ebShop2.AddField($":eight: ORZEŁ 🦅", $"{coin} 20 000", true);
                ebShop2.AddField($":nine: JEDNOROŻEC 🦄", $"{coin} 50 000", true);
                ebShop2.WithFooter("👆 Kliknij w odpowiednią reakcje by zakupić produkt. Użyj strzałek ◀ ▶ żeby zmienić stronę.");
                ebShop2.WithColor(new Color(34, 166, 192));

                EmbedBuilder ebShop3 = new EmbedBuilder();
                ebShop3.WithAuthor("SKLEP - Pojazdy");
                ebShop3.Author.WithIconUrl("http://icons.iconarchive.com/icons/webalys/kameleon.pics/512/Shop-icon.png");
                ebShop3.WithDescription("Strona 3/3");
                ebShop3.AddField($":one: ROWER 🚲", $"{coin} 500", true);
                ebShop3.AddField($":two: SAMOCHÓD 🚗", $"{coin} 3000", true);
                ebShop3.AddField($":three: ŻAGLÓWKA ⛵", $"{coin} 5000", true);
                ebShop3.AddField($":four: POCIĄG 🚂", $"{coin} 7500", true);
                ebShop3.AddField($":five: MOTOCYKL 🏍️", $"{coin} 10 000", true);
                ebShop3.AddField($":six: WYŚCIGÓWKA 🏎️", $"{coin} 10 000", true);
                ebShop3.AddField($":seven: HELIKOPTER 🚁", $"{coin} 15 000", true);
                ebShop3.AddField($":eight: SAMOLOT ✈️", $"{coin} 25 000", true);
                ebShop3.AddField($":nine: RAKIETA 🚀", $"{coin} 50 000", true);
                ebShop3.WithFooter("👆 Kliknij w odpowiednią reakcje by zakupić produkt. Użyj strzałek ◀ ▶ żeby zmienić stronę.");
                ebShop3.WithColor(new Color(34, 166, 192));

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "◀")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = "";
                                mmessage.Embed = null;
                                mmessage.Embed = ebShop3.Build();
                            });
                            GuildAccount.ShopPage = 3;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = "";
                                mmessage.Embed = null;
                                mmessage.Embed = ebShop1.Build();
                            });
                            GuildAccount.ShopPage = 1;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = "";
                                mmessage.Embed = null;
                                mmessage.Embed = ebShop2.Build();
                            });
                            GuildAccount.ShopPage = 2;
                            GuildAccounts.SaveAccounts();
                        }
                    }
                    else if (reaction.Emote.Name == "▶")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = "";
                                mmessage.Embed = null;
                                mmessage.Embed = ebShop2.Build();
                            });
                            GuildAccount.ShopPage = 2;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = "";
                                mmessage.Embed = null;
                                mmessage.Embed = ebShop3.Build();
                            });
                            GuildAccount.ShopPage = 3;
                            GuildAccounts.SaveAccounts();
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = "";
                                mmessage.Embed = null;
                                mmessage.Embed = ebShop1.Build();
                            });
                            GuildAccount.ShopPage = 1;
                            GuildAccounts.SaveAccounts();
                        }
                    }
                    else if (reaction.Emote.Name == "\u0031\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 5000;
                            string item = "RANGA VIP";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleVIP, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleVIP);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 500;
                            string item = "RYBKĘ 🐟";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA1, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA1);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 500;
                            string item = "ROWER 🚲";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV1, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV1);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0032\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 10000;
                            string item = "RANGA SVIP";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleSVIP, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleSVIP);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 1000;
                            string item = "CHOMICZKA 🐹";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA2, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA2);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 3000;
                            string item = "SAMOCHÓD 🚗";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV2, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV2);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0033\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 5000;
                            string item = "MUZYKA";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleMusic, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleMusic);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 2000;
                            string item = "PIESKA 🐶";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA3, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA3);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 5000;
                            string item = "ŻAGLÓWKA ⛵";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV3, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV3);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0034\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 5000;
                            string item = "AKINATOR";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleAkinator, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleAkinator);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 2000;
                            string item = "KOTKA 🐱";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA4, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA4);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 7500;
                            string item = "POCIĄG 🚂";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV4, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV4);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0035\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 1000;
                            string item = "ZMIANA NICKU";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleNickname, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleNickname);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 4000;
                            string item = "KONIKA 🐴";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA5, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA5);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 10000;
                            string item = "MOTOCYKL 🏍️";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV5, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV5);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0036\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 5000;
                            string item = "UNWARN ⚠";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has more than 0 warn
                            if (UserAccount.Warns == 0)
                            {
                                var ErrorMessage = await channel.SendMessageAsync(Messages.ShopEconomyWarnsError(reaction.User.Value, UserAccount.Warns));
                                await Helpers.RemoveMessage(ErrorMessage, 4);
                                return;
                            }
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccount.Warns -= 1;
                            UserAccounts.SaveAccounts();
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 6000;
                            string item = "PINGWINKA 🐧";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA6, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA6);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 10000;
                            string item = "WYŚCIGÓWKA 🏎️";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV6, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV6);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0037\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 1000;
                            string item = "MYSTERY BOX 1 📗";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            //MB1
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);

                            string reward = EconomyService.MysteryBox1(guild, reaction).Result;
                            string ReturnMessage;

                            if (reward == "0")
                                ReturnMessage = "**🎁 W PUDEŁKU NIC NIE MA 😟**";
                            else
                                ReturnMessage = $"🎁 W PUDEŁKU JEST: **{reward}**";

                            var msgtormv = await channel.SendMessageAsync(ReturnMessage);
                            await Helpers.RemoveMessage(msgtormv);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 10000;
                            string item = "PANDE 🐼";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA7, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA7);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 15000;
                            string item = "HELIKOPTER 🚁";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV7, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV7);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0038\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 2000;
                            string item = "MYSTERY BOX 2 📘";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            //MB1
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);

                            string reward = EconomyService.MysteryBox2(guild, reaction).Result;
                            string ReturnMessage;

                            if (reward == "0")
                                ReturnMessage = "**🎁 W PUDEŁKU NIC NIE MA 😟**";
                            else
                                ReturnMessage = $"🎁 W PUDEŁKU JEST: **{reward}**";

                            var msgtormv = await channel.SendMessageAsync(ReturnMessage);
                            await Helpers.RemoveMessage(msgtormv);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 20000;
                            string item = "ORZEŁKA 🦅";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA8, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA8);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 25000;
                            string item = "SAMOLOT ✈️";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV8, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV8);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                    else if (reaction.Emote.Name == "\u0039\u20e3")
                    {
                        if (GuildAccount.ShopPage == 1)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 3000;
                            string item = "MYSTERY BOX 3 📕";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            //MB1
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);

                            string reward = EconomyService.MysteryBox3(guild, reaction).Result;
                            string ReturnMessage;

                            if (reward == "0")
                                ReturnMessage = "**🎁 W PUDEŁKU NIC NIE MA 😟**";
                            else
                                ReturnMessage = $"🎁 W PUDEŁKU ZNAJDUJESZ: **{reward}**";

                            var msgtormv = await channel.SendMessageAsync(ReturnMessage);
                            await Helpers.RemoveMessage(msgtormv);
                        }
                        else if (GuildAccount.ShopPage == 2)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 50000;
                            string item = "JEDNOROŻCA 🦄";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleA9, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleA9);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                        else if (GuildAccount.ShopPage == 3)
                        {
                            //removeing reaction
                            await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                            //variables
                            ulong price = 50000;
                            string item = "RAKIETA 🚀";
                            //Checking if user has enough money
                            var BalanceCheck = await Helpers.BalanceCheck(reaction.User.Value, channel, price);
                            if (BalanceCheck == false)
                                return;
                            //Checking if user has this role already
                            var HasRoleChceck = await Helpers.HasRoleCheck((SocketGuildUser)reaction.User.Value, channel, RoleV9, item);
                            if (HasRoleChceck == false)
                                return;
                            //If not doing this:
                            UserAccount.MoneyWallet -= price;
                            UserAccounts.SaveAccounts();
                            await UserToAddRoleTo.AddRoleAsync(RoleV9);
                            var SuccessMessage = await channel.SendMessageAsync(Messages.ShopPurchaseCompleated(reaction.User.Value, item, price));
                            await Helpers.RemoveMessage(SuccessMessage, 4);
                        }
                    }
                }
            }
        }

        public static async Task ReactionPlec(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.gender)
            {
                var ReactionUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();

                if (reaction.User.Value.IsBot)
                {
                    return;
                }
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);
                    var guildUser = (SocketGuildUser)reaction.User;

                    if (reaction.Emote.Name == "🚹")
                    {
                        var AddRole = guild.Roles.FirstOrDefault(x => x.Name == "♂️");
                        var DelRole = guild.Roles.FirstOrDefault(x => x.Name == "♀️");

                        await guildUser.AddRoleAsync(AddRole);
                        await guildUser.RemoveRoleAsync(DelRole);
                    }
                    else if(reaction.Emote.Name == "🚺")
                    {
                        var AddRole = guild.Roles.FirstOrDefault(x => x.Name == "♀️");
                        var DelRole = guild.Roles.FirstOrDefault(x => x.Name == "♂️");

                        await guildUser.AddRoleAsync(AddRole);
                        await guildUser.RemoveRoleAsync(DelRole);
                    }
                    else if (reaction.Emote.Name == "➡")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 2/5");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 3/5");
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.AddRoleAsync(r2);
                    }
                }
            }
        }

        public static async Task ReactionReg(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.rules)
            {
                var guildUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();
                var nie = Emote.Parse("<:WrongMark:460770239286870017>");
                var tak = Emote.Parse("<:CheckMark:460770234177945610>");

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "WrongMark")
                    {
                        await guildUser.KickAsync();
                        var dmChannel = await guildUser.GetOrCreateDMChannelAsync();
                        await dmChannel.SendMessageAsync($"{Messages.wrong} Zostałeś wyrzucony z serwera, ponieważ nie zaakceptowałeś regulaminu.");
                    }
                    else if (reaction.Emote.Name == "CheckMark")
                    {
                        var AddRole = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 2/5");
                        var RemoveRole = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 1/5");

                        await guildUser.AddRoleAsync(AddRole);
                        await guildUser.RemoveRoleAsync(RemoveRole);

                        var guildaccount = GuildAccounts.GetAccount(guild);
                        ulong WelcomeChannelID = guildaccount.WelcomeChannelID;
                        var WelcomeChannel = guild.GetChannel(WelcomeChannelID) as IMessageChannel;
                        await WelcomeChannel.SendMessageAsync(Messages.WelcomeMessage(guild.Name, reaction.User.Value.Mention));
                    }
                }
            }
        }

        public static async Task ReactionWiek(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.age)
            {
                var guildUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;

                var msg = await cache.GetOrDownloadAsync();

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "\u0031\u20e3")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");

                        await guildUser.AddRoleAsync(r1);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0032\u20e3")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");

                        await guildUser.AddRoleAsync(r2);

                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0033\u20e3")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");

                        await guildUser.AddRoleAsync(r3);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0034\u20e3")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");

                        await guildUser.AddRoleAsync(r4);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0035\u20e3")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");

                        await guildUser.AddRoleAsync(r5);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0036\u20e3")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
                        var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
                        var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
                        var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
                        var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");

                        await guildUser.AddRoleAsync(r6);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r1);
                    }
                    else if(reaction.Emote.Name == "➡")
                    {
                        var r1 = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 3/5");
                        var r2 = guild.Roles.FirstOrDefault(x => x.Name == "WERYFIKACJA 4/5");
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.AddRoleAsync(r2);
                    }
                }
            }
        }

        public static async Task ReactionPomoc(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.help)
            {
                var ReactionUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;
                var msg = await cache.GetOrDownloadAsync();

                if (reaction.User.Value.IsBot) return;
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "💰")
                    {
                        string botmsg = Messages.HelpMoney;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "🤐")
                    {
                        string botmsg = Messages.HelpOffend;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "✋")
                    {
                        string botmsg = Messages.HelpCandidate;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "💡")
                    {
                        string botmsg = Messages.HelpIdea;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "🌟")
                    {
                        string botmsg = Messages.HelpPartner;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "📨")
                    {
                        string botmsg = Messages.HelpInvite;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "📜")
                    {
                        string botmsg = Messages.HelpCommands;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "supervip")
                    {
                        string botmsg = Messages.HelpVIP;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "ultravip")
                    {
                        string botmsg = Messages.HelpSVIP;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "sponsor")
                    {
                        string botmsg = Messages.HelpSponsor;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "👻")
                    {
                        string botmsg = Messages.HelpAki;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "🎵")
                    {
                        string botmsg = Messages.HelpMusic;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "blob_youtube")
                    {
                        string botmsg = Messages.HelpYT;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                    else if (reaction.Emote.Name == "⛑")
                    {
                        string botmsg = Messages.HelpOther;
                        var MsgToDelete = await channel.SendMessageAsync(botmsg);
                        await Helpers.RemoveMessage(MsgToDelete, 8);
                    }
                }
            }
        }

        public static async Task ReactionApproval (Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var client = Global.Client;
            var guild = client.GetGuild(448884032391086090);
            var GuildAccount = GuildAccounts.GetAccount(guild);
            var admChannel = guild.GetChannel(GuildAccount.AdmChannelID) as ITextChannel;
            var sugChannel = guild.GetChannel(GuildAccount.SuggestionsChannelID) as ITextChannel;
            var msg = await cache.GetOrDownloadAsync();

            if (reaction.Channel == admChannel)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
                if (reaction.Emote.Name == "🆗")
                {
                        //remove
                        var MsgToReact = await sugChannel.SendMessageAsync("", false, msg.Embeds.FirstOrDefault() as Embed);

                        var nie = Emote.Parse(Messages.wrong);
                        var tak = Emote.Parse(Messages.check);
                        await MsgToReact.AddReactionAsync(tak);
                        await MsgToReact.AddReactionAsync(nie);
                }
                if (reaction.Emote.Name == "WrongMark")
                {
                    var x = msg as IMessage;
                    await x.DeleteAsync();
                }
            }
        }

        public static async Task ReactionProfile (Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            if (reaction.MessageId == ReactionChannels.channels.profile)
            {
                if (reaction.User.Value.IsBot) return;
                else
                {
                    var msg = await cache.GetOrDownloadAsync();

                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    var account = UserAccounts.GetAccount(reaction.User.Value);

                    string avatar = reaction.User.Value.GetAvatarUrl();
                    string userlvl = account.LevelNumber.ToString();
                    string userexp = account.XP.ToString();
                    string username = reaction.User.Value.Username;
                    string moneyw = account.MoneyWallet.ToString();
                    string moneyac = account.MoneyAccount.ToString();
                    string NoWarns = account.Warns.ToString();

                    EmbedBuilder eb = new EmbedBuilder();
                    eb.WithAuthor($"Profil gracza {username}");
                    eb.Author.WithIconUrl(avatar);
                    eb.WithThumbnailUrl(avatar);
                    eb.AddField("Nazwa:", $"{username}", true);
                    eb.AddField("Liczba ostrzeżeń:", $"{NoWarns}/5", true);
                    eb.AddField("Poziom:", $"{userlvl} lvl", true);
                    eb.AddField("Exp:", $"{userexp} xp", true);
                    eb.AddField("Portfel:", $"{moneyw} {Messages.coin}", true);
                    eb.AddField("Konto:", $"{moneyac} {Messages.coin}", true);
                    eb.WithColor(Color.DarkGrey);

                    EmbedBuilder eb2 = new EmbedBuilder();
                    eb2.WithAuthor($"Kliknij aby załadować swój profil");
                    eb2.Author.WithIconUrl("https://cdn4.iconfinder.com/data/icons/social-messaging-ui-color-squares-01/3/30-512.png");
                    eb2.WithThumbnailUrl("https://cdn4.iconfinder.com/data/icons/social-messaging-ui-color-squares-01/3/30-512.png");
                    eb2.AddField("Nazwa:", "-", true);
                    eb2.AddField("Liczba ostrzeżeń:", "-", true);
                    eb2.AddField("Poziom:", "-", true);
                    eb2.AddField("Exp:", "-", true);
                    eb2.AddField("Portfel:", "-", true);
                    eb2.AddField("Konto:", "-", true);
                    eb2.WithColor(Color.DarkGrey);

                    await msg.ModifyAsync(mmessage =>
                    {
                        mmessage.Content = "";
                        mmessage.Embed = null;
                        mmessage.Embed = eb.Build();
                    });
                    await Task.Delay(10000);
                    await msg.ModifyAsync(mmessage =>
                    {
                        mmessage.Content = "";
                        mmessage.Embed = null;
                        mmessage.Embed = eb2.Build();
                    });
                }
            }
        }
    }
}