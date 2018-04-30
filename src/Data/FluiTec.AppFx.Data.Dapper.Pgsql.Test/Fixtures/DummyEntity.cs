using System.ComponentModel.DataAnnotations.Schema;

namespace FluiTec.AppFx.Data.Dapper.Pgsql.Test.Fixtures
{
    /// <summary>	A dummy entity. </summary>
    [EntityName("Dummy")]
    public class DummyEntity : IEntity<int>
    {
        /// <summary>	Gets or sets the name. </summary>
        /// <value>	The name. </value>
        [Column("Name")]
        public string Name { get; set; }

        /// <summary>	Gets or sets the identifier. </summary>
        /// <value>	The identifier. </value>
        [Column("Id")]
        public int Id { get; set; }
    }
}