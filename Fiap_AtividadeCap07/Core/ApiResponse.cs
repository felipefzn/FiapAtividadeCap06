using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Core
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }

        public ApiResponse(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public static ApiResponse<T> CreateSuccessResponse(T data)
        {
            return new ApiResponse<T>(true, data, "Request was successful.");
        }

        public static ApiResponse<T> CreateErrorResponse(string message)
        {
            return new ApiResponse<T>(false, default, message);
        }
    }
}
