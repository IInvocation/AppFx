namespace FluiTec.AppFx.Data.Dbreeze.Test.Fixtures
{
    /// <summary>	A dummy mssql data service. </summary>
    public class DummyDbreezeDataService : DbreezeDataService
    {
        /// <summary>	Default constructor. </summary>
        public DummyDbreezeDataService() : base("FluiTec/AppFx")
        {
        }

        /// <summary>	The name. </summary>
        public override string Name => "DummyDbreezeDataService";

        public override bool CanMigrate() => false;

        public override void Migrate() => throw new System.NotImplementedException();
    }
}