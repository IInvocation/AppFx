using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Data.Dapper.Pgsql
{
    [ConfigurationName("Dapper")]
    public class PgsqlDapperServiceOptions : DapperServiceOptions
    {
        /// <summary>	Default constructor. </summary>
        public PgsqlDapperServiceOptions()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            ConnectionFactory = new PgsqlConnectionFactory();
            // ReSharper enable VirtualMemberCallInConstructor
        }

        /// <summary>	Gets or sets the connection factory. </summary>
        /// <value>	The connection factory. </value>
        /// <remarks> Overridden to make this property visible as DeclaredProperty. </remarks>
        public override IConnectionFactory ConnectionFactory { get; set; }

        /// <summary>	Gets or sets the connection string. </summary>
        /// <value>	The connection string. </value>
        /// <remarks> Overridden to make this property visible as DeclaredProperty. </remarks>
        public override string ConnectionString { get; set; }
    }
}