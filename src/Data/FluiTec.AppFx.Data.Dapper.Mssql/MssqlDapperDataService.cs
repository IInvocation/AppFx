﻿namespace FluiTec.AppFx.Data.Dapper.Mssql
{
    /// <summary>	A mssql dapper data service. </summary>
    public abstract class MssqlDapperDataService : DapperDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="connectionString">	The connection string. </param>
        protected MssqlDapperDataService(string connectionString) : base(connectionString, new MssqlConnectionFactory())
        {
        }

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        protected MssqlDapperDataService(IDapperServiceOptions options) : base(options)
        {
        }

        #endregion

        #region Migration

        /// <summary>Gets or sets the type of the SQL.</summary>
        /// <value>The type of the SQL.</value>
        public override SqlType SqlType => SqlType.Mssql;

        #endregion
    }
}