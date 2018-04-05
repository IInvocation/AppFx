using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluiTec.AppFx.Authorization.Activity.Entities;
using FluiTec.AppFx.Authorization.Activity.Requirements;
using FluiTec.AppFx.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.Authorization.Activity.AuthorizationHandlers
{
    /// <summary>A resource typ operation authorization handler.</summary>
    public class ResourceTypOperationAuthorizationHandler : AuthorizationHandler<ResourceTypeOperationRequirement>
    {
        /// <summary>   The activities. </summary>
        private readonly ConcurrentDictionary<ClaimsPrincipal, IEnumerable<ActivityRoleEntity>> _activities = new ConcurrentDictionary<ClaimsPrincipal, IEnumerable<ActivityRoleEntity>>();

        /// <summary>The data service.</summary>
        private readonly IAuthorizationDataService _dataService;

        /// <summary>The identity data service.</summary>
        private readonly IIdentityDataService _identityDataService;

        /// <summary>Constructor.</summary>
        /// <param name="dataService">          The data service. </param>
        /// <param name="identityDataService">  The identity data service. </param>
        public ResourceTypOperationAuthorizationHandler(IAuthorizationDataService dataService, IIdentityDataService identityDataService)
        {
            _dataService = dataService;
            _identityDataService = identityDataService;
        }

        /// <summary>Makes a decision if authorization is allowed based on a specific requirement.</summary>
        /// <param name="context">      The authorization context. </param>
        /// <param name="requirement">  The requirement to evaluate. </param>
        /// <returns>The asynchronous result.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceTypeOperationRequirement requirement)
        {
            if (context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            var resourceType = requirement.ResourceType;

            // make sure a valid resourceType is requested
            if (resourceType == null) return Task.CompletedTask;

            var activityRoles = GetActivities(context.User, resourceType.Name, requirement.Operation.Name).ToList();

            if (!activityRoles.Any())
                return Fail(context);

            if (activityRoles.Any(ar => ar.Allow == false)
            ) // if any activity denies access explicitly - fail
                return Fail(context);
            if (activityRoles.Any(ar => ar.Allow == true)
            ) // if any activity allows access explicitly - succeed
                return Succeed(context, requirement);
            // if none matches - fail either way
            return Fail(context);
        }

        /// <summary>Fails the given context.</summary>
        /// <param name="context">  The authorization context. </param>
        /// <returns>The asynchronous result.</returns>
        private Task Fail(AuthorizationHandlerContext context)
        {
            context.Fail();
            return Task.CompletedTask;
        }

        /// <summary>Succeed.</summary>
        /// <param name="context">      The authorization context. </param>
        /// <param name="requirement">  The requirement to evaluate. </param>
        /// <returns>The asynchronous result.</returns>
        private Task Succeed(AuthorizationHandlerContext context, ResourceTypeOperationRequirement requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        /// <summary>   Gets the activities in this collection. </summary>
        /// <param name="user">             The user. </param>
        /// <param name="resourceTypeName"> Name of the resource type. </param>
        /// <param name="operationName">    Name of the operation. </param>
        /// <returns>
        ///     An enumerator that allows foreach to be used to process the activities in this collection.
        /// </returns>
        private IEnumerable<ActivityRoleEntity> GetActivities(ClaimsPrincipal user, string resourceTypeName, string operationName)
        {
            if (_activities.ContainsKey(user))
                return _activities[user];

            using (var uow = _dataService.StartUnitOfWork())
            {
                var activity = uow.ActivityRepository.GetByResourceAndActivity(resourceTypeName, operationName);
                var activityRoles = activity == null ? Enumerable.Empty<ActivityRoleEntity>() : uow.ActivityRoleRepository.ByActivity(activity).ToList();

                if (activityRoles != null)
                {
                    using (var iuow = _identityDataService.StartUnitOfWork())
                    {
                        var userRoleNames = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value)
                            .ToList();
                        var roleIds = iuow.RoleRepository.FindByNames(userRoleNames).Select(r => r.Id);
                        activityRoles = activityRoles.Where(ar => roleIds.Contains(ar.RoleId)).ToList();
                    }
                }

                _activities[user] = activityRoles;
            }

            return _activities[user];
        }
    }
}