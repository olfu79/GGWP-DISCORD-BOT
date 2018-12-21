using System;
using System.Collections.Generic;
using System.Text;
using Discord;
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

        public static DailyResult GetDaily(IUser user)
        {
            var account = UserAccounts.GetAccount(user);
            var difference = DateTime.UtcNow - account.LastDaily.AddDays(1);

            if (difference.TotalHours < 0) return new DailyResult { Success = false, RefreshTimeSpan = difference };

            account.MoneyAccount += 250;
            account.LastDaily = DateTime.UtcNow;
            UserAccounts.SaveAccounts();
            return new DailyResult { Success = true };
        }
    }
}
