using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.DTOs.Common
{
    public class OperationResult<T>
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }

        public static OperationResult<T> Success(T data) => new() { IsSuccess = true, Data = data };
        public static OperationResult<T> Fail(string message) => new() { IsSuccess = false, Message = message };
    }
}
