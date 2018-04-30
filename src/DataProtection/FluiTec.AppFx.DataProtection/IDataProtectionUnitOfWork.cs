using FluiTec.AppFx.Data;
using FluiTec.AppFx.DataProtection.Repositories;

namespace FluiTec.AppFx.DataProtection
{
    /// <summary>   Interface for data protection unit of work. </summary>
    public interface IDataProtectionUnitOfWork : IUnitOfWork
    {
        /// <summary>   Gets the data protection key repository. </summary>
        /// <value> The data protection key repository. </value>
        IDataProtectionKeyRepository DataProtectionKeyRepository { get; }
    }
}
