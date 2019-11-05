using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using DIS.Core;
using DIS.Dis1998;

namespace DIS
{
    /// <summary>
    /// The Connector class is an abstract base class for UDP socket connections.
    /// </summary>
    public abstract class Connector
    {
        Thread ReceiveThread { get; set; }
        protected Queue<Pdu> PduQueue { get; set; }
        protected PduProcessor PduProcessor { get; set; }
        protected int Port { get; set; }
        protected Socket Socket { get; set; }
        protected EndPoint Endpoint;

        //basic setup for the properties that are the same for every child class
        internal Connector()
        {
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

            byte[] bytes = new Byte[10000];
            int length = 0;

            while (true)
            {
                List<object> pduList;
                length = Socket.ReceiveFrom(bytes, ref Endpoint);
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
        public void sendPDU(IMarshallable pdu)
        {
            DataOutputStream dos = new DataOutputStream(Endian.Big);
            pdu.MarshalAutoLengthSet(dos);
            byte[] buff = dos.ConvertToBytes();
            Socket.SendTo(buff, Endpoint);
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

    }

}