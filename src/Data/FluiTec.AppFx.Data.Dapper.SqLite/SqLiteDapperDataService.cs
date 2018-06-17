namespace FluiTec.AppFx.Data.Dapper.SqLite
{
    /// <summary>   A sq lite dapper data service. </summary>
    public abstract class SqLiteDapperDataService : DapperDataService
    {
        #region Constructors

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="connectionString">     The connection string. </param>
        /// <param name="connectionFactory">    The connection factory. </param>
        protected SqLiteDapperDataService(string connectionString, IConnectionFactory connectionFactory) : base(
            connectionString, connectionFactory)
        {
        }

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="options">  Options for controlling the operation. </param>
        protected SqLiteDapperDataService(IDapperServiceOptions options) : base(options)
        {
        }

        #endregion

        #region Migration

        /// <summary>Gets or sets the type of the SQL.</summary>
        /// <value>The type of the SQL.</value>
        public override SqlType SqlType => SqlType.Sqlite;

        #endregion
    }
}