using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity.Entities
{
    /// <summary>An activity entity.</summary>
    [EntityName("AppFxAuthorization.Activity")]
    public class ActivityEntity : IEntity<int>
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the name of the resource.</summary>
        /// <value>The name of the resource.</value>
        public string ResourceName { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
    }
}