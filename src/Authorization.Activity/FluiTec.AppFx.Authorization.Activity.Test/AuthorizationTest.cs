namespace FluiTec.AppFx.Authorization.Activity.Test
{
    public class AuthorizationTest
    {
        /// <summary>	The default identifier. </summary>
        protected const int DefaultId = 0;

        /// <summary>	The data service. </summary>
        protected readonly IAuthorizationDataService DataService;

        /// <summary>	Specialised constructor for use only by derived class. </summary>
        /// <param name="dataService">	The data service. </param>
        protected AuthorizationTest(IAuthorizationDataService dataService)
        {
            DataService = dataService;
        }
    }
}