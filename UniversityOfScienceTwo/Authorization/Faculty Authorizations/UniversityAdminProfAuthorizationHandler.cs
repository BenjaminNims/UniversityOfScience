using System.Threading.Tasks;
using UniversityOfScienceTwo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace UniversityOfScienceTwo.Authorization
{
    public class UniversityAdminProfAuthorizationHandler
                    : AuthorizationHandler<OperationAuthorizationRequirement, Professor>
    {
        protected override Task HandleRequirementAsync(
                                              AuthorizationHandlerContext context,
                                    OperationAuthorizationRequirement requirement,
                                     Professor resource)
        {
            if (context.User == null)
            {
                return Task.CompletedTask;
            }

            // Administrators can do anything.
            if (context.User.IsInRole(Constants.UniversityAdministratorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}

