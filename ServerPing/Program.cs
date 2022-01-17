using System;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace ServerPing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ping on interval started");
            var pingOnInterval = new PingOnInterval("45.58.142.21");
        }


    }
}
