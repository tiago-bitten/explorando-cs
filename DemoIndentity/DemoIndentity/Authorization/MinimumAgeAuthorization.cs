using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace DemoIndentity.Authorization
{
    public class MinimumAgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var dateOfBirthClaim = context.User.FindFirst(ClaimTypes.DateOfBirth);

            if (dateOfBirthClaim == null)
            {
                return Task.CompletedTask;
            }

            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value);

            int age = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            if (age >= requirement.Age)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
