﻿namespace FluiTec.AppFx.Data.Dynamic.Configuration
{
    /// <summary>   A dynamic data options. </summary>
    /// <remarks>
    /// You'll probably want to use the 'ConfigurationName'-Attribute on derived classes
    /// </remarks>
    public abstract class DynamicDataOptions
    {
        /// <summary>   Gets or sets the provider. </summary>
        /// <value> The provider. </value>
        public DataProvider Provider { get; set; }
    }
}
