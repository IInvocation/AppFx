namespace FluiTec.AppFx.DataProtection.LiteDb.Test
{
    /// <summary>	A helper. </summary>
    public static class Helper
    {
        /// <summary>	Gets data service. </summary>
        /// <returns>	The data service. </returns>
        public static IDataProtectionDataService GetDataService()
        {
            return new LiteDbDataProtectionDataService(true, "DataProtection.ldb", "FluiTec/AppFx");
        }
    }
}
