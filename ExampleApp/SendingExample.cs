using DIS.Connections;
using DIS.OpenDIS.Core;
using DIS.OpenDIS.Dis1998;
using DIS.OpenDIS.Enumerations;
using DIS.OpenDIS.Enumerations.EntityState.Type;
using DIS.Utilties.Networking;
using System;
using System.Threading;

namespace ExampleApp
{
	class SendingExample : IExample
	{
		private readonly Connector _connector;
		public SendingExample(Connector connector)
		{
			_connector = connector;
		}
		public void Demonstrate()
		{
			Console.WriteLine("[SENDER - INFO] Started sending example");
			//Marnehuizen
			double lat = 53.3889139;
			double lon = 6.263677777777778;

			EntityStatePdu espdu = new EntityStatePdu();

			espdu.ExerciseID = 1;

			EntityID eid = espdu.EntityID;
			eid.Site = 0;
			eid.Application = 1;
			eid.Entity = 2;

			EntityType entityType = espdu.EntityType;
			entityType.Country = (ushort)Country.Netherlands; // NL
			entityType.EntityKind = (byte)EntityKind.LifeForm;// Life form (vs platform, munition, sensor, etc.)
			entityType.Domain = (byte)Platform.Land;          // Land (vs air, surface, subsurface, space)
			entityType.Category = 0;//empty
			entityType.Subcategory = 1;// Dismounted
			entityType.Specific = 5; //carrying an assault rifle
			entityType.Extra = 1; //Moving alone

			while (true)
			{
				lat += (1d / 11132000);
				lon += (1d / 40075) * Math.Cos(lat) / 360d;
				double[] disCoordinates = CoordinateConversions.getXYZfromLatLonDegrees(lat, lon, 0.0);

				Console.WriteLine("[SENDER - INFO] Entity is now at (lat:{0}, long:{1}", lat, lon);

				Vector3Double location = espdu.EntityLocation;
				location.X = disCoordinates[0];
				location.Y = disCoordinates[1];
				location.Z = disCoordinates[2];
				espdu.Timestamp = DisTime.DisRelativeTimestamp;

				//send the constructed PDU to the specified multicast group
				_connector.sendPDU(espdu, MulticastGroup.Parse("224.5.5.5"));
				Console.WriteLine("[SENDER - INFO] PDU broadcasted");

				Thread.Sleep(15000);
			}
		}
	}
}
