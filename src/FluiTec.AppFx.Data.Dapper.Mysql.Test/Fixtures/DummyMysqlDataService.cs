using FluiTec.AppFx.UnitTesting.Helper;

namespace FluiTec.AppFx.Data.Dapper.Mysql.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyMysqlDataService : MysqlDapperDataService
    {
        /// <summary>	Default constructor. </summary>
        /// <remarks>
        ///     ConnectionReset=true is required because of a MySql-bug, see https://bugs.mysql.com/bug.php?id=71502
        /// </remarks>
        public DummyMysqlDataService() : base(ConnectionStringHelper.GetConnectionStringFor("MYSQL"),
            new MysqlConnectionFactory())
        {
        }

        /// <summary>	The name. </summary>
        public override string Name => "DummyMysqlDataService";
    }
}