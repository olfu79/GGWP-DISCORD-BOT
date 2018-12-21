using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using ggwp.Core.GuildAccounts;
using ggwp.Core.ReactionsSystem;

using Newtonsoft.Json;

namespace ggwp.Core
{
    public static class GuildDataStorage
    {
        public static void SaveGuildAccounts(IEnumerable<GuildAccount> accounts, string filePath)
        {
            string json = JsonConvert.SerializeObject(accounts, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static IEnumerable<GuildAccount> LoadGuildAccounts(string filePath)
        {
            if (!File.Exists(filePath)) return null;
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<GuildAccount>>(json);
        }

        public static bool SaveExists(string filePath)
        {
            return File.Exists(filePath);
        }
    }
}
