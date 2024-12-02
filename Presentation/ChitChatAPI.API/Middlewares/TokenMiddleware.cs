using ChitChatAPI.Aplication.Abstractions.Services;

namespace ChitChatAPI.API.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ITokenService tokenService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault();

            if (!string.IsNullOrEmpty(token))
            {
                if (token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
                {
                    token = token.Substring("Bearer ".Length).Trim();
                }

                var _token = await tokenService.ValidateToken(token);

                if (!_token.IsValid)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Invalid token");
                    return;
                }

                context.Items["Token"] = token;
                context.Items["UserId"] = _token.UserId;
            }

            await _next(context);
        }
    }

}
