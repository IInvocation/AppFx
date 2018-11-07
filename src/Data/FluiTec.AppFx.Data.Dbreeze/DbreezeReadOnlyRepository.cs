using System;
using System.Collections.Generic;
using System.Linq;

namespace FluiTec.AppFx.Data.Dbreeze
{
    /// <summary>   A dbreeze read only repository. </summary>
    /// <typeparam name="TEntity">  Type of the entity. </typeparam>
    /// <typeparam name="TKey">     Type of the key. </typeparam>
    public abstract class DbreezeReadOnlyRepository<TEntity, TKey> : IReadOnlyDataRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IConvertible
    {
        #region Constructors

        protected DbreezeReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork as DbreezeUnitOfWork;
            if (UnitOfWork == null)
                throw new ArgumentException(
                    $"{nameof(unitOfWork)} was either null or does not implement {nameof(DbreezeUnitOfWork)}!");

            var replacedDot = GetTableName(typeof(TEntity)).Replace('.', '_');
            var split = replacedDot.Split('_');
            if (split.Length > 1)
            {
                split[0] = new string(split[0].Where(char.IsUpper).ToArray());
                replacedDot = string.Concat(split);
            }

            TableName = replacedDot;
        }

        #endregion

        #region Properties

        /// <summary>   Gets the name of the table. </summary>
        /// <value> The name of the table. </value>
        public virtual string TableName { get; }

        /// <summary>   Gets the unit of work. </summary>
        /// <value> The unit of work. </value>
        public DbreezeUnitOfWork UnitOfWork { get; }

        #endregion

        #region Methods

        /// <summary>	Gets table name. </summary>
        /// <returns>	The table name. </returns>
        protected string GetTableName(Type t)
        {
            return UnitOfWork.DbreezeDataService.NameService.NameByType(t);
        }

        #endregion

        #region IReadOnlyRepository

        /// <summary>   Gets an entity using the given identifier. </summary>
        /// <param name="id">   The Identifier to use. </param>
        /// <returns>   A TEntity. </returns>
        public TEntity Get(TKey id)
        {
            return UnitOfWork.Transaction.Select<TKey, TEntity>(TableName, id).Value;
        }

        /// <summary>   Gets all entities in this collection. </summary>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process all items in this collection.
        /// </returns>
        public IEnumerable<TEntity> GetAll()
        {
            return UnitOfWork.Transaction.SelectForward<TKey, TEntity>(TableName).Select(e => e.Value);
        }

        /// <summary>   Gets the count. </summary>
        /// <returns>   An int. </returns>
        public int Count()
        {
            return (int)UnitOfWork.Transaction.Count(TableName);
        }

        #endregion
    }

    /// <summary>   A dbreeze repository. </summary>
    /// <typeparam name="TEntity">  Type of the entity. </typeparam>
    /// <typeparam name="TKey">     Type of the key. </typeparam>
    public abstract class DbreezeRepository<TEntity, TKey> : DbreezeReadOnlyRepository<TEntity, TKey>, IDataRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
        where TKey : IConvertible
    {
        #region Constructors

        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        protected DbreezeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region IDataRepository
        
        public TEntity Add(TEntity entity)
        {
            var currentKey = UnitOfWork.Transaction.Max<TKey, TEntity>(TableName).Key;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TKey id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
