﻿using System;
using System.Data;

namespace FluiTec.AppFx.Data.Dapper
{
    public class DapperUnitOfWork : UnitOfWork
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
        /// <param name="dataService">  	The data service. </param>
        public DapperUnitOfWork(DapperDataService dataService) : base(dataService)
        {
            DapperDataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

            // create and open connection
            Connection = DapperDataService.ConnectionFactory.CreateConnection(DapperDataService.ConnectionString);
            Connection.Open();

            // begin transaction
            Transaction = Connection.BeginTransaction();
        }

        /// <summary>Constructor.</summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public DapperUnitOfWork(DapperDataService dataService, DapperUnitOfWork parentUnitOfWork) : base(dataService)
        {
            _ownsConnection = false;
            DapperDataService = dataService;
            Connection = parentUnitOfWork.Connection;
            Transaction = parentUnitOfWork.Transaction;
        }

        #endregion

        #region Properties

        /// <summary>   Gets the data service. </summary>
        /// <value> The data service. </value>
        public DapperDataService DapperDataService { get; }

        /// <summary>   Gets or sets the connection. </summary>
        /// <value> The connection. </value>
        public IDbConnection Connection { get; private set; }

        /// <summary>   Gets or sets the transaction. </summary>
        /// <value> The transaction. </value>
        public IDbTransaction Transaction { get; private set; }

        #endregion

        #region IUnitOfWork

        /// <summary>   Commits the UnitOfWork. </summary>
        /// <exception cref="InvalidOperationException">    Thrown when the there's no longer a transaction. </exception>
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
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }

        /// <summary>   Rolls back the UnitOfWork. </summary>
        /// <exception cref="InvalidOperationException">    Thrown when the there's no longer a transaction. </exception>
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
                Connection.Close();
                Connection.Dispose();
                Connection = null;
            }
        }

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
        ///     Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged
        ///     resources.
        /// </summary>
        /// <param name="disposing">
        ///     true to release both managed and unmanaged resources; false to
        ///     release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (Transaction != null)
                Rollback();
        }

        #endregion
    }
}