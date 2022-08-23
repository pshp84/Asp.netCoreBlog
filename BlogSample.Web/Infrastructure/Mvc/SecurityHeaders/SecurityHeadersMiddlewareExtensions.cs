using System;
using Microsoft.AspNetCore.Builder;

namespace BlogSample.Web.Infrastructure.Mvc.SecurityHeaders;

public static class SecurityHeadersMiddlewareExtensions
{
    public static IApplicationBuilder UseSecurityHeaders(this IApplicationBuilder app, Action<SecurityHeadersOptionsBuilder> builder)
    {
        var newBuilder = new SecurityHeadersOptionsBuilder();
        builder(newBuilder);

        var options = newBuilder.Build();
        return app.UseMiddleware<SecurityHeadersMiddleware>(options);
    }
}
