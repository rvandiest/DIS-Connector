using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using OpenDis.Dis1998;

namespace DIS
{
    /// <summary>
    /// Enables broadcasting PDU's to specified address, and receive PDU's 
    /// sent from that address.
    /// </summary>
    public class BroadcastConnector : Connector
    {
        /// <summary>
        /// Enables broadcasting PDU's to specified address, and receive PDU's 
        /// sent from that address.
        /// <param name="localaddress">The local address of this machine.</param>
        /// <param name="remoteaddress">The remote address to send and receive PDU's to/from.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        internal BroadcastConnector(IPAddress localaddress, IPAddress remoteaddress, int port)
        {
            Port = port;
            PduQueue = new Queue<Pdu>();

            RemoteEndpoint = (EndPoint)new IPEndPoint(remoteaddress, Port);
            LocalEndpoint = (EndPoint)new IPEndPoint(localaddress, Port);

            Socket = new Socket(AddressFamily.InterNetwork,
                                     SocketType.Dgram,
                                     ProtocolType.Udp);

            Socket.ExclusiveAddressUse = false;

            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            Socket.Bind(LocalEndpoint);
        }

    }

}