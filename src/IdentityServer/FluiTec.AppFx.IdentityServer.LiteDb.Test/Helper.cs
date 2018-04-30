namespace FluiTec.AppFx.IdentityServer.LiteDb.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IIdentityServerDataService GetDataService()
        {
            return new LiteDbIdentityServerDataService(true, "IdentityServer.ldb", "FluiTec/AppFx");
        }
    }
}