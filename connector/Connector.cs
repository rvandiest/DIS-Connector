using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using DIS.Core;
using DIS.Dis1998;
using DIS.Utilties.Networking;

namespace DIS
{
    /// <summary>
    /// The Connector class is the "base" for multicast connections. This class
    /// Enables for both sending and receiving PDU's from given multicast addresses.
    /// </summary>
    public class Connector
    {
        /// <summary>
        /// The UDP port to bind the listener to.
        /// </summary>
        private int Port { get; set; }

        /// <summary>
        /// <see cref="System.Net.Sockets.UdpClient"/>
        /// </summary>
        private UdpClient UdpClient { get; set; }

        /// <summary>
        /// <see cref="System.Net.IPEndPoint"/>
        /// </summary>
        private IPEndPoint LocalEndPoint;

        /// <summary>
        /// The maximum number of PDU's to be stored in the buffer. The default size is 10000.
        /// If the buffer overflows, the oldest PDU is disposed of, and the newest is added to the buffer.
        /// </summary>
        public int BufferSize { get; set; }

        /// <summary>
        /// This thread runs in the background and collects all PDU's sent to addresses that were joined.
        /// </summary>
        private Thread ReceiveThread { get; set; }

        /// <summary>
        /// This queue collects all PDU's that were collected by the ReceiveThread process. When the user 
        /// calls the GetEnqueuedPDUs method, the queue is emptied. 
        /// <see cref="Connector.ReceiveThread">
        /// <see cref="Connector.GetEnqueuedPDUs">
        /// </summary>
        private Queue<Pdu> PduQueue { get; set; }

        /// <summary>
        /// Decodes bytes to PDU's.
        /// <see cref="DIS.Core.PduProcessor"/>
        /// </summary>
        private PduProcessor PduProcessor { get; set; }

        /// <summary>
        /// Sets up the connector.
        /// </summary>
        /// <param name="port">UDP port number to bind the listener to.</param>
        internal Connector(int port) : this(port, 10000) { }

        /// <summary>
        /// Sets up the connector.
        /// </summary>
        /// <param name="port">UDP port number to bind the listener to.</param>
        /// <param name="buffersize">The maximum number of PDU's to be stored in the buffer.</param>
        internal Connector(int port, int buffersize)
        {
            BufferSize = buffersize;
            Port = port;
            LocalEndPoint = new IPEndPoint(IPAddress.Any, 0);

            UdpClient = new UdpClient(Port);

            PduProcessor = new PduProcessor();
            PduProcessor.Endian = Endian.Big;

            PduQueue = new Queue<Pdu>();
        }


        /// <summary>
        /// Disposes of the instance and it's members.
        /// </summary>
        ~Connector()
        {
            StopListening();
            UdpClient.Dispose();
        }

        /// <summary>
        /// Sets up the ReceiveThread property. This thread runs in the background
        /// and collects all received DIS PDU's.
        /// </summary>
        private void ThreadSetup()
        {
            ReceiveThread = new Thread(new ThreadStart(ReceiveLoop));
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
            FlushBuffer();
            ReceiveThread.Abort();
        }

        /// <summary>
        /// Ever ongoing loop that waits for incoming PDU's.
        /// Received PDU's are enqueued in the PduQueue property.
        /// </summary>
        protected virtual void ReceiveLoop()
        {
            while (true)
            {
                byte[] bytes = UdpClient.Receive(ref LocalEndPoint);
                processPDUs(bytes);
            }
        }

        /// <summary>
        /// Asynchrously processes bytes to pdu's and adds them to the queue.
        /// </summary>
        /// <param name="input">byte array to convert to one or multiple pdu's</param>
        protected virtual async void processPDUs(byte[] input)
        {
            await Task.Run(() =>
            {
                List<object> pduList = PduProcessor.ProcessPdu(input, Endian.Big);
                lock (PduQueue)
                {
                    foreach (object pduObj in pduList)
                    {
                        //check if the buffer has overflown
                        while (PduQueue.Count > BufferSize)
                        {
                            PduQueue.Dequeue();
                        }
                        PduQueue.Enqueue((Pdu)pduObj);
                    }
                }
            });

        }


        /// <summary>
        /// Suspends the listening for incoming PDU's. 
        /// </summary>
        /// <param name="pdu">The <see cref="DIS.Dis1998.IMarshallable"/> PDU to be transmitted</param>
        /// <param name="group">The <see cref="DIS.Utilties.Networking.MulticastGroup"/> to send this PDU to.</param>
        public void sendPDU(IMarshallable pdu, MulticastGroup group)
        {
            DataOutputStream dos = new DataOutputStream(Endian.Big);
            pdu.MarshalAutoLengthSet(dos);
            byte[] data = dos.ConvertToBytes();
            UdpClient.Send(data, data.Length, new IPEndPoint(group.Address, Port));
        }

        /// <summary>
        /// Wipes all stored PDU's from the memory. 
        /// </summary>
        public void FlushBuffer()
        {
            lock (PduQueue)
            {
                PduQueue = new Queue<Pdu>();
            }
        }

        /// <summary>
        /// Get all PDU's that were received since the last time
        /// this method was called.
        /// </summary>
        /// <returns>
        /// A collection of PDU's.
        /// </returns>
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
        /// </summary>
        /// <param name="group">The multicast group, ranging from 224.0.0.0 to 239.255.255.255.</param>
        public void JoinMulticastGroup(MulticastGroup group)
        {
            UdpClient.JoinMulticastGroup(group.Address, 50);
        }

    }

}