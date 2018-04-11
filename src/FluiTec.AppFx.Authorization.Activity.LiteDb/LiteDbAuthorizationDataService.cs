﻿using System;
using FluiTec.AppFx.Authorization.Activity.LiteDb.Repositories;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Activity.LiteDb
{
    /// <summary>A lite database authorization data service.</summary>
    public class LiteDbAuthorizationDataService : LiteDbDataService, IAuthorizationDataService
    {
        #region Properties

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public override string Name => "LiteDbAuthorizationDataService";

        #endregion

        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="useSingletonConnection">   The use singleton connection. </param>
        /// <param name="dbFilePath">               Full pathname of the database file. </param>
        /// <param name="applicationFolder">        (Optional) Pathname of the application folder. </param>
        public LiteDbAuthorizationDataService(bool? useSingletonConnection, string dbFilePath,
            string applicationFolder = null) : base(useSingletonConnection, dbFilePath, applicationFolder)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        /// <summary>Constructor.</summary>
        /// <param name="options">  Options for controlling the operation. </param>
        public LiteDbAuthorizationDataService(ILiteDbServiceOptions options) : base(options)
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            RegisterIdentityRepositories();
        }

        #endregion

        #region Methods

        /// <summary>Starts unit of work.</summary>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IAuthorizationUnitOfWork StartUnitOfWork()
        {
            return new LiteDbAuthorizationUnitOfWork(this);
        }

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        public IAuthorizationUnitOfWork StartUnitOfWork(IUnitOfWork other)
        {
            if (other == null) throw new ArgumentNullException(nameof(other));
            if (!(other is LiteDbUnitOfWork)) throw new ArgumentException($"Incompatible UnitOfWork. Must be of type {nameof(LiteDbUnitOfWork)}.");
            return new LiteDbAuthorizationUnitOfWork(this, (LiteDbUnitOfWork)other);
        }

        /// <summary>Registers the identity repositories.</summary>
        protected virtual void RegisterIdentityRepositories()
        {
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActivityRepository>(work => new LiteDbActivityRepository(work)));
            RegisterRepositoryProvider(
                new Func<IUnitOfWork, IActivityRoleRepository>(work => new LiteDbActivityRoleRepository(work)));
        }

        #endregion
    }
}