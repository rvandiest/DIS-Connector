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
        static Dictionary<Tuple<IPAddress, MulticastGroup, int>, MulticastConnector> instances = new Dictionary<Tuple<IPAddress, MulticastGroup, int>, MulticastConnector>();

        /// <summary>
        /// Get an instance of the BroadcastConnector class.
        /// <param name="server">The IP address of the server to connect to.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getBroadcastConnector(IPAddress server, int port)
        {
            if (broadcastInstance == null)
            {
                broadcastInstance = new BroadcastConnector(server, port);
            }
            return broadcastInstance;
        }

        /// <summary>
        /// Get an instance of the MulticastConnector class.
        /// sent from that address.
        /// <param name="server">The IP address of the server to connect to.</param>
        /// <param name="multicastaddress">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getMulticastConnector(IPAddress server, MulticastGroup group, int port)
        {
            Tuple<IPAddress, MulticastGroup, int> key = new Tuple<IPAddress, MulticastGroup, int>(server, group, port);
            if (!instances.ContainsKey(key))
            {
                instances[key] = new MulticastConnector(server, group, port);
            }
            return instances[key];
        }
    }

}