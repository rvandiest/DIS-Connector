using DIS.Connections;
using DIS.OpenDIS.Dis1998;
using System;

namespace ExampleApp
{
	class ReceivingExample : IExample
	{
		private readonly Connector _connector;
		public ReceivingExample(Connector connector)
		{
			_connector = connector;
		}

		public void Demonstrate()
		{
			//start the background listener
			_connector.StartListening();

			Console.WriteLine("[RECEIVER - INFO] Started receiving example");
			//ever ongoing loop for the sake of this example
			while (true)
			{
				foreach (Pdu pdu in _connector.GetEnqueuedPDUs())
				{
					Console.WriteLine("[RECEIVER - INFO] Received PDU with timestamp {0}", pdu.Timestamp);
					//do with it whatever you want, but it usually requires casting to the appropiate PDU type
					if (pdu is EntityStatePdu)
					{
						Console.WriteLine("[RECEIVER - INFO] Received PDU is of type EntityState.");
						EntityStatePdu espdu = (EntityStatePdu)pdu;
						Console.WriteLine(
							"[RECEIVER - INFO] Entity ID:{0} Location: (x:{1}, y:{2}, z:{3})",
							espdu.EntityID,
							espdu.EntityLocation.X,
							espdu.EntityLocation.Y,
							espdu.EntityLocation.Z
						);
					}
					else if (pdu is DetonationPdu)
					{
						DetonationPdu dpdu = (DetonationPdu)pdu;
						Console.WriteLine("[RECEIVER - INFO] Received PDU is of type Detonation.");
					}
				}
			}
		}
	}
}
