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

        public static async Task<bool> TryToParse(string ValueStringToNumber)
        {
            bool success = Int64.TryParse(ValueStringToNumber, out long number);
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

        public static async Task<(string url, string alt)> GetMeme()
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

        public static async Task<string> GetJoke()
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
