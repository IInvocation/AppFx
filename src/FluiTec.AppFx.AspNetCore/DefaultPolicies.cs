using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Activity;
using FluiTec.AppFx.Authorization.Activity.Requirements;
using FluiTec.AppFx.Identity.Entities;

namespace FluiTec.AppFx.AspNetCore
{
    /// <summary>A default policies.</summary>
    public class DefaultPolicies
    {
        /// <summary>Gets or sets the policies.</summary>
        /// <value>The policies.</value>
        public IEnumerable<DefaultPolicy> Policies { get; set; }

        /// <summary>Default constructor.</summary>
        public DefaultPolicies()
        {
            Policies = new List<DefaultPolicy>(new[]
            {
                AdministrativeAccess,
                UsersAccess,
                UsersCreate,
                UsersUpdate,
                UsersDelete,
                RolesAccess,
                RolesCreate,
                RolesUpdate,
                RolesDelete
            });
        }

        /// <summary>Gets the administrative access.</summary>
        /// <value>The administrative access.</value>
        public DefaultPolicy AdministrativeAccess { get; } = new DefaultPolicy(PolicyNames.AdministrativeAccess, new AdministrativeAccessRequirement(new[]
        {
            ResourceActivities.AccessRequirement(typeof(IdentityUserEntity)),
            ResourceActivities.AccessRequirement(typeof(IdentityRoleEntity))
        }));

        /// <summary>Gets the users access.</summary>
        /// <value>The users access.</value>
        public DefaultPolicy UsersAccess { get; } = new DefaultPolicy(PolicyNames.UsersAccess, ResourceActivities.AccessRequirement(typeof(IdentityUserEntity)));

        /// <summary>Gets the users create.</summary>
        /// <value>The users create.</value>
        public DefaultPolicy UsersCreate { get; } = new DefaultPolicy(PolicyNames.UsersCreate, ResourceActivities.CreateRequirement(typeof(IdentityUserEntity)));

        /// <summary>Gets the users update.</summary>
        /// <value>The users update.</value>
        public DefaultPolicy UsersUpdate { get; } = new DefaultPolicy(PolicyNames.UsersUpdate, ResourceActivities.UpdateRequirement(typeof(IdentityUserEntity)));

        /// <summary>Gets the users delete.</summary>
        /// <value>The users delete.</value>
        public DefaultPolicy UsersDelete { get; } = new DefaultPolicy(PolicyNames.UsersDelete, ResourceActivities.DeleteRequirement(typeof(IdentityUserEntity)));

        /// <summary>Gets the roles access.</summary>
        /// <value>The roles access.</value>
        public DefaultPolicy RolesAccess { get; } = new DefaultPolicy(PolicyNames.RolesAccess, ResourceActivities.AccessRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the roles create.</summary>
        /// <value>The roles create.</value>
        public DefaultPolicy RolesCreate { get; } = new DefaultPolicy(PolicyNames.RolesCreate, ResourceActivities.CreateRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the roles update.</summary>
        /// <value>The roles update.</value>
        public DefaultPolicy RolesUpdate { get; } = new DefaultPolicy(PolicyNames.RolesUpdate, ResourceActivities.UpdateRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the roles delete.</summary>
        /// <value>The roles delete.</value>
        public DefaultPolicy RolesDelete { get; } = new DefaultPolicy(PolicyNames.RolesDelete, ResourceActivities.DeleteRequirement(typeof(IdentityRoleEntity)));
    }
}