using System;
using System.Net;

namespace Utilties.Networking
{
    /// <summary>
    /// Networking helpers.
    /// </summary>
    public static class IPUtilities
    {
        /// <summary>
        /// Get this machines' local (IPV4) IP address
        /// </summary>
        public static IPAddress GetIpv4Address()
        {
            IPHostEntry host;
            host = Dns.GetHostEntry(String.Empty);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            return IPAddress.None;
        }
    }
}