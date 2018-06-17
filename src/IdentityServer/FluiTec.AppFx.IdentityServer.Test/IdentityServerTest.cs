namespace FluiTec.AppFx.IdentityServer.Test
{
    public abstract class IdentityServerTest
    {
        /// <summary>	The default identifier. </summary>
        protected const int DefaultId = 0;

        /// <summary>	The data service. </summary>
        protected readonly IIdentityServerDataService DataService;

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="dataService">	The data service. </param>
        protected IdentityServerTest(IIdentityServerDataService dataService)
        {
            DataService = dataService;
            if (dataService.CanMigrate())
                dataService.Migrate();
        }
    }
}