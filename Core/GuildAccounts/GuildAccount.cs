using System;
using System.Collections.Generic;
using System.Text;

namespace ggwp.Core.GuildAccounts
{
    public class GuildAccount
    {
        public ulong ID { get; set; }

        public ulong PenaltyChannelID { get; set; }

        public ulong AnnouncmentChannelID { get; set; }

        public ulong VoteChannelID { get; set; }

        public ulong BankChannelID { get; set; }

        public ulong WelcomeChannelID { get; set; }

        public uint ShopPage { get; set; }

        public uint GamblingPage { get; set; }

        public ulong AdmChannelID { get; set; }

        public ulong SuggestionsChannelID { get; set; }

        public string InviteLink { get; set; }
    }
}
