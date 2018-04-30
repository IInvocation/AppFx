using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Localization
{
    /// <summary>Interface for localization data service.</summary>
    public interface ILocalizationDataService : IDataService
    {
        /// <summary>Starts unit of work.</summary>
        /// <returns>An ILocalizationUnitOfWork.</returns>
        ILocalizationUnitOfWork StartUnitOfWork();

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An ILocalizationUnitOfWork.</returns>
        ILocalizationUnitOfWork StartUnitOfWork(IUnitOfWork other);
    }
}