using FluiTec.AppFx.Data;
using FluiTec.AppFx.DataProtection.Entities;

namespace FluiTec.AppFx.DataProtection.Repositories
{
    /// <summary>   Interface for data protection key repository. </summary>
    public interface IDataProtectionKeyRepository : IDataRepository<DataProtectionKeyEntity, int>
    {
    }
}
