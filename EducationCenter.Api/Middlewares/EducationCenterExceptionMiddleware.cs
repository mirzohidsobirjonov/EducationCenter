using EducationCenter.Service.Exceptions;

namespace EducationCenter.Api.Middlewares
{
    public class EducationCenterExceptionMiddleware
    {
        private RequestDelegate next;
        private readonly ILogger<EducationCenterExceptionMiddleware> logger;
        public EducationCenterExceptionMiddleware(RequestDelegate next, ILogger<EducationCenterExceptionMiddleware> logger)
        {
            this.logger = logger;
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (EducationCenterException ex)
            {
                await HandleExceptionAsync(context, ex.Code, ex.Message);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                await HandleExceptionAsync(context, 500, ex.Message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, int code, string message)
        {
            context.Response.StatusCode = code;
            await context.Response.WriteAsJsonAsync(new
            {
                Code = code,
                Message = message
            });
        }
    }
}
