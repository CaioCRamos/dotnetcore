using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using JwtWebApi.Core;
using JwtWebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace JwtWebApi.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public ActionResult<object> Post([FromBody] LoginSubmit login,
                                 [FromServices]SigningConfigurations signingConfigurations,
                                 [FromServices]TokenConfigurations tokenConfigurations)
        {
            if (string.IsNullOrEmpty(login.user) || string.IsNullOrEmpty(login.password))
                return Unauthorized();

            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(login.user, "Login"),
                new[] {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, login.user)
                }
            );

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddSeconds(tokenConfigurations.Seconds)
            });

            return new
            {
                authenticated = true,
                accessToken = handler.WriteToken(securityToken),
                message = "OK"
            };
        }
    }
}