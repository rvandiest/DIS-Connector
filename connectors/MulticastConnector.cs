using System.Net;
using System.Net.Sockets;
using Utilties.Networking;

namespace DIS
{
    /// <summary>
    /// Enables multicasting PDU's to specified address, and receive PDU's likewise. 
    /// sent from that address.
    /// </summary>
    public class MulticastConnector : Connector
    {
        /// <summary>
        /// Enables multicasting PDU's to specified address, and receive PDU's likewise. 
        /// sent from that address.
        /// <param name="server">The IP address of the server to connect to.</param>
        /// <param name="group">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        internal MulticastConnector(IPAddress server, MulticastGroup group, int port)
        {
            Port = port;
            Endpoint = (EndPoint)new IPEndPoint(server, Port);

            Socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            Socket.SetSocketOption(SocketOptionLevel.IP,
                SocketOptionName.AddMembership,
                    new MulticastOption(group.Address, server));

            Socket.Bind(Endpoint);
        }

    }
}