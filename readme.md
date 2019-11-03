# Easy DIS (Distributed Interactive Simulation) Connectivity using DIS Connector

## Installation

Reference the prebuilt binary (.dll), or add this source code to your project.

### code examples
#### Using multicasting
##### multicast connector instantiation
```c#
    /*
    use the factory to get your instantiation
    this example uses the following parameters:
    - remote IP address of 192.168.178.150
    - multicast group 224.5.6.7
    - port 6400
    */
    Connector conn = DIS.ConnectorFactory.getMulticastConnector(IPAddress.Parse("192.168.178.150"), IPAddress.Parse("224.5.6.7"), 6400);
```

##### multicast connector instantiation
```c#
    /*
    use the factory to get your instantiation
    this example uses the following parameters:
    - remote IP address of 192.168.178.150
    - port 6400
    */
    Connector conn = DIS.ConnectorFactory.getBroadcastConnector(IPAddress.Parse("192.168.178.150"), 6400);
```
##### listening for incoming PDU's
```c#
    //start the background listener
    conn.startListening();
    //ongoing loop for the sake of this demonstration
    while(true){
        //get all pdu's that were received by the connector. When you call this 
        //method, the queue is emptied.
        foreach(object ob in conn.GetEnqueuedPDUs()){
            Console.WriteLine(ob.ToString());
        }
    }
```