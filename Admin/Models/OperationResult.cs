using System;

namespace Flagman.Models
{
    public class OperationResult<TResult>
    {
        OperationResult() { }

        public TResult Value { get; set; }
        public string Html { get; set; }
        public int StatusCode { get;set; }
        public string Message { get; set; }
        public bool IsUIVisible { get; set; }
        public bool IsSuccess { get; private set; }
        public Exception Exception { get; private set; }

        public static OperationResult<TResult> CreateSuccessResult(TResult result)
        {
            return new OperationResult<TResult> { Value = result, IsSuccess = true };
        }

        public static OperationResult<TResult> CreateSuccessHtmlResult(string html)
        {
            return new OperationResult<TResult> { Html = html, IsSuccess = true };
        }

        public static OperationResult<TResult> CreateFailure(string nonSuccessMessage, Exception ex = null, int statusCode = 0)
        {
            return new OperationResult<TResult> { Message = nonSuccessMessage, Exception = ex, IsSuccess = false, StatusCode = statusCode };
        }

        public static OperationResult<TResult> CreateFailure(OperationResult<TResult> operationResult, int statusCode)
        {
            return new OperationResult<TResult> { Message = operationResult.Message, IsUIVisible = operationResult.IsUIVisible, IsSuccess = false, StatusCode = statusCode };
        }

        public bool ValidateResponse(bool displayAlert = true, string customMessage = null, Func<bool> additionalverificationFunc = null)
        {
            var success = IsSuccess && (additionalverificationFunc != null ? additionalverificationFunc() : true);
            if (!success && displayAlert)
            {
                if (!IsUIVisible)
                    Message = null;
                //if (string.IsNullOrEmpty(Message))
                    //Message = customMessage ?? AppResources.ErrorRetryOrCallHotLine;

                //Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.Alert(Message, AppResources.Error, AppResources.OK));
            }

            return success;
        }
    }
}
