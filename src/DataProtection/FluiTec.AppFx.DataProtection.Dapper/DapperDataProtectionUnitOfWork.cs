using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.DataProtection.Repositories;

namespace FluiTec.AppFx.DataProtection.Dapper
{
    /// <summary>   A dapper data protection unit of work. </summary>
    public class DapperDataProtectionUnitOfWork : DapperUnitOfWork, IDataProtectionUnitOfWork
    {
        #region Constructors

        /// <summary>	Constructor. </summary>
        /// <param name="dataService">	The data service. </param>
        public DapperDataProtectionUnitOfWork(DapperDataService dataService) : base(dataService)
        {
        }

        /// <summary>Constructor.</summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public DapperDataProtectionUnitOfWork(DapperDataService dataService, DapperUnitOfWork parentUnitOfWork) : base(
            dataService, parentUnitOfWork)
        {
        }

        #endregion

        #region Fields

        private IDataProtectionKeyRepository _dataProtectionKeyRepository;

        #endregion

        #region IDataProtectionUnitOfWork

        /// <summary>   Gets the data protection key repository. </summary>
        /// <value> The data protection key repository. </value>
        public IDataProtectionKeyRepository DataProtectionKeyRepository => _dataProtectionKeyRepository ??
                                                       (_dataProtectionKeyRepository = GetRepository<IDataProtectionKeyRepository>());

        #endregion
    }
}
