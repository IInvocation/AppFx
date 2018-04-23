using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.LiteDb
{
    /// <summary>
    ///     A lite database identity unit of work.
    /// </summary>
    public class LiteDbIdentityUnitOfWork : LiteDbUnitOfWork, IIdentityUnitOfWork
    {
        #region Constructors

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="dataService">  The data service. </param>
        public LiteDbIdentityUnitOfWork(LiteDbDataService dataService) : base(dataService)
        {
        }

        /// <summary>Constructor.</summary>
        /// <param name="dataService">      The data service. </param>
        /// <param name="parentUnitOfWork"> The parent unit of work. </param>
        public LiteDbIdentityUnitOfWork(LiteDbDataService dataService, LiteDbUnitOfWork parentUnitOfWork) : base(
            dataService, parentUnitOfWork)
        {
        }

        #endregion

        #region Fields

        private IUserRepository _userRepository;
        private IRoleRepository _roleRepository;
        private IUserRoleRepository _userRoleRepository;
        private IClaimRepository _claimRepository;
        private IUserLoginRepository _loginRepository;
        private IDataProtectionKeyRepository _dataProtectionKeyRepository;

        #endregion

        #region IIdentityUnitOfWork

        /// <summary>	The user repository. </summary>
        public IUserRepository UserRepository =>
            _userRepository ?? (_userRepository = GetRepository<IUserRepository>());

        /// <summary>	The claim repository. </summary>
        public IClaimRepository ClaimRepository =>
            _claimRepository ?? (_claimRepository = GetRepository<IClaimRepository>());

        /// <summary>	The role repository. </summary>
        public IRoleRepository RoleRepository =>
            _roleRepository ?? (_roleRepository = GetRepository<IRoleRepository>());

        /// <summary>	The user role repository. </summary>
        public IUserRoleRepository UserRoleRepository => _userRoleRepository ??
                                                         (_userRoleRepository = GetRepository<IUserRoleRepository>());

        /// <summary>	The user login repository. </summary>
        public IUserLoginRepository LoginRepository => _loginRepository ??
                                                       (_loginRepository = GetRepository<IUserLoginRepository>());

        /// <summary>   Gets the data protection key repository. </summary>
        /// <value> The data protection key repository. </value>
        public IDataProtectionKeyRepository DataProtectionKeyRepository => _dataProtectionKeyRepository ??
                                                       (_dataProtectionKeyRepository = GetRepository<IDataProtectionKeyRepository>());

        #endregion
    }
}