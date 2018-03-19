namespace FluiTec.AppFx.Localization.Test
{
    /// <summary>   A dataservice test. </summary>
    public class DataServiceTest
    {
        /// <summary>	The default identifier. </summary>
        protected const int DefaultId = 0;

        /// <summary>	The data service. </summary>
        protected readonly ILocalizationDataService DataService;

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="dataService">	The data service. </param>
        protected DataServiceTest(ILocalizationDataService dataService)
        {
            DataService = dataService;
        }
    }
}