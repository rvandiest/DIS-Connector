using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DIS.Core;
using DIS.Dis1998;
using Utilties.Networking;

namespace DIS
{
    /// <summary>
    /// The Connector class is the "base" for multicast connections. This class
    /// Enables for both sending and receiving PDU's from given multicast addresses.
    /// For more help, see:
    /// https://github.com/rvandiest/DIS-Connector
    /// </summary>
    public class Connector
    {
        private Thread ReceiveThread { get; set; }
        private Queue<Pdu> PduQueue { get; set; }
        private PduProcessor PduProcessor { get; set; }
        private int Port { get; set; }
        private UdpClient UdpClient { get; set; }
        private IPEndPoint LocalEndPoint;

        //basic setup for the properties that are the same for every child class
        internal Connector(int port)
        {
            Port = port;
            LocalEndPoint = new IPEndPoint(IPAddress.Any, 0);

            UdpClient = new UdpClient(Port);

            PduProcessor = new PduProcessor();
            PduProcessor.Endian = Endian.Big;

            PduQueue = new Queue<Pdu>();
        }

        /// <summary>
        /// This method sets up the ReceiveThread property. This thread runs in the background
        /// and collects all received DIS PDU's.
        /// </summary>
        private void ThreadSetup()
        {
            ReceiveThread = new Thread(new ThreadStart(ListenerLoop));
            ReceiveThread.IsBackground = true;
        }

        /// <summary>
        /// Starts the background thread that listens for incoming PDU's.
        /// </summary>
        public void StartListening()
        {
            ThreadSetup();
            ReceiveThread.Start();
        }

        /// <summary>
        /// Suspends the listening for incoming PDU's. 
        /// </summary>
        public void StopListening()
        {
            ReceiveThread.Abort();
        }

        /// <summary>
        /// Ever ongoing loop that waits for incoming PDU's.
        /// Received PDU's are enqueued in the PduQueue property.
        /// </summary>
        protected virtual void ListenerLoop()
        {

            while (true)
            {
                List<object> pduList;

                byte[] bytes = UdpClient.Receive(ref LocalEndPoint);
                pduList = PduProcessor.ProcessPdu(bytes, Endian.Big);
                lock (PduQueue)
                {
                    foreach (object pduObj in pduList)
                    {
                        PduQueue.Enqueue((Pdu)pduObj);
                    }
                }
            }

        }

        /// <summary>
        /// Suspends the listening for incoming PDU's. 
        /// <param name="pdu">The PDU to be transmitted</param>
        /// </summary>
        public void sendPDU(IMarshallable pdu, MulticastGroup group)
        {
            DataOutputStream dos = new DataOutputStream(Endian.Big);
            pdu.MarshalAutoLengthSet(dos);
            byte[] data = dos.ConvertToBytes();
            UdpClient.Send(data, data.Length, new IPEndPoint(group.Address, Port));
        }

        /// <summary>
        /// Get all PDU's that were received since the last time
        /// this method was called.
        /// <returns>
        /// A collection of PDU's.
        /// </returns>
        /// </summary>
        public List<Pdu> GetEnqueuedPDUs()
        {
            lock (PduQueue)
            {
                List<Pdu> results = new List<Pdu>();
                while (PduQueue.Count != 0)
                {
                    results.Add(PduQueue.Dequeue());
                }
                return results;
            }
        }

        /// <summary>
        /// Enables multicasting PDU's to specified address, and receive PDU's likewise. 
        /// sent from that address.
        /// <param name="group">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        /// </summary>
        public void JoinMulticastGroup(MulticastGroup group)
        {
            UdpClient.JoinMulticastGroup(group.Address, 50);
        }

    }

}