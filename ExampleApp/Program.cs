

using DIS.Connections;
using DIS.Utilties.Networking;
using System.Threading;
using System.Threading.Tasks;

namespace ExampleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			//get an instance of the connector from the factory
			Connector conn = ConnectorFactory.getInstance(6400);
			//then join a multicast group of your choice to send and receive PDU's from/to
			conn.JoinMulticastGroup(MulticastGroup.Parse("224.5.5.5"));

			IExample sendingExample, receivingExample;
			sendingExample = new SendingExample(conn);
			receivingExample = new ReceivingExample(conn);

			Thread t1 = new Thread(new ThreadStart(sendingExample.Demonstrate));
			Thread t2 = new Thread(new ThreadStart(receivingExample.Demonstrate));

			t1.Start();
			t2.Start();

		}
	}
}
