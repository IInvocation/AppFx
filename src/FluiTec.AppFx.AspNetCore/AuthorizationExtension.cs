using FluiTec.AppFx.Authorization.Activity;
using FluiTec.AppFx.Authorization.Activity.AuthorizationHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluiTec.AppFx.Authorization.Activity.Dynamic;
using FluiTec.AppFx.Authorization.Activity.Requirements;
using FluiTec.AppFx.Identity.Entities;
using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.AspNetCore
{
    /// <summary>An authorization extension.</summary>
    public static class AuthorizationExtension
    {
        /// <summary>An IServiceCollection extension method that configure authorization.</summary>
        /// <param name="services">         The services to act on. </param>
        /// <param name="configuration">    The configuration. </param>
        /// <returns>An IServiceCollection.</returns>
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.ConfigureAppFxAuthorizationData(configuration);
            services.AddSingleton<IAuthorizationHandler, ResourceTypOperationAuthorizationHandler>();
            services.AddSingleton<ResourceTypOperationAuthorizationHandler>();
            services.AddSingleton<IAuthorizationHandler, AdministrativeAccessAuthorizationHandler>();

            services.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyNames.AdministrativeAccess, policy =>
                    policy.Requirements.Add(new AdministrativeAccessRequirement(new[]
                    {
                        ResourceActivities.AccessRequirement(typeof(IdentityUserEntity)),
                        ResourceActivities.AccessRequirement(typeof(IdentityRoleEntity))
                    })));
                AddDefaultPolicies(services, options);
            });

            return services;
        }

        /// <summary>An IServiceCollection extension method that adds a default policies.</summary>
        /// <param name="services">             The services to act on. </param>
        /// <param name="authorizationOptions"> Options for controlling the authorization. </param>
        public static void AddDefaultPolicies(this IServiceCollection services, AuthorizationOptions authorizationOptions)
        {
            foreach (var policy in new DefaultPolicies().Policies)
            {
                authorizationOptions.AddPolicy(policy.Name, builder =>
                {
                    foreach (var requirement in policy.Requirements)
                    {
                        builder.Requirements.Add(requirement);
                    }
                });
            }
        }
    }
}