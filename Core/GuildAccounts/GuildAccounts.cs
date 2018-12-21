using System;
using System.Collections.Generic;
using System.Linq;

using Discord;

namespace ggwp.Core.GuildAccounts
{
    public static class GuildAccounts
    {
        private static List<GuildAccount> accounts;

        private static string accountsFile = "Resources/guild_accounts.json";

        static GuildAccounts()
        {
            if (GuildDataStorage.SaveExists(accountsFile))
            {
                accounts = GuildDataStorage.LoadGuildAccounts(accountsFile).ToList();
            }
            else
            {
                accounts = new List<GuildAccount>();
                SaveAccounts();
            }
        }

        public static void SaveAccounts()
        {
            GuildDataStorage.SaveGuildAccounts(accounts, accountsFile);
        }

        public static GuildAccount GetAccount(IGuild guild)
        {
            return GetOrCreateAccount(guild.Id);
        }

        internal static List<GuildAccount> GetAllAccounts()
        {
            return accounts.ToList();
        }

        private static GuildAccount GetOrCreateAccount(ulong id)
        {
            var result = from a in accounts
                         where a.ID == id
                         select a;

            var account = result.FirstOrDefault();
            if (account == null) account = CreateGuildAccount(id);
            return account;
        }

        private static GuildAccount CreateGuildAccount(ulong id)
        {
            var newAccount = new GuildAccount()
            {
                ID = id
            };

            accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }
    }
}
