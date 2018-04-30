using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace FluiTec.AppFx.Authorization.Activity.Requirements
{
    /// <summary>An administrative access requirement.</summary>
    public class AdministrativeAccessRequirement : IAuthorizationRequirement
    {
        /// <summary>Gets the requirements.</summary>
        /// <value>The requirements.</value>
        public IReadOnlyList<IAuthorizationRequirement> Requirements { get; }

        /// <summary>Constructor.</summary>
        /// <param name="requirements"> The requirements. </param>
        public AdministrativeAccessRequirement(IEnumerable<IAuthorizationRequirement> requirements)
        {
            Requirements = requirements.ToList().AsReadOnly();
        }
    }
}