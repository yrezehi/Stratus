using System.Net.NetworkInformation;

namespace Static.Health
{
    public static class Reachability
    {
        public IList<string> IsReachable(params string[] dependencies)
        {
            List<string> failues = new List<string>();

            Ping pinger = new Ping();

            foreach (var dependency in dependencies) {
                pinger.SendAsync(dependency);
            }
        }
    }
}
