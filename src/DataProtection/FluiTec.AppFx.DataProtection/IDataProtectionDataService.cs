using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.DataProtection
{
    /// <summary>   Interface for data protection data service. </summary>
    public interface IDataProtectionDataService : IDataService
    {
        /// <summary>   Starts unit of work. </summary>
        /// <returns>   An IDataProtectionUnitOfWork. </returns>
        IDataProtectionUnitOfWork StartUnitOfWork();

        /// <summary>   Data protection unit of work. </summary>
        /// <param name="other">    The other. </param>
        /// <returns>   An IDataProtectionUnitOfWork. </returns>
        IDataProtectionUnitOfWork StartUnitOfWork(IUnitOfWork other);
    }
}
