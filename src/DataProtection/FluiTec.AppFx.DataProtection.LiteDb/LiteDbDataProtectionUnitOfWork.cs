using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.DataProtection.Repositories;

namespace FluiTec.AppFx.DataProtection.LiteDb
{
    /// <summary>   A lite database data protection unit of work. </summary>
    public class LiteDbDataProtectionUnitOfWork : LiteDbUnitOfWork, IDataProtectionUnitOfWork
    {
        #region Constructors

        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public LiteDbDataProtectionUnitOfWork(LiteDbDataService dataService) : base(dataService)
        {
        }

        /// <summary>Constructor.</summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public LiteDbDataProtectionUnitOfWork(LiteDbDataService dataService, LiteDbUnitOfWork parentUnitOfWork) : base(
            dataService, parentUnitOfWork)
        {
        }

        #endregion

        #region Fields

        /// <summary>   The data protection key repository. </summary>
        private IDataProtectionKeyRepository dataProtectionKeyRepository;

        #endregion

        #region IDataProtectionUnitOfWork

        /// <summary>   Gets the data protection key repository. </summary>
        /// <value> The data protection key repository. </value>
        public IDataProtectionKeyRepository DataProtectionKeyRepository => dataProtectionKeyRepository ??
                                                         (dataProtectionKeyRepository = GetRepository<IDataProtectionKeyRepository>());

        #endregion
    }
}
