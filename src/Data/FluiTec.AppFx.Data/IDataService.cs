﻿using System;

namespace FluiTec.AppFx.Data
{
    /// <summary>	Interface for a data service. </summary>
    public interface IDataService : IDisposable
    {
        /// <summary>	Gets the name. </summary>
        /// <value>	The name. </value>
        string Name { get; }

        /// <summary>	Begins unit of work. </summary>
        /// <returns>	An IUnitOfWork. </returns>
        IUnitOfWork BeginUnitOfWork();

        /// <summary>Begins unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IUnitOfWork.</returns>
        IUnitOfWork BeginUnitOfWork(IUnitOfWork other);

        /// <summary>	Registers the repository provider described by repositoryProvider. </summary>
        /// <typeparam name="TRepository">	Type of the repository. </typeparam>
        /// <param name="repositoryProvider">	The repository provider. </param>
        void RegisterRepositoryProvider<TRepository>(Func<IUnitOfWork, TRepository> repositoryProvider)
            where TRepository : class, IRepository;

        /// <summary>Determine if we can migrate.</summary>
        /// <returns>True if we can migrate, false if not.</returns>
        bool CanMigrate();

        /// <summary>Migrates this object.</summary>
        void Migrate();
    }
}