using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ReportingApp.Application.ApplicationUser
{
    /// <summary>
    /// Gives access to current logged in user.
    /// </summary>
    public class UserContext : IUserContext
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserContext"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">HttpContextAccessor.</param>
        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Gets information about current logged in user.
        /// </summary>
        /// <returns>Current user id, name and roles.</returns>
        /// <exception cref="InvalidOperationException">Throws when context user does not exist.</exception>
        public CurrentUser GetCurrentUser()
        {
            var user = this.httpContextAccessor?.HttpContext?.User ?? throw new InvalidOperationException("Context user is not available");
            var id = user.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)!.Value;
            var name = user.FindFirst(x => x.Type == ClaimTypes.Email)!.Value;
            var roles = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);

            return new CurrentUser(id, name, roles);
        }
    }
}
