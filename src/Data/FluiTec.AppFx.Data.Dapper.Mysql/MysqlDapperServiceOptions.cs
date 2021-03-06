﻿using FluiTec.AppFx.Options;

namespace FluiTec.AppFx.Data.Dapper.Mysql
{
    /// <summary>	A mysql dapper service options. </summary>
    [ConfigurationName("Dapper")]
    public class MysqlDapperServiceOptions : DapperServiceOptions
    {
        /// <summary>	Default constructor. </summary>
        public MysqlDapperServiceOptions()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            ConnectionFactory = new MysqlConnectionFactory();
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