using Dapper;
using FluiTec.AppFx.Data.Sql;

namespace FluiTec.AppFx.Data.Dapper
{
    /// <summary>	A dapper predefined key repository. </summary>
    /// <typeparam name="TEntity">	Type of the entity. </typeparam>
    /// <typeparam name="TKey">   	Type of the key. </typeparam>
    public abstract class DapperPredefinedKeyRepository<TEntity, TKey> : DapperRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        #region Constructors

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        protected DapperPredefinedKeyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region Metods

        /// <summary>	Sets insert key. </summary>
        /// <param name="entity">	The entity to add. </param>
        protected abstract void SetInsertKey(TEntity entity);

        #endregion

        #region DapperRepository

        /// <summary>	Adds entity. </summary>
        /// <param name="entity">	The entity to add. </param>
        /// <returns>	A TEntity. </returns>
        public override TEntity Add(TEntity entity)
        {
            var type = typeof(TEntity);

            var builder = UnitOfWork.Connection.GetBuilder();
            var sql = builder.InsertAutoMultiple(type);

            UnitOfWork.Connection.Execute(sql, entity, UnitOfWork.Transaction);

            return entity;
        }

        #endregion
    }
}