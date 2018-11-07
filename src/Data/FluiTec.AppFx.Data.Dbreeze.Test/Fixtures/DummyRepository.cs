namespace FluiTec.AppFx.Data.Dbreeze.Test.Fixtures
{
    /// <summary>	A dummy repository. </summary>
    public class DummyRepository : LiteDbIntegerRepository<DummyEntity>, IDummyRepository
    {
        /// <summary>	Constructor. </summary>
        /// <param name="unitOfWork">	The unit of work. </param>
        public DummyRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}