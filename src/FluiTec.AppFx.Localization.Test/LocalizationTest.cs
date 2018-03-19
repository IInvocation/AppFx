using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.Test
{
    public class LocalizationFactoryTest : DataServiceTest
    {
        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public LocalizationFactoryTest(ILocalizationDataService dataService) : base(dataService)
        {
        }

        public virtual void CanCreateFactory()
        {
            var factory = new RepositoryStringLocalizerFactory(DataService);
            Assert.IsNotNull(factory);
        }

        public virtual void CanProvideLocalizer()
        {
            var factory = new RepositoryStringLocalizerFactory(DataService);
            var localizer = factory.Create(typeof(TestResource));
            Assert.IsNotNull(localizer);
        }
    }
}
