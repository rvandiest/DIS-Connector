namespace DIS.Connections
{
    /// <summary>
    /// Factory to get Connector classes.
    /// </summary>
    public static class ConnectorFactory
    {
        //best to use singleton, to prevent socket connection errors
        static Connector instance;

        /// <summary>
        ///  Get an instance of <see cref="DIS.Connector"/>.
        /// </summary>
        /// <param name="port">The UDP port number.</param>
        /// <param name="buffersize">The maximum number of PDU's to be stored in the buffer. The default size is 10000.  If the buffer overflows, 
        /// the oldest PDU is disposed of, and the newest is added to the buffer.</param>
        /// <returns>
        /// An instance of <see cref="DIS.Connector"/>
        /// </returns>
        public static Connector getInstance(int port, int buffersize)
        {
            if (instance == null)
            {
                instance = new Connector(port, buffersize);
            }
            else{
                instance.BufferSize = buffersize;
            }
            return instance;
        }

        /// <summary>
        ///  Get an instance of <see cref="DIS.Connector"/>.
        /// </summary>
        /// <param name="port">The UDP port number.</param>
        /// <returns>
        /// An instance of <see cref="DIS.Connector"/>
        /// </returns>
        public static Connector getInstance(int port)
        {
            return getInstance(port, 10000);
        }

    }

}