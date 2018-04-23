using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.Dapper.Repositories
{
    /// <summary>   A dapper data protection key repository. </summary>
    public class DapperDataProtectionKeyRepository : DapperRepository<DataProtectionKeyEntity, int>, IDataProtectionKeyRepository
    {
        /// <summary>   Specialised constructor for use only by derived class. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperDataProtectionKeyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
