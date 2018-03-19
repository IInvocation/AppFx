using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Localization.Entities
{
    /// <summary>
    ///     A resource entity.
    /// </summary>
    [EntityName("AppFxLocalizer.Resource")]
    public class ResourceEntity : IEntity<int>
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>Gets or sets the key.</summary>
        /// <value>The key.</value>
        public string Key { get; set; }

        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }
    }
}