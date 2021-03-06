﻿using System;
using System.Collections.Generic;
using Dapper;
using FluiTec.AppFx.Data.Sql;

namespace FluiTec.AppFx.Data.Dapper
{
    /// <summary>	A dapper read only repository. </summary>
    /// <typeparam name="TEntity">	Type of the entity. </typeparam>
    /// <typeparam name="TKey">   	Type of the key. </typeparam>
    public abstract class DapperReadOnlyRepository<TEntity, TKey> : IReadOnlyDataRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        protected DapperReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork as DapperUnitOfWork;
            if (UnitOfWork == null)
                throw new ArgumentException(
                    $"{nameof(unitOfWork)} was either null or does not implement {nameof(DapperUnitOfWork)}!");

            SqlBuilder = UnitOfWork.Connection.GetBuilder();
            TableName = GetTableName(typeof(TEntity));
            EntityType = typeof(TEntity);
        }

        #endregion

        #region Methods

        /// <summary>	Gets table name. </summary>
        /// <returns>	The table name. </returns>
        protected string GetTableName(Type t)
        {
            return SqlBuilder.Adapter.RenderTableName(t);
        }

        #endregion

        #region Properties

        /// <summary>   Gets the name of the table. </summary>
        /// <value> The name of the table. </value>
        public virtual string TableName { get; }

        /// <summary>   Gets the unit of work. </summary>
        /// <value> The unit of work. </value>
        public DapperUnitOfWork UnitOfWork { get; }

        /// <summary>	Gets the SQL builder. </summary>
        /// <value>	The SQL builder. </value>
        protected SqlBuilder SqlBuilder { get; }

        /// <summary>	Gets the type of the entity. </summary>
        /// <value>	The type of the entity. </value>
        protected Type EntityType { get; }

        #endregion

        #region IReadOnlyRepository

        /// <summary>	Gets a t entity using the given identifier. </summary>
        /// <param name="id">	The Identifier to get. </param>
        /// <returns>	A TEntity. </returns>
        public virtual TEntity Get(TKey id)
        {
            return UnitOfWork.Connection.Get<TEntity>(id, UnitOfWork.Transaction);
        }

        /// <summary>	Gets all items in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return UnitOfWork.Connection.GetAll<TEntity>(UnitOfWork.Transaction);
        }

        /// <summary>Gets the count.</summary>
        /// <returns>An int.</returns>
        public int Count()
        {
            var command = $"SELECT COUNT({SqlBuilder.Adapter.RenderPropertyName(nameof(IEntity<int>.Id))}) FROM {TableName}";
            return UnitOfWork.Connection.ExecuteScalar<int>(command, null, UnitOfWork.Transaction);
        }

        #endregion
    }
}