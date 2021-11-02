using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyFirstApi.Middleware
{
    public class MiddleWare
    {
        private readonly RequestDelegate _next;

        public MiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue("User-Agent", out var header);
            await _next(context);
            
            Console.WriteLine($"From Middleware\n---------------\nTool used to send:\n{header}");
        }
    }
}