using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity
{
    /// <summary>Interface for authorization data service.</summary>
    public interface IAuthorizationDataService : IDataService
    {
        /// <summary>Starts unit of work.</summary>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        IAuthorizationUnitOfWork StartUnitOfWork();

        /// <summary>Starts unit of work.</summary>
        /// <param name="other">    The other. </param>
        /// <returns>An IAuthorizationUnitOfWork.</returns>
        IAuthorizationUnitOfWork StartUnitOfWork(IUnitOfWork other);
    }
}