using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FluiTec.AppFx.Authorization.Activity.Requirements;
using FluiTec.AppFx.Identity;
using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.Authorization.Activity.AuthorizationHandlers
{
    /// <summary>A resource typ operation authorization handler.</summary>
    public class ResourceTypOperationAuthorizationHandler : AuthorizationHandler<ResourceTypeOperationRequirement>
    {
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

            // check if the principals role is intitled to do the requested activity on the given resource
            using (var uow = _dataService.StartUnitOfWork())
            {
                var activity = uow.ActivityRepository.GetByResourceAndActivity(resourceType.Name, requirement.Operation.Name);
                if (activity == null) return Fail(context); // if activity isnt registered - fail

                // fetch all rights related to the activity
                var activityRoles = uow.ActivityRoleRepository.ByActivity(activity).ToList();

                // remove rights from roles the user is no member of
                using (var iuow = _identityDataService.StartUnitOfWork())
                {
                    var userRoleNames = context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
                    if (!userRoleNames.Any()) return Fail(context);
                    var roleIds = iuow.RoleRepository.FindByNames(userRoleNames).Select(r => r.Id);
                    activityRoles = activityRoles.Where(ar => roleIds.Contains(ar.RoleId)).ToList();

                    if (activityRoles.Any(ar => ar.Allow == false)
                    ) // if any activity denies access explicitly - fail
                        return Fail(context);
                    if (activityRoles.Any(ar => ar.Allow == true)
                    ) // if any activity allows access explicitly - succeed
                        return Succeed(context, requirement);
                    // if none matches - fail either way
                    return Fail(context);
                }
            }
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
    }
}