# Easy DIS (Distributed Interactive Simulation) Connectivity using DIS Connector

## Installation

Reference the prebuilt binary (DIS Connector.dll), or add this source code to your project.

### code examples
#### Using the connector
##### Multicast connector instantiation
```c#
//get an instance of the connector from the factory
Connector conn = DIS.ConnectorFactory.getInstance(6400);
//then join a multicast group of your choice to send and receive PDU's from/to
conn.JoinMulticastGroup(MulticastGroup.Parse("224.5.5.5"));
```

##### Listening for incoming PDU's
```c#
//start the background listener
conn.StartListening();
//ever ongoing loop for the sake of this example
while (true)
{
    foreach (Pdu pdu in conn.GetEnqueuedPDUs())
    {
        Console.WriteLine("Received PDU with timestamp {0}", pdu.Timestamp);
        //do with it whatever you want, but it usually requires casting to the appropiate PDU type
        if (pdu is EntityStatePdu)
        {
            Console.WriteLine("Received PDU is of type EntityState.");
            EntityStatePdu espdu = (EntityStatePdu)pdu;
            Console.WriteLine(
                "Entity ID:{0} \n Location: (x:{1}, y:{2}, z:{3})",
                espdu.EntityID,
                espdu.EntityLocation.X,
                espdu.EntityLocation.Y,
                espdu.EntityLocation.Z
            );
        }
        else if(pdu is DetonationPdu){
            DetonationPdu dpdu = (DetonationPdu)pdu;
            Console.WriteLine("Received PDU is of type Detonation.");
        }
    }
}
```

##### Sending a PDU
```c#
EntityStatePdu espdu = new EntityStatePdu();
using Dis.DIS.Core;
using Dis.DIS.Dis1998;
using Dis.DIS.Enumerations;
using Dis.DIS.Enumerations.EntityState.Type;

//Marnehuizen
double lat = 53.3889139;
double lon = 6.263677777777778;

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

double[] disCoordinates = CoordinateConversions.getXYZfromLatLonDegrees(lat, lon, 0.0);

Vector3Double location = espdu.EntityLocation;
location.X = disCoordinates[0];
location.Y = disCoordinates[1];
location.Z = disCoordinates[2];
espdu.Timestamp = DisTime.DisRelativeTimestamp;

//send the constructed PDU to the specified multicast group
conn.sendPDU(espdu, MulticastGroup.Parse("224.5.5.5"))
```