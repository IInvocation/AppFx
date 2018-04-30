using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;
using FluiTec.AppFx.DataProtection.Entities;
using FluiTec.AppFx.DataProtection.Repositories;

namespace FluiTec.AppFx.DataProtection.LiteDb.Repositories
{
    /// <summary>   A lite database data protection repository. </summary>
    public class LiteDbDataProtectionRepository : LiteDbIntegerRepository<DataProtectionKeyEntity>, IDataProtectionKeyRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbDataProtectionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
