using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.DataProtection.Entities
{
    /// <summary>   A data protection key entity. </summary>
    [EntityName("AppFxDataProtection.DataProtectionKey")]
    public class DataProtectionKeyEntity : IEntity<int>
    {
        /// <summary>   Gets or sets the identifier. </summary>
        /// <value> The identifier. </value>
        public int Id { get; set; }

        /// <summary>   Gets or sets the name of the friendly. </summary>
        /// <value> The name of the friendly. </value>
        public string FriendlyName { get; set; }

        /// <summary>   Gets or sets information describing the XML. </summary>
        /// <value> Information describing the XML. </value>
        public string XmlData { get; set; }
    }
}
