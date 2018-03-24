using FluiTec.AppFx.Data;

namespace FluiTec.AppFx.Authorization.Activity.Entities
{
    /// <summary>An activity role entity.</summary>
    [EntityName("AppFxAuthorization.ActivityRole")]
    public class ActivityRoleEntity : IEntity<int>
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the identifier of the activity.</summary>
        /// <value>The identifier of the activity.</value>
        public int ActivityId { get; set; }

        /// <summary>Gets or sets the identifier of the role.</summary>
        /// <value>The identifier of the role.</value>
        public int RoleId { get; set; }

        /// <summary>Gets or sets the allow.</summary>
        /// <value>The allow.</value>
        /// <remarks>
        /// NULL = neither deny - nor allow
        /// TRUE = allow
        /// FALSE = deny         
        /// </remarks>
        public bool? Allow { get; set; }
    }
}
