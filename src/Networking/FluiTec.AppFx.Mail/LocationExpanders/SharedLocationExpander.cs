﻿using System.Collections.Generic;

namespace FluiTec.AppFx.Mail.LocationExpanders
{
    /// <summary>A shared location expander.</summary>
    public class SharedLocationExpander : ILocationExpander
    {
        /// <summary>Enumerates expand in this collection.</summary>
        /// <param name="viewName"> Name of the view. </param>
        /// <returns>An enumerator that allows foreach to be used to process expand in this collection.</returns>
        public IEnumerable<string> Expand(string viewName)
        {
            return new[] {$"Shared/{viewName}"};
        }
    }
}