
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace SMS.Web
{
    public static class Extensions
    {   
        // AddCookieAuthentication extension method - to be called in Startup service configuration
        public static void AddCookieAuthentication(this IServiceCollection services, 
            string notAuthorised = "/User/ErrorNotAuthorised", string notAuthenticated= "/User/ErrorNotAuthenticated")
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options => {
                        options.AccessDeniedPath = notAuthorised;
                        options.LoginPath = notAuthenticated;
            });
        } 

        // ClaimsPrincipal extension method to allow a roles string to contain multiple roles (separated by ,)
        public static bool HasOneOfRoles(this ClaimsPrincipal claims, string rolesString)
        {
            // split string into an array of roles
            var roles = rolesString.Split(",");

            // linq query to check that ClaimsPrincipal has one of these roles
            return roles.FirstOrDefault(role => claims.IsInRole(role)) != null;
        }  
    }
}
