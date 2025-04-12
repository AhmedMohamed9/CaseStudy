using API.Errors;
using Core.Responses;
using System.Net;
using System.Text.Json;

namespace API.MiddleWare
{
	public class ExceptionMiddleware
	{
		private readonly RequestDelegate next;
		private readonly ILogger<ExceptionMiddleware> logger;
		private readonly IHostEnvironment env;

		public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
			IHostEnvironment env)
		{
			this.next = next;
			this.logger = logger;
			this.env = env;
		}
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await next(context);
			}
			catch (Exception ex)
			{
				logger.LogError(ex.Message);
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

				BaseResponse<string> response = BaseResponse<string>.Fail(ex.Message);

				//env.IsDevelopment()
				//	? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace)
				//	: 

				var options = new JsonSerializerOptions()
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase
				};

				var json = JsonSerializer.Serialize(response, options);

				await context.Response.WriteAsync(json);
			}
		}
	}
}
