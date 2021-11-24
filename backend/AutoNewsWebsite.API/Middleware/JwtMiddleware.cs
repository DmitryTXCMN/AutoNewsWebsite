using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoNewsWebsite.API.Services;
using AutoNewsWebsite.DAL;
using AutoNewsWebsite.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AutoNewsWebsite.API.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly AppSettings _appSettings;
        private readonly string _token;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
            _token = AppSettings.Token;
            //_appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

             if (token != null)
                 await AttachAccountToContext(context);

            await _next(context);
        }

        private async Task AttachAccountToContext(HttpContext context)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_token);
                tokenHandler.ValidateToken(_token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                //var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
                var accountId = Guid.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach account to context on successful jwt validation
                //context.Items["Account"] = await dataContext.Accounts.FindAsync(accountId);
                //context.Items["Account"] = Handler.GetFromIndex<Users>(accountId);
                context.Items["Account"] = new User() {Id = Guid.NewGuid(), Login = "login", Password = "Pass"};
            }
            catch 
            {
                // do nothing if jwt validation fails
                // account is not attached to context so request won't have access to secure routes
            }
        }
    }
}