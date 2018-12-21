using System;
using System.Collections.Generic;
using System.Text;

namespace ggwp.Core.GuildAccounts
{
    public class GuildAccount
    {
        public ulong ID { get; set; }

        public ulong PenaltyChannelID { get; set; }

        public ulong BankChannelID { get; set; }

        public ulong WelcomeChannelID { get; set; }

        public uint ShopPage { get; set; }
    }
}
