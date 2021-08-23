using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Hosts
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip  = pegarIP();
            Console.WriteLine(ip);
            Console.ReadKey();
        }
        static string pegarIP() 
        {
            var ipV4s = NetworkInterface.GetAllNetworkInterfaces()
    .Select(i => i.GetIPProperties().UnicastAddresses)
    .SelectMany(u => u)
    .Where(u => u.Address.AddressFamily == AddressFamily.InterNetwork)
    .Select(i => i.Address);

            foreach (NetworkInterface netInterface in NetworkInterface.GetAllNetworkInterfaces())
            {

                foreach (UnicastIPAddressInformation address in netInterface.GetIPProperties().UnicastAddresses)
                {
                    if (address.Address.AddressFamily == AddressFamily.InterNetwork &&
                        netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                        (netInterface.Name == "Ethernet" || netInterface.Name == "eth0"))
                    {
                        Console.WriteLine("Adaptador de Internet principal");
                        Console.WriteLine(netInterface.Name);
                        Console.WriteLine("------------------------------");
                        Console.WriteLine(address.Address.ToString());
                        Console.WriteLine("------------------------------");
                    }
                    else if(address.Address.AddressFamily == AddressFamily.InterNetwork &&
                        netInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet) {
                        Console.WriteLine(netInterface.Name); 
                        Console.WriteLine(address.Address.ToString());
                    }

                }
            }
            return null;
        }
    }
}


//fe80::a8be:6bf: 743f:3946 % 10
//2804:d59: 916a: 8200:3d10:bf33: 2790:1792
//2804:d59: 916a: 8200:a8be: 6bf: 743f:3946
//fe80::8c42: a78: 4167:56bc % 51
//fe80::75d6:29c0: 5411:b35e % 44
//192.168.100.42
//172.18.224.1
//172.23.0.1
//test
