﻿namespace FluiTec.AppFx.Data.LiteDb
{
    /// <summary>	Interface for lite database options. </summary>
    public interface ILiteDbServiceOptions
    {
        /// <summary>	Gets or sets the filename of the database file. </summary>
        /// <value>	The filename of the database file. </value>
        string DbFileName { get; set; }

        /// <summary>	Gets or sets the pathname of the application folder. </summary>
        /// <value>	The pathname of the application folder. </value>
        string ApplicationFolder { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this object use singleton connection.
        /// </summary>
        /// <value>	True if use singleton connection, false if not. </value>
        bool UseSingletonConnection { get; set; }
    }
}