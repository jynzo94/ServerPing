using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ServerPing
{
    public class PingOnInterval
    {
        private string _ip;

        public PingOnInterval(string ip)
        {
            _ip = ip;
            
            PingServer();

            Start().Wait();
        }

        public async Task Start()
        {
            var timespan = TimeSpan.FromMinutes(10);
            await SetInterval(PingServer, timespan);
        }

        private void PingServer()
        {
            Ping ping = new Ping();

            var result = ping.Send(_ip);

            if (result.Status == IPStatus.Success)
            {
                Console.WriteLine($"Ping successed");
            }
            else
            {
                Console.WriteLine($"Ping failed");
            }


        }

        private async Task SetInterval(Action action, TimeSpan timeout)
        {
            await Task.Delay(timeout).ConfigureAwait(false);

            action();

            await SetInterval(action, timeout);
        }

    }


}
