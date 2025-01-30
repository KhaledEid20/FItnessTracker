using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace Workout.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context){
            var AuthenticOne = context.Request.Headers["Authorization"].ToString();
            var token = AuthenticOne.Replace("Bearer " ,"");
            var handler = new JwtSecurityTokenHandler();
            try{
                var jwtToken = handler.ReadJwtToken(token);
            var email = jwtToken.Claims.First(claim => claim.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;
            var role = jwtToken.Claims.First(claim => claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").Value;
                context.Items["email"] = email;
                context.Items["role"] = role;
            }
            catch(Exception e){
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync(e.Message);}
            await _next(context);
        }
    }
}