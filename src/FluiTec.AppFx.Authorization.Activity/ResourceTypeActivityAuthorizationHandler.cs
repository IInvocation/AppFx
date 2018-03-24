using System;
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
            if (resourceType != null)
            {
                // check if the principals role is intitled to do the requested activity on the given resource
                
            }

            return Task.CompletedTask;
        }
    }
}