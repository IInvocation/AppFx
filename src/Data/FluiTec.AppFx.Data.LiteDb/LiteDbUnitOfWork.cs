using System;
using LiteDB;

namespace FluiTec.AppFx.Data.LiteDb
{
    public class LiteDbUnitOfWork : UnitOfWork
    {
        #region Fields

        /// <summary>True to owns connection.</summary>
        private readonly bool _ownsConnection = true;

        #endregion

        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <exception cref="ArgumentNullException">
        ///     Thrown when one or more required arguments are
        ///     null.
        /// </exception>
        /// <param name="dataService">	The data service. </param>
        public LiteDbUnitOfWork(LiteDbDataService dataService) : base(dataService)
        {
            LiteDbDataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            Transaction = LiteDbDataService.Database.BeginTrans();
        }

        /// <summary>Constructor.</summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public LiteDbUnitOfWork(LiteDbDataService dataService, LiteDbUnitOfWork parentUnitOfWork) : base(dataService)
        {
            _ownsConnection = false;
            LiteDbDataService = dataService;;
            Transaction = parentUnitOfWork.Transaction;
        }

        #endregion

        #region Properties

        /// <summary>	Gets the lite database data service. </summary>
        /// <value>	The lite database data service. </value>
        public LiteDbDataService LiteDbDataService { get; }

        /// <summary>	Gets or sets the transaction. </summary>
        /// <value>	The transaction. </value>
        public LiteTransaction Transaction { get; private set; }

        #endregion Properties

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
            if (_ownsConnection)
            {
                Transaction.Rollback();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        #endregion
    }
}