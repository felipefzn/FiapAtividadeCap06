using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Authorization
{
    public class TokenMiddleware(RequestDelegate next, IConfiguration configuration)
    {
        private readonly RequestDelegate _next = next;
        private readonly string _token = configuration["Jwt:Token"];

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = context.Request.Headers.Authorization.ToString();

                if (authHeader.StartsWith("Bearer "))
                {
                    var token = authHeader["Bearer ".Length..].Trim();

                    if (token == _token)
                    {
                        await _next(context);
                        return;
                    }
                }
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("Token inválido ou ausente.");
        }
    }
}
