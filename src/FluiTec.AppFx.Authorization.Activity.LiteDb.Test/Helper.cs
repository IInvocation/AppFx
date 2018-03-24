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
    }
}