﻿using System.Collections.Generic;

namespace FluiTec.AppFx.Data
{
    /// <summary>	Interface for a read only data repository. </summary>
    /// <typeparam name="TEntity">	Type of the entity. </typeparam>
    /// <typeparam name="TKey">   	Type of the key. </typeparam>
    public interface IReadOnlyDataRepository<out TEntity, in TKey> : IRepository
        where TEntity : class, IEntity<TKey>, new()
    {
        /// <summary>	Gets the name of the table. </summary>
        /// <value>	The name of the table. </value>
        string TableName { get; }

        /// <summary>	Gets an entity using the given identifier. </summary>
        /// <param name="id">	The Identifier to use. </param>
        /// <returns>	A TEntity. </returns>
        TEntity Get(TKey id);

        /// <summary>	Gets all entities in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        IEnumerable<TEntity> GetAll();

        /// <summary>Gets the count.</summary>
        /// <returns>An int.</returns>
        int Count();
    }
}