using FluiTec.AppFx.Localization.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.LiteDb.Test
{
    [TestClass]
    public class LiteDbLocalizerTest : LocalizerTest
    {
        public LiteDbLocalizerTest() : base(Helper.GetDataService())
        {
        }

        [TestMethod]
        public override void CanProvideNonExistentKey()
        {
            base.CanProvideNonExistentKey();
        }
    }
}