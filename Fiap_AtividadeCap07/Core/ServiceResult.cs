using Microsoft.AspNetCore.Mvc;

namespace Fiap_AtividadeCap07.Core
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ServiceResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static ServiceResult SuccessResult(string message = "Operation successful")
        {
            return new ServiceResult(true, message);
        }

        public static ServiceResult FailureResult(string message)
        {
            return new ServiceResult(false, message);
        }
    }
}
