using FluiTec.AppFx.Localization.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.LiteDb.Test
{
    /// <summary>A lite database resource test.</summary>
    [TestClass]
    public class LiteDbResourceTest : ResourceTest
    {
        /// <summary>Default constructor.</summary>
        public LiteDbResourceTest() : base(Helper.GetDataService())
        {
        }

        /// <summary>Can add and get resource.</summary>
        [TestMethod]
        public override void CanAddAndGetResource()
        {
            base.CanAddAndGetResource();
        }

        /// <summary>Can add and get resources.</summary>
        [TestMethod]
        public override void CanAddAndGetResources()
        {
            base.CanAddAndGetResources();
        }

        /// <summary>Can update resource.</summary>
        [TestMethod]
        public override void CanUpdateResource()
        {
            base.CanUpdateResource();
        }

        /// <summary>Can delete claim.</summary>
        [TestMethod]
        public override void CanDeleteClaim()
        {
            base.CanDeleteClaim();
        }
    }
}