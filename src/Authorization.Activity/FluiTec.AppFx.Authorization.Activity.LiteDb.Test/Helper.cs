using FluiTec.AppFx.Identity;
using FluiTec.AppFx.Identity.LiteDb;

namespace FluiTec.AppFx.Authorization.Activity.LiteDb.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IAuthorizationDataService GetDataService()
        {
            return new LiteDbAuthorizationDataService(true, "Authorization.ldb", "FluiTec/AppFx");
        }

        /// <summary>Gets identity data service.</summary>
        /// <returns>The identity data service.</returns>
        public static IIdentityDataService GetIdentityDataService()
        {
            return new LiteDbIdentityDataService(true, "Identity.ldb", "FluiTec/AppFx");
        }
    }
}