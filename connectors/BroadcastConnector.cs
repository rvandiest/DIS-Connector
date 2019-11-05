using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using DIS.Dis1998;

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
        /// <param name="server">The IP address of the server to connect to.</param>
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        internal BroadcastConnector(IPAddress server, int port)
        {
            Port = port;
            PduQueue = new Queue<Pdu>();

            Endpoint = (EndPoint)new IPEndPoint(server, Port);

            Socket = new Socket(AddressFamily.InterNetwork,
                                     SocketType.Dgram,
                                     ProtocolType.Udp);

            Socket.ExclusiveAddressUse = false;

            Socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);

            Socket.Connect(Endpoint);
        }

    }

}