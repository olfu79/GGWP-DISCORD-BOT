using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using ggwp.Core.UserAccounts;
using ggwp.Core.ReactionsSystem;

using Newtonsoft.Json;

namespace ggwp.Core
{
    public static class UserDataStorage
    {
        public static void SaveUserAccounts(IEnumerable<UserAccount> accounts, string filePath)
        {
            string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static void SaveChannels(ReactionChannel channels, string filePath)
        {
            string json = JsonConvert.SerializeObject(channels, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static IEnumerable<UserAccount> LoadUserAccounts(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<UserAccount>>(json);
        }

        public static bool SaveExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
