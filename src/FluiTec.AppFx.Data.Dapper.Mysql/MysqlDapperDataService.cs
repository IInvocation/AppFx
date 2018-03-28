namespace FluiTec.AppFx.Data.Dapper.Mysql
{
    /// <summary>	A mysql dapper data service. </summary>
    public abstract class MysqlDapperDataService : DapperDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="connectionString"> 	The connection string. </param>
        /// <param name="connectionFactory">	The connection factory. </param>
        protected MysqlDapperDataService(string connectionString, IConnectionFactory connectionFactory) : base(
            connectionString, connectionFactory)
        {
        }

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        protected MysqlDapperDataService(IDapperServiceOptions options) : base(options)
        {
        }

        #endregion
    }
}