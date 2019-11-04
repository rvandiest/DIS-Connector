using System.Net;
using System.Net.Sockets;

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
        /// <param name="multicastaddress">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        internal MulticastConnector(IPAddress multicastaddress, int port)
        {
            Port = port;
            Endpoint = (EndPoint)new IPEndPoint(IPAddress.Any, Port);

            Socket = new Socket(AddressFamily.InterNetwork,
                SocketType.Dgram, ProtocolType.Udp);

            Socket.SetSocketOption(SocketOptionLevel.IP,
                SocketOptionName.AddMembership,
                    new MulticastOption(multicastaddress, IPAddress.Any));

            Socket.Bind(Endpoint);
        }

    }
}