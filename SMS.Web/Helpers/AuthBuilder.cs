using System;
using System.Text;
// using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
// using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.Cookies;
using SMS.Data.Models;
using Microsoft.Extensions.Configuration;

namespace SMS.Web
{
    public static class AuthBuilder
    {
        // ========================= Build Claims Principle ==================
        
        // https://docs.microsoft.com/en-us/aspnet/core/security/authorization/roles
        // https://andrewlock.net/introduction-to-authentication-with-asp-net-core/
                
        // return claims principal based on authenticated user
        public static ClaimsPrincipal BuildClaimsPrincipal(User user)
        { 
            // define user claims
            var claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString())                              
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            // build principal using claims
            return  new ClaimsPrincipal(claims);
        }
                
    }

}