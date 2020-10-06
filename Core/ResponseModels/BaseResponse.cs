namespace University.Core.ResponseModels
{
    public class BaseResponse
    {
        protected BaseResponse(string message, bool success = default)
        {
            Message = message;
            Success = success;
        }

        protected BaseResponse(string message, bool isUiVisible = default, bool success = default)
        {
            Message = message;
            IsUIVisible = isUiVisible;
            Success = success;
        }

        public string Message { get; }
        public bool Success { get; }
        public bool IsUIVisible { get; set; }

        public static BaseResponse Ok(string message) => new BaseResponse(message, true);
        public static BaseResponse<T> Ok<T>(string message, T value) => new BaseResponse<T>(message, value);
        public static BaseResponse<T> Ok<T>(string message, bool isUIVisible, T value) => new BaseResponse<T>(message, isUIVisible, value);
        public static BaseResponse Fail(string message) => new BaseResponse(message, false);
        public static BaseResponse Fail(string message, bool isUIvisible) => new BaseResponse(message, isUIvisible, false);
        public static BaseResponse<T> Fail<T>(string message) => new BaseResponse<T>(message);
    }


    public class BaseResponse<T> : BaseResponse
    {
        public BaseResponse(string message)
            : base(message, false) { }

        public BaseResponse(string message, T value)
            : base(message, true)
        {
            Value = value;
            IsUIVisible = true;
        }

        public BaseResponse(string message, bool isUIVisible, T value)
            : base(message, true)
        {
            Value = value;
            IsUIVisible = isUIVisible;
        }

        public T Value { get; }
    }
}
