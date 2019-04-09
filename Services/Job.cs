using System;
using System.Linq;
using Discord.WebSocket;
using ggwp.Core.UserAccounts;

namespace ggwp.Services
{
    public static class Job
    {
        public struct JobResult
        {
            public bool Success;
            public TimeSpan RefreshTimeSpan;
        }

        public static JobResult GetOrder(SocketGuildUser user, uint award)
        {
            var account = UserAccounts.GetAccount(user);
            var difference = DateTime.UtcNow - account.LastJob.AddDays(1);

            if (difference.TotalHours < 0) return new JobResult { Success = false, RefreshTimeSpan = difference };

            account.LastJob = DateTime.UtcNow;
            UserAccounts.SaveAccounts();
            return new JobResult { Success = true };
        }
    }
}
