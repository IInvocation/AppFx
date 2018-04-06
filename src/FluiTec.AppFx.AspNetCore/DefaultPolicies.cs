using System.Collections.Generic;
using FluiTec.AppFx.Authorization.Activity;
using FluiTec.AppFx.Authorization.Activity.Requirements;
using FluiTec.AppFx.Identity.Entities;
using FluiTec.AppFx.IdentityServer.Entities;

namespace FluiTec.AppFx.AspNetCore
{
    /// <summary>A default policies.</summary>
    public class DefaultPolicies
    {
        /// <summary>Gets or sets the policies.</summary>
        /// <value>The policies.</value>
        public IReadOnlyList<DefaultPolicy> Policies { get; }

        /// <summary>Default constructor.</summary>
        public DefaultPolicies()
        {
            Policies = new List<DefaultPolicy>(new[]
            {
                AdministrativeAccess,
                UsersAccess, UsersCreate, UsersUpdate, UsersDelete,
                RolesAccess, RolesCreate, RolesUpdate, RolesDelete,
                ClaimsAccess, ClaimsCreate, ClaimsUpdate, ClaimsDelete,
                ClientsAccess, ClientsCreate, ClientsUpdate, ClientsDelete
            }).AsReadOnly();
        }

        /// <summary>Gets the administrative access.</summary>
        /// <value>The administrative access.</value>
        public DefaultPolicy AdministrativeAccess { get; } = new DefaultPolicy(PolicyNames.AdministrativeAccess, new AdministrativeAccessRequirement(new[]
        {
            ResourceActivities.AccessRequirement(typeof(IdentityUserEntity)),
            ResourceActivities.AccessRequirement(typeof(IdentityRoleEntity)),
            ResourceActivities.AccessRequirement(typeof(ClientEntity))
        }));

        #region Users

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

        #endregion

        #region Roles

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

        #endregion

        #region Claims

        /// <summary>Gets the Claims access.</summary>
        /// <value>The Claims access.</value>
        public DefaultPolicy ClaimsAccess { get; } = new DefaultPolicy(PolicyNames.ClaimsAccess, ResourceActivities.AccessRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the Claims create.</summary>
        /// <value>The Claims create.</value>
        public DefaultPolicy ClaimsCreate { get; } = new DefaultPolicy(PolicyNames.ClaimsCreate, ResourceActivities.CreateRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the Claims update.</summary>
        /// <value>The Claims update.</value>
        public DefaultPolicy ClaimsUpdate { get; } = new DefaultPolicy(PolicyNames.ClaimsUpdate, ResourceActivities.UpdateRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the Claims delete.</summary>
        /// <value>The Claims delete.</value>
        public DefaultPolicy ClaimsDelete { get; } = new DefaultPolicy(PolicyNames.ClaimsDelete, ResourceActivities.DeleteRequirement(typeof(IdentityRoleEntity)));

        #endregion

        #region Clients

        /// <summary>Gets the Clients access.</summary>
        /// <value>The Clients access.</value>
        public DefaultPolicy ClientsAccess { get; } = new DefaultPolicy(PolicyNames.ClientsAccess, ResourceActivities.AccessRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the Clients create.</summary>
        /// <value>The Clients create.</value>
        public DefaultPolicy ClientsCreate { get; } = new DefaultPolicy(PolicyNames.ClientsCreate, ResourceActivities.CreateRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the Clients update.</summary>
        /// <value>The Clients update.</value>
        public DefaultPolicy ClientsUpdate { get; } = new DefaultPolicy(PolicyNames.ClientsUpdate, ResourceActivities.UpdateRequirement(typeof(IdentityRoleEntity)));

        /// <summary>Gets the Clients delete.</summary>
        /// <value>The Clients delete.</value>
        public DefaultPolicy ClientsDelete { get; } = new DefaultPolicy(PolicyNames.ClientsDelete, ResourceActivities.DeleteRequirement(typeof(IdentityRoleEntity)));

        #endregion
    }
}