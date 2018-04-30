namespace FluiTec.AppFx.Data.Dapper.Pgsql
{
    /// <summary>	A pgsql dapper data service. </summary>
    public abstract class PgsqlDapperDataService : DapperDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="connectionString">	The connection string. </param>
        protected PgsqlDapperDataService(string connectionString) : base(connectionString, new PgsqlConnectionFactory())
        {
        }

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        protected PgsqlDapperDataService(IDapperServiceOptions options) : base(options)
        {
        }

        #endregion
    }
}