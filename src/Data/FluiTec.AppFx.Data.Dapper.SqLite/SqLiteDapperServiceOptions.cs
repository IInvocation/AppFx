using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Data.Dapper.SqLite
{
    [ConfigurationName("Dapper")]
    public class SqLiteDapperServiceOptions : DapperServiceOptions
    {
        /// <summary>	Default constructor. </summary>
        public SqLiteDapperServiceOptions()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            ConnectionFactory = new SqLiteConnectionFactory();
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