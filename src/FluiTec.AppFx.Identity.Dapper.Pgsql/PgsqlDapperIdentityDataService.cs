using System;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Data.Dapper.Pgsql;
using FluiTec.AppFx.Identity.Dapper.Pgsql.Repositories;
using FluiTec.AppFx.Identity.Dapper.Repositories;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Pgsql
{
    /// <summary>	A pgsql dapper identity data service. </summary>
    public class PgsqlDapperIdentityDataService : PgsqlDapperDataService, IIdentityDataService
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="options">	Options for controlling the operation. </param>
        public PgsqlDapperIdentityDataService(IDapperServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region IIdentityDataService

        /// <summary>	Starts unit of work. </summary>
        /// <returns>	An IIdentityUnitOfWork. </returns>
        public virtual IIdentityUnitOfWork StartUnitOfWork()
        {
            return new DapperIdentityUnitOfWork(this);
        }

        #endregion

        #region Properties

        /// <summary>	The name. </summary>
        public override string Name => "PgsqlDapperIdentityDataService";

        #endregion

        #region Methods

        /// <summary>	Registers the identity repositories. </summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserRepository>(work => new PgsqlDapperUserRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IClaimRepository>(work => new DapperClaimRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IRoleRepository>(work => new PgsqlDapperRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserRoleRepository>(work => new DapperUserRoleRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IUserLoginRepository>(work => new PgsqlDapperUserLoginRepository(work)));
        }

        #endregion
    }
}