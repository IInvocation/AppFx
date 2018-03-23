using FluiTec.AppFx.Localization.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FluiTec.AppFx.Localization.Pgsql.Test
{
    [TestClass]
    public class PgsqlResourceTest : ResourceTest
    {
        /// <summary>Constructor.</summary>
        public PgsqlResourceTest() : base(Helper.GetDataService())
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