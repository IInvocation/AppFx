using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.Test
{
    public class LocalizerTest : DataServiceTest
    {
        protected LocalizerTest(ILocalizationDataService dataService) : base(dataService)
        {
        }

        public virtual void CanProvideNonExistentKey()
        {
            var factory = new RepositoryStringLocalizerFactory(DataService);
            var localizer = factory.Create(typeof(TestResource));

            var key = "Name";
            var translation = localizer[key];
            Assert.AreEqual(key, translation);
        }
    }
}