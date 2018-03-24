using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.LiteDb;

namespace FluiTec.AppFx.Authorization.Activity.LiteDb.Repositories
{
    /// <summary>An activity repository.</summary>
    public class LiteDbActivityRepository : LiteDbIntegerRepository<ActivityEntity>, IActivityRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public LiteDbActivityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
