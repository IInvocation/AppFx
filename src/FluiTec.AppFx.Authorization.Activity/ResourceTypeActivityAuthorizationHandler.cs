using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FluiTec.AppFx.Authorization.Activity
{
    /// <summary>A resource type activity authorization handler.</summary>
    /// <typeparam name="TResourceType">    Type of the resource type. </typeparam>
    public class ResourceTypeActivityAuthorizationHandler<TResourceType> 
        : AuthorizationHandler<OperationAuthorizationRequirement , TResourceType> 
        where TResourceType : Type
    {
        /// <summary>The data service.</summary>
        private readonly IAuthorizationDataService _dataService;

        /// <summary>Constructor.</summary>
        /// <param name="dataService">  The data service. </param>
        public ResourceTypeActivityAuthorizationHandler(IAuthorizationDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>Makes a decision if authorization is allowed based on a specific requirement and
        /// resource.</summary>
        /// <param name="context">      The authorization context. </param>
        /// <param name="requirement">  The requirement to evaluate. </param>
        /// <param name="resourceType">     The resource to evaluate. </param>
        /// <returns>The asynchronous result.</returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement,
            TResourceType resourceType)
        {
            // make sure a valid resourceType is requested
            if (resourceType == null) return Task.CompletedTask;

            // check if the principals role is intitled to do the requested activity on the given resource
            using (var uow = _dataService.StartUnitOfWork())
            {
                var activity = uow.ActivityRepository.GetByResourceAndActivity(resourceType.Name, requirement.Name);
                if (activity == null) context.Fail(); // if activity isnt registered - fail

                var activityRoles = uow.ActivityRoleRepository.ByActivity(activity).ToList();
                if (activityRoles.Any(ar => ar.Allow == false)) // if any activity denies access explicitly - fail
                    context.Fail();
                else if (activityRoles.Any(ar => ar.Allow == true)) // if any activity allows access explicitly - succeed
                    context.Succeed(requirement);

            }

            return Task.CompletedTask;
        }
    }
}