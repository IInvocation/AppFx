﻿using System;
using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.DataProtection.Dapper.Migration;
using FluiTec.AppFx.DataProtection.Dapper.Repositories;
using FluiTec.AppFx.DataProtection.Repositories;

namespace FluiTec.AppFx.DataProtection.Mysql
{
    /// <summary>   A mysql dapper data protection data service. </summary>
    public class MysqlDapperDataProtectionDataService : MysqlDapperDataService, IDataProtectionDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        public MysqlDapperDataProtectionDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region IDataProtectionDataService

        /// <summary>	Starts unit of work. </summary>
        /// <returns>	An IIdentityUnitOfWork. </returns>
        public virtual IDataProtectionUnitOfWork StartUnitOfWork()
        {
            return new Dapper.DapperDataProtectionUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IIdentityUnitOfWork.</returns>
        public IDataProtectionUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}");
            return new Dapper.DapperDataProtectionUnitOfWork(this, (DapperUnitOfWork)other);
        }

        #endregion

        #region Properties

        /// <summary>	The name. </summary>
        public override string Name => "MysqlDapperDataProtectionDataService";

        /// <summary>Gets or sets information describing the meta.</summary>
        /// <value>Information describing the meta.</value>
        public override IVersionTableMetaData MetaData => new VersionTable();

        #endregion

        #region Methods

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IDataProtectionKeyRepository>(work => new DapperDataProtectionKeyRepository(work)));
        }

        #endregion
    }
}
