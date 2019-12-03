using System.IO;
using System.Text;
using DIS.Dis1998;
using Newtonsoft.Json;

/// <summary>
/// Contains decoder classes to decode PDU's to a different data representation.
/// </summary>
namespace DIS.Decoders
{
    /// <summary>
    /// Contains methods to decode PDU's to a JSON string representation.
    /// </summary>
    public static class JSONDecoder
    {
        /// <summary>
        /// Decodes a PDU instance to a JSON string.
        /// </summary>
        /// <param name="pdu"><see cref="DIS.Dis1998.Pdu"/> instance to be decoded</param>
        /// <param name="detailed">Whether or not to add a details field where possible.</param>
        /// <returns></returns>
        public static string Decode(Pdu pdu, bool detailed)
        {
            if (pdu is EntityStatePdu && detailed)
            {
                EntityStatePdu espdu = (EntityStatePdu)pdu;
                EntityID eid = espdu.EntityID;
                EntityType et = espdu.EntityType;
                EntityType altet = espdu.AlternativeEntityType;

                return JsonConvert.SerializeObject(new
                {
                    EntityID = espdu.EntityID,
                    ForceID = espdu.ForceId,
                    NumberOfArticulationParameters = espdu.NumberOfArticulationParameters,
                    EntityType = new
                    {
                        EntityKind = new
                        {
                            Value = et.EntityKind,
                            Details = Enumerations.GetPlatform(et.EntityKind)
                        },
                        Domain = new
                        {
                            Value = et.Domain,
                            Details = Enumerations.GetDomain(et.Domain)
                        },
                        Country = new
                        {
                            Value = et.Country,
                            Details = Enumerations.GetCountry(et.Country),
                        },
                        Category = new
                        {
                            Value = et.Category,
                            Details = Enumerations.GetCategory(et.EntityKind, et.Domain, et.Category),
                        },
                        Subcategory = new
                        {
                            Value = et.Subcategory,
                            //Details = Enumerations.GetSubcategory(et.Subcategory, et.Domain, et.Category),
                        },
                        Specific = new
                        {
                            Value = et.Subcategory,
                            //Details = Enumerations.GetSpecific(et.Specific, et.Domain, et.Category),
                        },
                        Extra = new
                        {
                            Value = et.Extra,
                            //Details = Enumerations.GetExtra(et.Extra, et.Domain, et.Category),
                        },
                    },
                    AlternativeEntityType = new
                    {
                        EntityKind = new
                        {
                            Value = et.EntityKind,
                            Details = Enumerations.GetPlatform(altet.EntityKind)
                        },
                        Domain = new
                        {
                            Value = et.Domain,
                            Details = Enumerations.GetDomain(altet.Domain)
                        },
                        Country = new
                        {
                            Value = et.Country,
                            Details = Enumerations.GetCountry(altet.Country),
                        },
                        Category = new
                        {
                            Value = et.Category,
                            Details = Enumerations.GetCategory(altet.EntityKind, altet.Domain, altet.Category),
                        },
                        Subcategory = new
                        {
                            Value = et.Subcategory,
                            //Details = Enumerations.GetSubcategory(altet.Subcategory, altet.Domain, altet.Category),
                        },
                        Specific = new
                        {
                            Value = et.Subcategory,
                            //Details = Enumerations.GetSpecific(altet.Specific, altet.Domain, altet.Category),
                        },
                        Extra = new
                        {
                            Value = et.Extra,
                            //Details = Enumerations.GetExtra(altet.Extra, altet.Domain, altet.Category),
                        },
                    },
                    EntityLinearVelocity = espdu.EntityLinearVelocity,
                    EntityLocation = espdu.EntityLocation,
                    EntityOrientation = espdu.EntityOrientation,
                    EntityAppearance = espdu.EntityAppearance,
                    DeadReckoningParameters = espdu.DeadReckoningParameters,
                    Marking = espdu.Marking,
                    Capabilities = espdu.Capabilities,
                    ArticulationParameters = espdu.ArticulationParameters,
                    ProtocolVersion = espdu.ProtocolVersion,
                    ExerciseID = espdu.ExerciseID,
                    PduType = espdu.PduType,
                    ProtocolFamily = espdu.ProtocolFamily,
                    Timestamp = espdu.Timestamp,
                    Length = espdu.Length,
                    Padding = espdu.Padding
                }, Formatting.Indented);

            }
            else return JsonConvert.SerializeObject(pdu, Formatting.Indented);
        }
    }
}