﻿using System;
using FluentMigrator.Runner.VersionTableInfo;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Mysql;
using FluiTec.AppFx.Identity.Dapper.Migration;
using FluiTec.AppFx.Identity.Dapper.Mysql.Repositories;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Mysql
{
    /// <summary>	A mysql dapper identity data service. </summary>
    public class MysqlDapperIdentityDataService : MysqlDapperDataService, IIdentityDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        public MysqlDapperIdentityDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Properties

        /// <summary>	The name. </summary>
        public override string Name => "MysqlDapperIdentityDataService";

        /// <summary>Gets or sets information describing the meta.</summary>
        /// <value>Information describing the meta.</value>
        public override IVersionTableMetaData MetaData => new VersionTable();

        #endregion

        #region Methods

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserRepository>(work => new MysqlDapperUserRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClaimRepository>(work => new DapperClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IRoleRepository>(work => new MysqlDapperRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserRoleRepository>(work => new DapperUserRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserLoginRepository>(work => new MysqlDapperUserLoginRepository(work)));
        }

        #endregion

        #region IIdentityDataService

        /// <summary>	Starts unit of work. </summary>
        /// <returns>	An IIdentityUnitOfWork. </returns>
        public virtual IIdentityUnitOfWork StartUnitOfWork()
        {
            return new DapperIdentityUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IIdentityUnitOfWork.</returns>
        public IIdentityUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is DapperUnitOfWork))
                throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(DapperUnitOfWork)}");
            return new DapperIdentityUnitOfWork(this, (DapperUnitOfWork)other);
        }

        /// <summary>
        ///     Begins unit of work.
        /// </summary>
        /// <returns>
        ///     An IUnitOfWork.
        /// </returns>
        public override IUnitOfWork BeginUnitOfWork()
        {
            return new DapperIdentityUnitOfWork(this);
        }

        #endregion
    }
}