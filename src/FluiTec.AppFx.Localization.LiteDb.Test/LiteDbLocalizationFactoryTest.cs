using FluiTec.AppFx.Localization.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.LiteDb.Test
{
    [TestClass]
    public class LiteDbLocalizationFactoryTest : LocalizationFactoryTest
    {
        public LiteDbLocalizationFactoryTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanCreateFactory()
        {
            base.CanCreateFactory();
        }

        [TestMethod]
        public override void CanProvideLocalizer()
        {
            base.CanProvideLocalizer();
        }
    }
}
