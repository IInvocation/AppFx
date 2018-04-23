using FluiTec.AppFx.Data;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.Identity.Repositories
{
    /// <summary>   Interface for data protection key repository. </summary>
    public interface IDataProtectionKeyRepository : IDataRepository<DataProtectionKeyEntity, int>
    {
    }
}
