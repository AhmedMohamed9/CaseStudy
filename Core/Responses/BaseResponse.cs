using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Responses
{
	public class BaseResponse<T>
	{
		public bool Success { get; set; }
		public string? Message { get; set; }
		public T? Data { get; set; }
		public BaseResponse(T data, string? message = null)
		{
			Success = true;
			Data = data;
			Message = message;
		}
		public static BaseResponse<T> SuccessResponse(T data, string? message = null)
		{
			return new BaseResponse<T>(data, message);
		}

		public static BaseResponse<T> Fail(string message)
		{
			return new BaseResponse<T>(default!, message) { Success = false };
		}
	}
}
