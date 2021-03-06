﻿using System;
using System.Collections.Generic;

namespace FluiTec.AppFx.Data
{
    /// <summary>	An abstract, basic implementation of a data service. </summary>
    public abstract class DataService : IDataService
    {
        #region Constructors

        /// <summary>	Specialised default constructor for use only by derived class. </summary>
        /// <remarks>	Initializes the property <see cref="RepositoryProviders" />. </remarks>
        protected DataService()
        {
            RepositoryProviders = new Dictionary<Type, Func<IUnitOfWork, IRepository>>();
        }

        #endregion

        #region Properties

        /// <summary>	Gets the name. </summary>
        /// <value>	The name. </value>
        public abstract string Name { get; }

        /// <summary>	Gets the repository providers. </summary>
        /// <value>	The repository providers. </value>
        public Dictionary<Type, Func<IUnitOfWork, IRepository>> RepositoryProviders { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        public abstract void Dispose();

        /// <summary>	Begins unit of work. </summary>
        /// <returns>	An IUnitOfWork. </returns>
        public abstract IUnitOfWork BeginUnitOfWork();

        /// <summary>Begins unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IUnitOfWork.</returns>
        public abstract IUnitOfWork BeginUnitOfWork(IUnitOfWork other);

        /// <summary>	Registers the repository provider described by repositoryProvider. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when <see cref="repositoryProvider" /> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the provider was registered before.
        /// </exception>
        /// <typeparam name="TRepository">	Type of the repository. </typeparam>
        /// <param name="repositoryProvider">	The repository provider. </param>
        public void RegisterRepositoryProvider<TRepository>(Func<IUnitOfWork, TRepository> repositoryProvider)
            where TRepository : class, IRepository
        {
            if (repositoryProvider == null)
                throw new ArgumentNullException(nameof(repositoryProvider));
            var repoType = typeof(TRepository);
            if (RepositoryProviders.ContainsKey(repoType))
                throw new InvalidOperationException($"A provider for {repoType.Name} was already registerd!");

            RepositoryProviders.Add(repoType, repositoryProvider);
        }

        /// <summary>Determine if we can migrate.</summary>
        /// <returns>True if we can migrate, false if not.</returns>
        public abstract bool CanMigrate();

        /// <summary>Migrates this object.</summary>
        public abstract void Migrate();

        #endregion
    }
}