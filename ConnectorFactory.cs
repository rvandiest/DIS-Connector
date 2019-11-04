using System;
using System.Collections.Generic;
using System.Net;

namespace DIS
{
    /// <summary>
    /// Factory to get Connector classes.
    /// </summary>
    public static class ConnectorFactory
    {
        //best to use singleton, to prevent socket connection errors
        static BroadcastConnector broadcastInstance;
        static Dictionary<Tuple<IPAddress, int>, MulticastConnector> instances = new Dictionary<Tuple<IPAddress, int>, MulticastConnector>();

        /// <summary>
        /// Get an instance of the BroadcastConnector class.
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getBroadcastConnector(int port)
        {
            if (broadcastInstance == null)
            {
                broadcastInstance = new BroadcastConnector(port);
            }
            return broadcastInstance;
        }

        /// <summary>
        /// Get an instance of the MulticastConnector class.
        /// sent from that address.
        /// <param name="multicastaddress">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getMulticastConnector(IPAddress broadcastadress, int port)
        {
            Tuple<IPAddress, int> key = new Tuple<IPAddress, int>(broadcastadress, port);
            if (!instances.ContainsKey(key))
            {
                instances[key] = new MulticastConnector(broadcastadress, port);
            }
            return instances[key];
        }
    }

}