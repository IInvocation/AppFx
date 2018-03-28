using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace FluiTec.AppFx.Authorization.Activity
{
    /// <summary>An list of requirements for activities.</summary>
    public static class Activities
    {
        /// <summary>The access requirement.</summary>
        public static OperationAuthorizationRequirement Access =
            new OperationAuthorizationRequirement {Name = nameof(Access)};

        /// <summary>The create requirement.</summary>
        public static OperationAuthorizationRequirement Create =
            new OperationAuthorizationRequirement {Name = nameof(Create)};

        /// <summary>The read requirement.</summary>
        public static OperationAuthorizationRequirement Read =
            new OperationAuthorizationRequirement {Name = nameof(Read)};

        /// <summary>The update requirement.</summary>
        public static OperationAuthorizationRequirement Update =
            new OperationAuthorizationRequirement {Name = nameof(Update)};

        /// <summary>The delete requirement.</summary>
        public static OperationAuthorizationRequirement Delete =
            new OperationAuthorizationRequirement {Name = nameof(Delete)};
    }
}