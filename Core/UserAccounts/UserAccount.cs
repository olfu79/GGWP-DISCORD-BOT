using System;
using System.Collections.Generic;
using System.Text;

namespace ggwp.Core.UserAccounts
{
    public class UserAccount
    {
        public ulong ID { get; set; }

        public uint Points { get; set; }

        public uint XP { get; set; }

        public ulong MoneyWallet { get; set; }

        public ulong MoneyAccount { get; set; }

        public uint Warns { get; set; }

        public uint LevelNumber
        {
            get
            {
                return (uint)Math.Sqrt(XP / 50);
            }
        }

        public DateTime LastDaily { get; set; } = DateTime.UtcNow.AddDays(-2);

        public DateTime LastJob { get; set; } = DateTime.UtcNow.AddDays(-2);

        public DateTime UnmuteTime { get; set; } = DateTime.MinValue;

        public ulong PrivateChannelID { get; set; }

        public bool HelpInProgress { get; set; }

        public ulong HelpChannelID { get; set; }
    }
}
