using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Live.Middlewares
{
    public class LiveMiddleware
    {
        public LiveMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await Task.FromResult(context.Response.StatusCode = StatusCodes.Status200OK);
            await context.Response.WriteAsync("");
        }
    }
}
