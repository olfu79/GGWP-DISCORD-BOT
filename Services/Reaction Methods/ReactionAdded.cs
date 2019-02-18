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

                var ReactionUser = (SocketGuildUser)reaction.User;
                var guildChannel = channel as IGuildChannel;
                var guild = guildChannel.Guild as SocketGuild;

                var account = UserAccounts.GetAccount(reaction.User.Value);

                var Rcs = guild.Roles.FirstOrDefault(x => x.Name == "CS:GO");
                var Rlol = guild.Roles.FirstOrDefault(x => x.Name == "LOL");
                var Rpubg = guild.Roles.FirstOrDefault(x => x.Name == "PUBG");
                var Rfort = guild.Roles.FirstOrDefault(x => x.Name == "FORTNITE");
                var Rov = guild.Roles.FirstOrDefault(x => x.Name == "OVERWATCH");
                var Rroblox = guild.Roles.FirstOrDefault(x => x.Name == "ROBLOX");
                var Rgta = guild.Roles.FirstOrDefault(x => x.Name == "GTA V");
                var Rmc = guild.Roles.FirstOrDefault(x => x.Name == "MINECRAFT");
                var Rsims = guild.Roles.FirstOrDefault(x => x.Name == "SIMS");
                var Rrocket = guild.Roles.FirstOrDefault(x => x.Name == "ROCKET LEAGUE");
                var Runturned = guild.Roles.FirstOrDefault(x => x.Name == "UNTURNED");
                var Rwow = guild.Roles.FirstOrDefault(x => x.Name == "WOW");

                var msg = await cache.GetOrDownloadAsync();
                if (reaction.MessageId == ReactionChannels.channels.games)
                {
                    if (reaction.User.Value.IsBot)
                    {
                        return;
                    }
                    else
                    {
                        await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                        if (reaction.Emote.Name == "csgo")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rcs))
                            {
                                await guildUser.RemoveRoleAsync(Rcs);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rcs);
                            }
                        }
                        else if (reaction.Emote.Name == "lol")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rlol))
                            {
                                await guildUser.RemoveRoleAsync(Rlol);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rlol);
                            }
                        }
                        else if (reaction.Emote.Name == "pubg")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rpubg))
                            {
                                await guildUser.RemoveRoleAsync(Rpubg);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rpubg);
                            }
                        }
                        else if (reaction.Emote.Name == "fortnite")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rfort))
                            {
                                await guildUser.RemoveRoleAsync(Rfort);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rfort);
                            }
                        }
                        else if (reaction.Emote.Name == "overwatch")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rov))
                            {
                                await guildUser.RemoveRoleAsync(Rov);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rov);
                            }
                        }
                        else if (reaction.Emote.Name == "roblox")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rroblox))
                            {
                                await guildUser.RemoveRoleAsync(Rroblox);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rroblox);
                            }
                        }
                        else if (reaction.Emote.Name == "gta")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rgta))
                            {
                                await guildUser.RemoveRoleAsync(Rgta);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rgta);
                            }
                        }
                        else if (reaction.Emote.Name == "minecraft")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rmc))
                            {
                                await guildUser.RemoveRoleAsync(Rmc);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rmc);
                            }
                        }
                        else if (reaction.Emote.Name == "sims")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rsims))
                            {
                                await guildUser.RemoveRoleAsync(Rsims);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rsims);
                            }
                        }
                        else if (reaction.Emote.Name == "rocketleague")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rrocket))
                            {
                                await guildUser.RemoveRoleAsync(Rrocket);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rrocket);
                            }
                        }
                        else if (reaction.Emote.Name == "unturned")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Runturned))
                            {
                                await guildUser.RemoveRoleAsync(Runturned);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Runturned);
                            }
                        }
                        else if (reaction.Emote.Name == "wow")
                        {
                            var guildUser = (SocketGuildUser)reaction.User;

                            if (ReactionUser.Roles.Contains(Rwow))
                            {
                                await guildUser.RemoveRoleAsync(Rwow);
                            }
                            else
                            {
                                await guildUser.AddRoleAsync(Rwow);
                            }
                        }
                    }
                }
            }
        }

        public static async Task ReactionGambling(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
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
            slots.AddField("Ruletka", $"```,```");
            slots.WithColor(Color.DarkGreen);
            //msg coinflip
            string coinflip = "coinflip";

            if (reaction.MessageId == ReactionChannels.channels.gambling)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
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

                    //rulette stuff
                    uint roulettemultiplier = 1;
                    string colors = "";

                    var red = Emote.Parse("<:red:546427447797612546>");
                    var green = Emote.Parse("<:green:546426978820030464>");

                    Random rndom = new Random();
                    var r = rnd.Next(1,100);

                    if(r < 49)
                    {
                        roulettemultiplier = 2;
                        colors = $"**\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_**\n│:black_large_square::black_large_square:{red}{red}║:black_large_square::black_large_square:║{red}{red}:black_large_square::black_large_square:│\n│:black_large_square::black_large_square:{red}{red}║:black_large_square::black_large_square:║{red}{red}:black_large_square::black_large_square:│\n**ˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉ**";
                    }
                    else if(r > 49 && r < 99)
                    {
                        roulettemultiplier = 2;
                        colors = $"**\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_**\n│{red}{red}:black_large_square::black_large_square:║{red}{red}║:black_large_square::black_large_square:{red}{red}│\n│{red}{red}:black_large_square::black_large_square:║{red}{red}║:black_large_square::black_large_square:{red}{red}│\n**ˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉ**";
                    }
                    else
                    {
                        roulettemultiplier = 25;
                        colors = $"**\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_\\_**\n│{red}{red}:black_large_square::black_large_square:║{green}{green}║{red}{red}:black_large_square::black_large_square:│\n│{red}{red}:black_large_square::black_large_square:║{green}{green}║{red}{red}:black_large_square::black_large_square:│\n**ˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉˉ**";
                    }

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
                                message.Content = coinflip;
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
                            await msg.ModifyAsync(mmessage =>
                            {
                                mmessage.Content = coinflip;
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

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
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
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = frulette.Build();
                                });

                                ulong reward = bid * roulettemultiplier;

                                UserAccount.MoneyWallet += reward;

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
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

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
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
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = frulette.Build();
                                });

                                ulong reward = bid * roulettemultiplier;

                                UserAccount.MoneyWallet += reward;

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
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

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
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
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = frulette.Build();
                                });

                                ulong reward = bid * roulettemultiplier;

                                UserAccount.MoneyWallet += reward;

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
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

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
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
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = frulette.Build();
                                });

                                ulong reward = bid * roulettemultiplier;

                                UserAccount.MoneyWallet += reward;

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
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

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
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
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = frulette.Build();
                                });

                                ulong reward = bid * roulettemultiplier;

                                UserAccount.MoneyWallet += reward;

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {
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

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
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
                                UserAccount.MoneyWallet -= bid;

                                await msg.ModifyAsync(message =>
                                {
                                    message.Content = $"";
                                    message.Embed = null;
                                    message.Embed = frulette.Build();
                                });

                                ulong reward = bid * roulettemultiplier;

                                UserAccount.MoneyWallet += reward;

                                string depmessage = "㊙ Przepraszam, wystąpił błąd.";
                                if (reward != 0)
                                    depmessage = $"🎊 Gratulacje {reaction.User.Value.Username}! Wygrałeś {reward} {Messages.coin}";
                                else
                                    depmessage = $"😢 Niestety {reaction.User.Value.Username}, nic nie wygrałeś. Spróbuj ponownie.";
                                var MsgToRemove = await channel.SendMessageAsync(depmessage);
                                await Helpers.RemoveMessage(MsgToRemove, 5);
                            }
                        }
                        else if (GuildAccount.GamblingPage == 3)
                        {

                        }
                    }
                    //end
                }
            }
        }

        public static async Task ReactionCashmashine(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var msg = await cache.GetOrDownloadAsync();

            if (reaction.MessageId == ReactionChannels.channels.bank)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
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

        public static async Task ReactionMeme(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var msg = await cache.GetOrDownloadAsync();
            //trycatch
            var tuple = await Helpers.GetMeme();
            string MemeUrl = tuple.url;
            string MemeAlt = tuple.alt;

            string JokeUrl = await Helpers.GetJoke();

            EmbedBuilder ebMeme = new EmbedBuilder();
            ebMeme.WithTitle(MemeAlt);
            ebMeme.WithImageUrl(MemeUrl);
            ebMeme.WithColor(Color.Gold);

            EmbedBuilder ebJoke = new EmbedBuilder();
            ebJoke.WithTitle("");
            ebJoke.WithImageUrl(JokeUrl);
            ebJoke.WithColor(Color.Gold);

            if (reaction.MessageId == ReactionChannels.channels.meme)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
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

            if (reaction.MessageId == ReactionChannels.channels.shop)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
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
            var ReactionUser = (SocketGuildUser)reaction.User;
            var guildChannel = channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            var msg = await cache.GetOrDownloadAsync();

            if (reaction.MessageId == ReactionChannels.channels.gender)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "👨")
                    {
                        var AddRole = guild.Roles.FirstOrDefault(x => x.Name == "♂️");
                        var DelRole = guild.Roles.FirstOrDefault(x => x.Name == "♀️");

                        var guildUser = (SocketGuildUser)reaction.User;

                        await guildUser.AddRoleAsync(AddRole);
                        await guildUser.RemoveRoleAsync(DelRole);
                    }
                    else if(reaction.Emote.Name == "👩")
                    {
                        var AddRole = guild.Roles.FirstOrDefault(x => x.Name == "♀️");
                        var DelRole = guild.Roles.FirstOrDefault(x => x.Name == "♂️");

                        var guildUser = (SocketGuildUser)reaction.User;

                        await guildUser.AddRoleAsync(AddRole);
                        await guildUser.RemoveRoleAsync(DelRole);
                    }
                }
            }
        }

        public static async Task ReactionReg(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var guildUser = (SocketGuildUser)reaction.User;
            var guildChannel = channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            var msg = await cache.GetOrDownloadAsync();
            var nie = Emote.Parse("<:WrongMark:460770239286870017>");
            var tak = Emote.Parse("<:CheckMark:460770234177945610>");

            if (reaction.MessageId == ReactionChannels.channels.rules)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "WrongMark")
                    {
                        await guildUser.KickAsync();
                        //DM wiadomość że został wyrzucony
                    }
                    else if (reaction.Emote.Name == "CheckMark")
                    {
                        var AddRole = guild.Roles.FirstOrDefault(x => x.Name == "NOWY CZŁONEK 2/4");
                        var RemoveRole = guild.Roles.FirstOrDefault(x => x.Name == "NOWY CZŁONEK 1/4");

                        var guildUsr = (SocketGuildUser)reaction.User;
                        await guildUsr.AddRoleAsync(AddRole);
                        await guildUsr.RemoveRoleAsync(RemoveRole);

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
            var guildUser = (SocketGuildUser)reaction.User;
            var guildChannel = channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;

            var msg = await cache.GetOrDownloadAsync();

            var r1 = guild.Roles.FirstOrDefault(x => x.Name == "13+");
            var r2 = guild.Roles.FirstOrDefault(x => x.Name == "14+");
            var r3 = guild.Roles.FirstOrDefault(x => x.Name == "15+");
            var r4 = guild.Roles.FirstOrDefault(x => x.Name == "16+");
            var r5 = guild.Roles.FirstOrDefault(x => x.Name == "17+");
            var r6 = guild.Roles.FirstOrDefault(x => x.Name == "18+");



            if (reaction.MessageId == ReactionChannels.channels.age)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
                else
                {
                    await msg.RemoveReactionAsync(reaction.Emote, reaction.User.Value);

                    if (reaction.Emote.Name == "\u0031\u20e3")
                    {
                        await guildUser.AddRoleAsync(r1);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0032\u20e3")
                    {
                        await guildUser.AddRoleAsync(r2);

                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0033\u20e3")
                    {
                        await guildUser.AddRoleAsync(r3);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0034\u20e3")
                    {
                        await guildUser.AddRoleAsync(r4);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0035\u20e3")
                    {
                        await guildUser.AddRoleAsync(r5);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r1);
                        await guildUser.RemoveRoleAsync(r6);
                    }
                    else if (reaction.Emote.Name == "\u0036\u20e3")
                    {
                        await guildUser.AddRoleAsync(r6);

                        await guildUser.RemoveRoleAsync(r2);
                        await guildUser.RemoveRoleAsync(r3);
                        await guildUser.RemoveRoleAsync(r4);
                        await guildUser.RemoveRoleAsync(r5);
                        await guildUser.RemoveRoleAsync(r1);
                    }
                }
            }
        }

        public static async Task ReactionPomoc(Cacheable<IUserMessage, ulong> cache, ISocketMessageChannel channel, SocketReaction reaction)
        {
            var ReactionUser = (SocketGuildUser)reaction.User;
            var guildChannel = channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            var msg = await cache.GetOrDownloadAsync();

            if (reaction.MessageId == ReactionChannels.channels.help)
            {
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
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
                if (reaction.User.Value.IsBot)
                {
                    return;
                }
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