namespace FluiTec.AppFx.Identity.Test
{
    /// <summary>	An identity test. </summary>
    public abstract class IdentityTest
    {
        /// <summary>	The default identifier. </summary>
        protected const int DefaultId = 0;

        /// <summary>	The data service. </summary>
        protected readonly IIdentityDataService DataService;

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="dataService">	The data service. </param>
        protected IdentityTest(IIdentityDataService dataService)
        {
            DataService = dataService;
            if (DataService.CanMigrate())
                DataService.Migrate();
        }
    }
}