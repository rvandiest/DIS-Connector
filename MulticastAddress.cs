using System;
using System.Net;

namespace Utilties.Networking
{
    public struct MulticastGroup
    {
        //224.0.0.0 to 239.255.255.255
        public IPAddress Address { get; private set; }
        private MulticastGroup(string address)
        {
            string[] chunks = address.Split('.');
            if (chunks.Length != 4)
            {
                throw new InvalidMulticastGroupException(string.Format("Invalid multicast group length. (Size is {0}, should be 4)", chunks.Length));
            }
            else
            {
                try
                {
                    short chunk1 = Int16.Parse(chunks[0]);
                    short chunk2 = Int16.Parse(chunks[1]);
                    short chunk3 = Int16.Parse(chunks[2]);
                    short chunk4 = Int16.Parse(chunks[3]);

                    if (chunk1 < 224 || chunk1 > 239)
                    {
                        throw new InvalidMulticastGroupException(string.Format("Invalid multicast group. Multicast groups range from 224.0.0.0 to 239.255.255.255. (Given group:{0})", address));
                    }
                    else if (chunk2 < 0 || chunk2 > 255)
                    {
                        throw new InvalidMulticastGroupException(string.Format("Invalid multicast group. Multicast groups range from 224.0.0.0 to 239.255.255.255. (Given group:{0})", address));
                    }
                    else if (chunk3 < 0 || chunk3 > 255)
                    {
                        throw new InvalidMulticastGroupException(string.Format("Invalid multicast group. Multicast groups range from 224.0.0.0 to 239.255.255.255. (Given group:{0})", address));
                    }
                    else if (chunk4 < 0 || chunk4 > 255)
                    {
                        throw new InvalidMulticastGroupException(string.Format("Invalid multicast group. Multicast groups range from 224.0.0.0 to 239.255.255.255. (Given group:{0})", address));
                    }

                    Address = IPAddress.Parse(address);
                }
                catch (ArgumentException)
                {
                    throw new ArgumentException("(Part of) the group could not be parsed. Did you supply a valid IP address?");
                }

            }
        }
        public static MulticastGroup Parse(string address)
        {
            return new MulticastGroup(address);
        }
    }

    [System.Serializable]
    public class InvalidMulticastGroupException : System.Exception
    {
        public InvalidMulticastGroupException() { }
        public InvalidMulticastGroupException(string message) : base(message) { }
        public InvalidMulticastGroupException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidMulticastGroupException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}