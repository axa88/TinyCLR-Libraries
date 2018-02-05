
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using NI = System.Net.NetworkInterface.NetworkInterface;

namespace System.Net {
    using System.Net.Sockets;

    public static class Dns
    {
        public static IPHostEntry GetHostEntry(string hostNameOrAddress)
        {
            var dns = NI.GetActiveForDns();

            dns.GetHostByName(hostNameOrAddress, out var canonicalName, out var addresses);

            var cAddresses = addresses.Length;
            var ipAddresses = new IPAddress[cAddresses];
            var ipHostEntry = new IPHostEntry();

            for (var i = 0; i < cAddresses; i++)
            {
                var address = addresses[i];

                var sockAddress = new SocketAddress(address);

                AddressFamily family;

                if(SystemInfo.IsBigEndian)
                {
                    family = (AddressFamily)((address[0] << 8) | address[1]);
                }
                else
                {
                    family = (AddressFamily)((address[1] << 8) | address[0]);
                }
                //port address[2-3]

                if (family == AddressFamily.InterNetwork)
                {
                    //This only works with IPv4 addresses

                    var ipAddr = (uint)((address[7] << 24) | (address[6] << 16) | (address[5] << 8) | (address[4]));

                    ipAddresses[i] = new IPAddress((long)ipAddr);
                }
            }

            ipHostEntry.hostName = canonicalName;
            ipHostEntry.addressList = ipAddresses;

            return ipHostEntry;
        }
    }
}

