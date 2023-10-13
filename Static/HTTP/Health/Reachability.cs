using System.Net.NetworkInformation;

namespace Static.HTTP.Health
{
    public static class Reachability
    {
        private static int REQUEST_TIMEOUT = 5;

        public static IList<string> IsReachable(params string[] dependencies)
        {
            List<string> failues = new List<string>();

            Ping pinger = new Ping();

            foreach (var dependency in dependencies)
            {
                PingReply replay = pinger.Send(dependency, REQUEST_TIMEOUT);

                if (replay.Status == IPStatus.Success)
                {
                    failues.Add($"Ping failed for {replay.Address.ToString()}");
                }
            }

            return failues;
        }
    }
}
