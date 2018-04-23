using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.Identity.Repositories;

namespace FluiTec.AppFx.Identity.LiteDb.Repositories
{
    /// <summary>   A lite database data protection key repository. </summary>
    public class LiteDbDataProtectionKeyRepository : LiteDbIntegerRepository<DataProtectionKeyEntity>, IDataProtectionKeyRepository
    {
        /// <summary>   Constructor. </summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbDataProtectionKeyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
