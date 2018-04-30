namespace FluiTec.AppFx.DataProtection.Test
{
    /// <summary>   A data protection test. </summary>
    public abstract class DataProtectionTest
    {
        /// <summary>	The default identifier. </summary>
        protected const int DefaultId = 0;

        /// <summary>	The data service. </summary>
        protected readonly IDataProtectionDataService DataService;

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="dataService">	The data service. </param>
        protected DataProtectionTest(IDataProtectionDataService dataService)
        {
            DataService = dataService;
        }
    }
}
