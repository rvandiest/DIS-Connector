# Easy DIS (Distributed Interactive Simulation) Connectivity using DIS Connector

## Installation

The dist folder contains the releases in folders named by their version number. Use the highest number to have the newest stable release.
Copy the DLL's in the folder to your project and reference them to use this library.

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
using DIS.Core;
using DIS.Dis1998;
using DIS.Enumerations;
using DIS.Enumerations.EntityState.Type;

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

##### Sending a PDU
It's also possible to decode a PDU to a JSON string.
```c#
foreach (Pdu pdu in conn.GetEnqueuedPDUs())
{
    //if you want the PDU to be accompanied with a "details field", pass true.
    Console.WriteLine(JSONDecoder.Decode(pdu, true));
    /*
    results in:
    {
        "EntityID": {
            "Site": 0,
            "Application": 1,
            "Entity": 2
        },
        "ForceID": 0,
        "NumberOfArticulationParameters": 0,
        "EntityType": {
            "EntityKind": {
            "Value": 3,
            "Details": "Life form"
            },
            "Domain": {
            "Value": 1,
            "Details": "Land"
            },
            "Country": {
            "Value": 153,
            "Details": "Netherlands (NLD)"
            },
            "Category": {
            "Value": 10,
            "Details": "Conventional Armed Forces64"
            },
            "Subcategory": {
            "Value": 1
            },
            "Specific": {
            "Value": 1
            },
            "Extra": {
            "Value": 1
            }
        }
        ..etc
    }
    */ 

    //if set to false, the field types are primitives.
    Console.WriteLine(JSONDecoder.Decode(pdu, true));
    /*
    results in:
    {
        "EntityID": {
            "Site": 0,
            "Application": 1,
            "Entity": 2
        },
        "ForceID": 0,
        "NumberOfArticulationParameters": 0,
        "EntityType": {
            "EntityKind": 3,
            "Domain": 1,
            "Country":153,
            "Category": 10,
            "Subcategory" : 1,
            "Specific": 1,
            "Extra": 1
        }
        ..etc
    }
    */     
}
```