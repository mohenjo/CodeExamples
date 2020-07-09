using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GetNetworkIPs
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            H_NetworkIPInfo newIPInfo = new H_NetworkIPInfo();

            IPAddress ipV4 = newIPInfo.GetInternalIP();
            Console.WriteLine($"Internal IPv4 Address: {ipV4.ToString()}");

            IPAddress ipExt = newIPInfo.GetExternalIP();
            Console.WriteLine($"External IP Address: {ipExt.ToString()}");

            Console.ReadKey();
        }
    }
}
