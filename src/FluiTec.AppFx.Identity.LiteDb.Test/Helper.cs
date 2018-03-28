namespace FluiTec.AppFx.Identity.LiteDb.Test
{
    /// <summary>
    ///     A helper.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        ///     Gets data service.
        /// </summary>
        /// <returns>
        ///     The data service.
        /// </returns>
        public static IIdentityDataService GetDataService()
        {
            return new LiteDbIdentityDataService(true, "Identity.ldb", "FluiTec/AppFx");
        }
    }
}