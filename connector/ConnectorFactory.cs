using System;
using System.Collections.Generic;
using System.Net;
using Utilties.Networking;

namespace DIS
{
    /// <summary>
    /// Factory to get Connector classes.
    /// </summary>
    public static class ConnectorFactory
    {
        //best to use singleton, to prevent socket connection errors
        static Connector instance;
        /// <summary>
        /// Get an instance of the connector class.
        /// <param name="port">The UDP port number.</param>
        /// </summary>
        public static Connector getInstance(int port)
        {
            if (instance == null)
            {
                instance = new Connector(port);
            }
            return instance;
        }

    }

}