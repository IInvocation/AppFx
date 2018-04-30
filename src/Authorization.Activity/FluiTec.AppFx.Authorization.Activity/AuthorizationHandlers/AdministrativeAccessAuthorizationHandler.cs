using System.Threading.Tasks;
using FluiTec.AppFx.Authorization.Activity.Requirements;
using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.Authorization.Activity.AuthorizationHandlers
{
    /// <summary>An administrative access authorization handler.</summary>
    public class AdministrativeAccessAuthorizationHandler : AuthorizationHandler<AdministrativeAccessRequirement>
    {
        /// <summary>The handler.</summary>
        private readonly ResourceTypOperationAuthorizationHandler _handler;

        /// <summary>Constructor.</summary>
        /// <param name="handler">  The handler. </param>
        public AdministrativeAccessAuthorizationHandler(ResourceTypOperationAuthorizationHandler handler)
        {
            _handler = handler;
        }

        /// <summary>Makes a decision if authorization is allowed based on a specific requirement.</summary>
        /// <param name="context">      The authorization context. </param>
        /// <param name="requirement">  The requirement to evaluate. </param>
        /// <returns>The asynchronous result.</returns>
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AdministrativeAccessRequirement requirement)
        {
            // if user is in role administrator, succeed
            if (context.User.IsInRole("Administrator"))
            {
                context.Succeed(requirement);
                return;
            }
           
            // if any of the sub-requirements succeeds - succeed
            foreach (var r in requirement.Requirements)
            {
                var ctx = new AuthorizationHandlerContext(new[] {r}, context.User, context.Resource);
                await _handler.HandleAsync(ctx);

                // if sub failed - try next
                if (ctx.HasFailed) continue;

                // if sub didnt fail - succeed
                context.Succeed(requirement);
                return;
            }

            // if nothing succeeded - fai
            context.Fail();
        }
    }
}