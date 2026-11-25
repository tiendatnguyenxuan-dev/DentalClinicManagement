namespace BLL_DCM
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; } = string.Empty;

        public static OperationResult Success(string message = "Thao tác thành công.")
        {
            return new OperationResult { IsSuccess = true, Message = message };
        }

        public static OperationResult Failure(string message)
        {
            return new OperationResult { IsSuccess = false, Message = message };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Data { get; set; }

        public static OperationResult<T> Success(T data, string message = "Thao tác thành công.")
        {
            return new OperationResult<T> { IsSuccess = true, Message = message, Data = data };
        }

        public new static OperationResult<T> Failure(string message)
        {
            return new OperationResult<T> { IsSuccess = false, Message = message, Data = default };
        }
    }
}
