using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Repositories;
using FluiTec.AppFx.Data;
using FluiTec.AppFx.Data.Dapper;

namespace FluiTec.AppFx.Authorization.Activity.Dapper.Repositories
{
    /// <summary>A dapper activity repository.</summary>
    public class DapperActivityRepository : DapperRepository<ActivityEntity, int>, IActivityRepository
    {
        /// <summary>Constructor.</summary>
        /// <param name="unitOfWork">   The unit of work. </param>
        public DapperActivityRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}