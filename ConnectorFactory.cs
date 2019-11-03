using System;
using System.Collections.Generic;
using System.Net;
using Utilties.Networking;

namespace DIS
{
    /// <summary>
    /// Factory to get Connector classes.
    /// </summary>
    public static class ConnectorFactory
    {
        //best to use singleton, to prevent socket connection errors
        static BroadcastConnector broadcastInstance;
        static Dictionary<Tuple<IPAddress, IPAddress, int>, MulticastConnector> instances = new Dictionary<Tuple<IPAddress, IPAddress, int>, MulticastConnector>();

        /// <summary>
        /// Get an instance of the BroadcastConnector class.
        /// <param name="remoteaddress">The remote address to send and receive PDU's to/from.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getBroadcastConnector(IPAddress remoteaddress, int port)
        {
            if (broadcastInstance == null)
            {
                broadcastInstance = new BroadcastConnector(IPUtilities.GetIpv4Address(), remoteaddress, port);
            }
            return broadcastInstance;
        }

        /// <summary>
        /// Get an instance of the MulticastConnector class.
        /// sent from that address.
        /// <param name="remoteaddress">The remote address to send and receive PDU's to/from.</param>
        /// <param name="multicastaddress">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getMulticastConnector(IPAddress remote, IPAddress broadcastadress, int port)
        {
            Tuple<IPAddress, IPAddress, int> key = new Tuple<IPAddress, IPAddress, int>(remote, broadcastadress, port);
            if (!instances.ContainsKey(key))
            {
                instances[key] = new MulticastConnector(IPUtilities.GetIpv4Address(), remote, broadcastadress, port);
            }
            return instances[key];
        }
    }

}