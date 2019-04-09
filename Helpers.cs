using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Discord;
using Supremes.Nodes;
using ggwp.Core.UserAccounts;
using Discord.WebSocket;
using ggwp.Core.GuildAccounts;
using ggwp.Services.Managment_Methods;
using ggwp.Services.Reaction_Methods;

namespace ggwp
{
    public class Helpers
    {
        public static async Task RemoveMessage(IUserMessage message, int timeInSeconds = 3)
        {
            try
            {
                var seconds = timeInSeconds * 1000;
                await Task.Delay(seconds);
                await message.DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static bool HasImage(IMessage msg)
        {
            if (msg.Attachments.Any())
                foreach (var attachment in msg.Attachments)
                {
                    if (attachment.Filename.EndsWith(".png") || attachment.Filename.EndsWith(".jpg") || attachment.Filename.EndsWith(".jpeg") || attachment.Filename.EndsWith(".gif"))
                        return true;
                }

            return false;
        }

        public static async Task AntiAdvertisment(SocketMessage msg)
        {
            if (msg.Author.IsBot) return;
            if (msg.Channel is IPrivateChannel) return;

            var guildChannel = msg.Channel as IGuildChannel;
            var guild = guildChannel.Guild as SocketGuild;
            var user = msg.Author as SocketGuildUser;
            var rola = guild.Roles.FirstOrDefault(x => x.Id == 446765076490223618);


            if (Global.Advertismentwords.Any(word => msg.Content.ToLower().Contains(word)) == false || msg.Content.Contains("discord.gg/xXKrd5R") || user.Roles.Contains(rola)) return;
            {
                var pamietaj = Emote.Parse("<:thinksmart:460770233171443713>");
                await msg.DeleteAsync();
                var MessageToRemove = await msg.Channel.SendMessageAsync($":rage: {msg.Author.Mention} Reklamowanie cudzych serwerów nie jest dozwolone! :warning: Dopisuję ostrzeżenie.\n{pamietaj} Pamiętaj że nasz serwer ma tylko jedno oficjalne zaproszenie.\n:anger_right: Wpisz `!zaproszenie` aby je otrzymać.");
                await Helpers.RemoveMessage(MessageToRemove, 5);
                var uslessmsg = await msg.Channel.SendMessageAsync(".");

                string reason = "Reklamowanie innych serwerów discord.";
                var administrator = Global.Client.CurrentUser;

                await ManagmentService.Warn(guild, uslessmsg, user, administrator, reason);
            }
        }

        public static async Task AntiSwear(SocketMessage arg)
        {
            if (arg.Author.IsBot) return;
            if (Global.Swearwords.Any(word => arg.Content.ToLower().Contains(word)) == false) return;
            {
                if (arg.Channel is SocketDMChannel) return;
                await arg.DeleteAsync();
                var msg = await arg.Channel.SendMessageAsync($":angry: {arg.Author.Mention} Nie przeklinaj! :zipper_mouth:");
                await Helpers.RemoveMessage(msg, 5);
            }
        }

        public static async Task CountingChannel(SocketMessage msg)
        {
            if (msg.Channel is IPrivateChannel) return;

            var channel = msg.Channel as IGuildChannel;
            var Guild = channel.Guild as SocketGuild;
            var GuildAccount = GuildAccounts.GetAccount(Guild);

            ulong CountingChannelID = GuildAccount.CountingChannelID;

            if (msg.Channel.Id == CountingChannelID)
            {
                if (msg.Author.IsBot) { return; }

                var CountingChannel = Guild.GetChannel(CountingChannelID) as IMessageChannel;

                if (!msg.Content.Any(Char.IsDigit))
                {
                    await msg.DeleteAsync();
                    var InfoMsg = await CountingChannel.SendMessageAsync("Na tym kanale można wysyłać tylko liczby.");
                    await Helpers.RemoveMessage(InfoMsg);
                }
            }
        }

        public static async Task MemesChannel(SocketMessage msg)
        {
            if (msg.Channel is IPrivateChannel) return;

            var channel = msg.Channel as IGuildChannel;
            var Guild = channel.Guild as SocketGuild;
            var GuildAccount = GuildAccounts.GetAccount(Guild);

            ulong MemesChannelID = GuildAccount.MemesChannelID;

            if (msg.Channel.Id == MemesChannelID)
            {
                if (msg.Author.IsBot) { return; }

                var MemesChannel = Guild.GetChannel(MemesChannelID) as IMessageChannel;

                if (!msg.Attachments.Any())
                {
                    await msg.DeleteAsync();
                    var InfoMsg = await MemesChannel.SendMessageAsync($"{Messages.wrong} Na tym kanale można wysyłać tylko obrazki.");
                    await Helpers.RemoveMessage(InfoMsg);
                }
                else
                {
                    var attachments = msg.Attachments;
                    foreach (var attachment in attachments)
                    {
                        if (attachment.Filename.EndsWith(".jpg") || attachment.Filename.EndsWith(".jpeg") || attachment.Filename.EndsWith(".png") || attachment.Filename.EndsWith(".gif") || attachment.Filename.EndsWith(".bmp"))
                        {
                            var like = new Emoji("👍");
                            var dislike = new Emoji("👎");
                            var MemeMessage = msg as IUserMessage;
                            await MemeMessage.AddReactionAsync(like);
                            await MemeMessage.AddReactionAsync(dislike);
                        }
                        else
                        {
                            await msg.DeleteAsync();
                            var InfoMsg = await MemesChannel.SendMessageAsync($"{Messages.wrong} Na tym kanale nie można wysyłać innych plików niż obrazki.");
                            await Helpers.RemoveMessage(InfoMsg);
                        }
                    }
                }
            }
        }

        public static bool TryToParse(string valueStringToNumber)
        {
            bool success = Int64.TryParse(valueStringToNumber, out long number);
            return success;
        }

        public static async Task<bool> BalanceCheck(IUser user, IMessageChannel channel, ulong money)
        {
            string wrong = Messages.wrong;
            string coin = Messages.coin;

            var account = UserAccounts.GetAccount(user);
            ulong balnace = account.MoneyWallet;

            if (balnace < money)
            {
                var msg = await channel.SendMessageAsync($"{wrong} Nie masz tyle pieniędzy **w portfelu**. Aktualnie posiadasz: {balnace}{coin}");
                await RemoveMessage(msg, 3);
                return false;
            }
            return true;
        }

        public static async Task<bool> HasRoleCheck(SocketGuildUser user, IMessageChannel channel, IRole role, string item)
        {
            string wrong = Messages.wrong;

            var account = UserAccounts.GetAccount(user);

            if (user.Roles.Contains(role))
            {
                var msg = await channel.SendMessageAsync($"{wrong} {user.Mention}, posiadasz już **{item}**");
                await RemoveMessage(msg, 3);
                return false;
            }
            return true;
        }

        public static (string url, string alt) GetMeme()
        {
            string searchUrl = "https://kwejk.pl/losowy";
            string url = "";
            string alt = "";

            WebClient webClient = new WebClient();
            //trycatch
            string htmlResult = "";
            try
            {
                htmlResult = webClient.DownloadString(searchUrl);
            }
            catch(WebException)
            {
                url = "https://www.lifewire.com/thmb/OO7CD06NAdoIwv71DgUgBiTd4ps=/768x0/filters:no_upscale():max_bytes(150000):strip_icc()/shutterstock_325494917-5a68d8403418c600190a3e1f.jpg";
                alt = "😦 Wystąpił błąd. Spróbuj ponownie!";
                //System.Net.WebException: „The remote server returned an error: (404) Not Found.”
            }
            Document doc = Supremes.Dcsoup.Parse(htmlResult, "https://kwejk.pl/losowy");

            foreach (Element result in doc.GetElementsByClass("full-image"))
            {
                url = result.Attr("src");
                alt = result.Attr("alt");
            }
            return (url, alt);
        }

        public static string GetJoke()
        {
            string searchUrl = "http://www.suchary.com/random.html";

            WebClient webClient = new WebClient();
            string htmlResult = webClient.DownloadString(searchUrl);

            Document doc = Supremes.Dcsoup.Parse(htmlResult, "http://www.suchary.com/random.html");
            string url = "";
            foreach (Element result in doc.GetElementsByClass("file-container"))
            {
                Elements elements = result.GetElementsByTag("img");               
                url = elements.Attr("src");
            }
            return url;
        }
    }
}
