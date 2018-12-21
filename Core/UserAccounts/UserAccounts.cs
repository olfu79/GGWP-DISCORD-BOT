using System;
using System.Collections.Generic;
using System.Linq;

using Discord;

namespace ggwp.Core.UserAccounts
{
    public static class UserAccounts
    {
        private static List<UserAccount> accounts;

        private static readonly string accountsFile = "Resources/accounts.json";

        static UserAccounts()
        {
            if (UserDataStorage.SaveExists(accountsFile))
            {
                accounts = UserDataStorage.LoadUserAccounts(accountsFile).ToList();
            }
            else
            {
                accounts = new List<UserAccount>();
                SaveAccounts();
            }
        }

        public static void SaveAccounts()
        {
            UserDataStorage.SaveUserAccounts(accounts, accountsFile);
        }

        public static UserAccount GetAccount(IUser user)
        {
            return GetOrCreateAccount(user.Id);
        }

        internal static List<UserAccount> GetAllAccounts()
        {
            return accounts.ToList();
        }

        private static UserAccount GetOrCreateAccount(ulong id)
        {
            var result = from a in accounts
                         where a.ID == id
                         select a;

            var account = result.FirstOrDefault();
            if (account == null) account = CreateUserAccount(id);
            return account;
        }

        private static UserAccount CreateUserAccount(ulong id)
        {
            var newAccount = new UserAccount()
            {
                ID = id,
                Points = 10,
                XP = 0,
                MoneyAccount = 250,
                MoneyWallet = 0
            };

            accounts.Add(newAccount);
            SaveAccounts();
            return newAccount;
        }
    }
}
