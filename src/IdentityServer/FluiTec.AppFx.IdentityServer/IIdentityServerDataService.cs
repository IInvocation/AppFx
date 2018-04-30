using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.IdentityServer
{
    /// <summary>	Interface for identity server data service. </summary>
    public interface IIdentityServerDataService : IDataService
    {
        /// <summary>	Starts unit of work. </summary>
        /// <returns>	An IIdentityServerUnitOfWork. </returns>
        IIdentityServerUnitOfWork StartUnitOfWork();

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IIdentityServerUnitOfWork.</returns>
        IIdentityServerUnitOfWork StartUnitOfWork(IUnitOfWork other);
    }
}