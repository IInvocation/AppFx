namespace FluiTec.AppFx.Localization.LiteDb.Test
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
        public static ILocalizationDataService GetDataService()
        {
            return new LiteDbLocalizationDataService(true, "Localization.ldb", "FluiTec/AppFx");
        }
    }
}