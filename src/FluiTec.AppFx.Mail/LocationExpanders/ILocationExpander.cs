﻿using System.Collections.Generic;

namespace FluiTec.AppFx.Mail.LocationExpanders
{
    /// <summary>Interface for location expander.</summary>
    public interface ILocationExpander
    {
        /// <summary>Enumerates expand in this collection.</summary>
        /// <param name="viewName"> Name of the view. </param>
        /// <returns>An enumerator that allows foreach to be used to process expand in this collection.</returns>
        IEnumerable<string> Expand(string viewName);
    }
}