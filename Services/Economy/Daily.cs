using System;
using System.Linq;
using Discord.WebSocket;
using ggwp.Core.UserAccounts;

namespace ggwp.Services.Economy
{
    public static class Daily
    {
        public struct DailyResult
        {
            public bool Success;
            public TimeSpan RefreshTimeSpan;
        }

        public static DailyResult GetDaily(SocketGuildUser user)
        {
            var account = UserAccounts.GetAccount(user);
            var difference = DateTime.UtcNow - account.LastDaily.AddDays(1);

            if (difference.TotalHours < 0) return new DailyResult { Success = false, RefreshTimeSpan = difference };

            var rVip = user.Guild.Roles.FirstOrDefault(x => x.Name == "VIP");
            var rSvip = user.Guild.Roles.FirstOrDefault(x => x.Name == "SVIP");
            var rSponsor = user.Guild.Roles.FirstOrDefault(x => x.Name == "SPONSOR");

            uint DailyReward = 200;

            if (user.Roles.Contains(rVip))
                DailyReward = 2 * DailyReward;
            if (user.Roles.Contains(rSvip))
                DailyReward = 3 * DailyReward;
            if (user.Roles.Contains(rSponsor))
                DailyReward = 5 * DailyReward;

            account.MoneyAccount += DailyReward;
            account.LastDaily = DateTime.UtcNow;
            UserAccounts.SaveAccounts();
            return new DailyResult { Success = true };
        }
    }
}
