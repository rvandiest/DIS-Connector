﻿using System;
using System.Collections.Generic;

namespace DIS.OpenDIS.Enumerations.Cet2010
{
    public interface ICategoryOrCategoryRange : IGenericEntryDescription
    {
        ////List<ISubcategoryOrSubcategoryRange> Subcategories { get; set; }
        List<GenericEntryDescription> Subcategories { get; set; }
        ulong UId { get; set; }
    }
}
