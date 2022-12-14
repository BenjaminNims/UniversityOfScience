using System.Threading.Tasks;
using UniversityOfScienceTwo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace UniversityOfScienceTwo.Authorization
{
    public class UniversityProfessorProfAuthorizationHandler :
        AuthorizationHandler<OperationAuthorizationRequirement, Professor>
    {
        
        protected override Task
            HandleRequirementAsync(AuthorizationHandlerContext context,
                                   OperationAuthorizationRequirement requirement,
                                   Professor resource)
        {
            if (context.User == null || resource == null)
            {
                return Task.CompletedTask;
            }

            // If not asking for approval/reject, return.
            if (requirement.Name != Constants.ApproveOperationName &&
                requirement.Name != Constants.RejectOperationName)
            {
                return Task.CompletedTask;
            }

            // Professors can approve or reject.
            if (context.User.IsInRole(Constants.UniversityProfessorsRole))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}