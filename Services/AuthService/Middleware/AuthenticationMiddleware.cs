using System;
using System.Net;

namespace AuthService.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var tokens = new Dictionary<string, string>();
            tokens.Add("token1", "user1");
            tokens.Add("token2", "user2");
            tokens.Add("token3", "user3");

            var auth = context.Request.Headers["Authorization"];
            var token = auth.FirstOrDefault().Substring(7);

            if (tokens.ContainsKey(token))
            {
                Console.WriteLine("AUTH: found user");
                context.Response.Headers.Add("x-current-user", tokens[token]);
                Console.WriteLine(context);

                context.Response.StatusCode = (int)StatusCodes.Status200OK;
                await context.Response.WriteAsync("success");

                // return instantly
                return;

                // go to the service local controllers
                //await _next(context);
            }
            
            Console.WriteLine("AUTH: no such user");
            context.Response.Clear();
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            await context.Response.WriteAsync("Unauthorized - Token Not Found");
        }
    }
}