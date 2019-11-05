# Easy DIS (Distributed Interactive Simulation) Connectivity using DIS Connector

## Installation

Reference the prebuilt binary (DIS Connector.dll), or add this source code to your project.

### code examples
#### Using the connectors
##### Multicast connector instantiation
```c#
/*
use the factory to get your instantiation
this example uses the following parameters:
- remote IP address of 192.168.178.150
- multicast group 224.5.6.7
- port 6400
*/
Connector conn = DIS.ConnectorFactory.getMulticastConnector(IPAddress.Parse("224.5.6.7"), 6400);
```

##### Multicast connector instantiation
```c#
/*
use the factory to get your instantiation
this example uses the following parameters:
- remote IP address of 192.168.178.150
- port 6400
*/
Connector conn = DIS.ConnectorFactory.getBroadcastConnector(6400);
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
using Dis.OpenDis.Core;
using Dis.OpenDis.Dis1998;
using Dis.OpenDis.Enumerations;
using Dis.OpenDis.Enumerations.EntityState.Type;

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

conn.sendPDU(espdu)
```