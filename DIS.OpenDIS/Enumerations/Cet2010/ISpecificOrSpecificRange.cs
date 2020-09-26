using System;
using System.Collections.Generic;

namespace DIS.OpenDIS.Enumerations.Cet2010
{
    public interface ISpecificOrSpecificRange : IGenericEntryDescription
    {
        ////List<IExtraOrExtraRange> Extras {get; set;}
        List<GenericEntryDescription> Extras { get; set; }
        ulong UId { get; set; }
    }
}
