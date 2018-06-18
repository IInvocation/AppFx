using System;
using FluentMigrator.Runner;
using FluentMigrator.Runner.VersionTableInfo;

namespace FluiTec.AppFx.Data.Dapper
{
    /// <summary>	A dapper data service. </summary>
    public abstract class DapperDataService : DataService
    {
        #region IDataService

        /// <summary>	Begins unit of work. </summary>
        /// <returns>	An IUnitOfWork. </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new DapperUnitOfWork(this);
        }

        /// <summary>Begins unit of work.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <exception cref="ArgumentException">        Thrown when one or more arguments have
        ///                                             unsupported or illegal values. </exception>
        /// <param name="other">    The other. </param>
        /// <returns>An IUnitOfWork.</returns>
        public override IUnitOfWork BeginUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException(
                    $"Incompatible implementation of UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}!");
            return new DapperUnitOfWork(this, (DapperUnitOfWork) other);
        }

        #endregion

        #region Constructors

        /// <summary>Specialised constructor for use only by derived class.</summary>
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        /// <param name="connectionString">     The connection string. </param>
        /// <param name="connectionFactory">    The connectionfactory. </param>
        protected DapperDataService(string connectionString, IConnectionFactory connectionFactory)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
            ConnectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        /// <summary>Specialised constructor for use only by derived class.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        /// 
        protected DapperDataService(IDapperServiceOptions options) :
            this(options?.ConnectionString, options?.ConnectionFactory)
        {
        }

        protected DapperDataService()
        {
        }

        #endregion

        #region IDisposbale

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        ///     Releases the unmanaged resources used by the FluiTec.AppFx.Data.Dapper.DapperDataService and
        ///     optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     True to release both managed and unmanaged resources; false to
        ///     release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            // nothing to do here yet
        }

        #endregion

        #region Properties

        /// <summary>	Gets or sets the connection string. </summary>
        /// <value>	The connection string. </value>
        public string ConnectionString { get; protected set; }

        /// <summary>	Gets or sets the connection factory. </summary>
        /// <value>	The connection factory. </value>
        public IConnectionFactory ConnectionFactory { get; protected set; }

        /// <summary>Gets or sets the type of the SQL.</summary>
        /// <value>The type of the SQL.</value>
        public abstract SqlType SqlType { get; }

        /// <summary>Gets or sets information describing the meta.</summary>
        /// <value>Information describing the meta.</value>
        public abstract IVersionTableMetaData MetaData { get; }

        #endregion

        #region Migration

        /// <summary>Determine if we can migrate.</summary>
        /// <returns>True if we can migrate, false if not.</returns>
        public override bool CanMigrate() => MetaData != null;

        /// <summary>Migrates the database.</summary>
        public override void Migrate()
        {
            var migrationRunner = new MigrationRunner(ConnectionString, MetaData.GetType(), SelectDatabase);
            migrationRunner.MigrateUp();
        }

        /// <summary>Select database.</summary>
        /// <param name="runner">  The migration-runner. </param>
        private void SelectDatabase(IMigrationRunnerBuilder runner)
        {
            switch (SqlType)
            {
                case SqlType.Mssql:
                    runner.AddSqlServer2014();
                    break;
                case SqlType.Mysql:
                    runner.AddMySql5();
                    break;
                case SqlType.Pgsql:
                    runner.AddPostgres();
                    break;
                case SqlType.Sqlite:
                    runner.AddSQLite();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion
    }
}