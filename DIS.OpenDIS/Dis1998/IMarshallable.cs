using DIS.OpenDIS.Core;

namespace DIS.OpenDIS.Dis1998
{
    /// <summary>
    /// I added this interface to the Open-DIS library to be able to send all different
    /// PDU's using a generic type.
    ///</summary>
    public interface IMarshallable
    {
        int GetMarshalledSize();
        void MarshalAutoLengthSet(DataOutputStream dos);
        void Marshal(DataOutputStream dos);
        void Unmarshal(DataInputStream dis);
    }
}