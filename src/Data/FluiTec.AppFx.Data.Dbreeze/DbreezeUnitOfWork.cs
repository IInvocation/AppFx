using System;
using DBreeze.Transactions;

namespace FluiTec.AppFx.Data.Dbreeze
{
    /// <summary>   A dbreeze unit of work. </summary>
    public class DbreezeUnitOfWork : UnitOfWork
    {
        #region Fields

        /// <summary>True to owns connection.</summary>
        private readonly bool _ownsConnection = true;

        #endregion

        #region Constructors

        /// <summary>   Constructor. </summary>
        /// <param name="dataService">  The data service. </param>
        public DbreezeUnitOfWork(DbreezeDataService dataService) : base(dataService)
        {
            DbreezeDataService = dataService;
            Transaction = DbreezeDataService.Database.GetTransaction();
        }

        /// <summary>   Constructor. </summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public DbreezeUnitOfWork(DbreezeDataService dataService, DbreezeUnitOfWork parentUnitOfWork) : base(dataService)
        {
            _ownsConnection = false;
            DbreezeDataService = dataService;
            Transaction = parentUnitOfWork.Transaction;
        }

        #endregion

        #region Properties

        /// <summary>   Gets the dbreeze data service. </summary>
        /// <value> The dbreeze data service. </value>
        public DbreezeDataService DbreezeDataService { get; }

        /// <summary>   Gets or sets the transaction. </summary>
        /// <value> The transaction. </value>
        public Transaction Transaction { get; private set; }

        #endregion

        #region IDisposable

        /// <summary>
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        ///     Releases the unmanaged resources used by the FluiTec.AppFx.Data.Dapper.DapperDataService and
        ///     optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     True to release both managed and unmanaged resources; false to
        ///     release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (Transaction != null)
                Rollback();
        }

        #endregion

        #region IUnitOfWork

        /// <summary>	Commits this object. </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the requested operation is
        ///     invalid.
        /// </exception>
        public override void Commit()
        {
            if (Transaction == null)
                throw new InvalidOperationException(
                    "UnitOfWork can't be committed since it's already finished. (Missing transaction)");
            if (_ownsConnection)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        /// <summary>	Rollbacks this object. </summary>
        /// <exception cref="InvalidOperationException">
        ///     Thrown when the requested operation is
        ///     invalid.
        /// </exception>
        public override void Rollback()
        {
            if (Transaction == null)
                throw new InvalidOperationException(
                    "UnitOfWork can't be rolled back since it's already finished. (Missing transaction)");

            if (!_ownsConnection) return;
            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        #endregion
    }
}
