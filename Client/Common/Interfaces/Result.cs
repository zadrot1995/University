using Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Common.Interfaces
{
    public interface IResult<out T>
    {
        T Value { get; }
        ApiError ApiError { get; }
        int StatusCode { get; }
        string ErrorMessage { get; }
        bool UIVisible { get; }
        bool IsSuccess { get; }
        bool ValidateResponse(bool displayAlert = true, string customMessage = null, Func<bool> additionalverificationFunc = null);
    }

    public abstract class AbstractResult<TResult> : IResult<TResult>
    {
        public ApiError ApiError { get; private set; }
        public int StatusCode { get; private set; }
        public string ErrorMessage { get; private set; }
        public bool UIVisible { get; private set; }
        public bool IsSuccess { get; private set; }

        public TResult Value { get; private set; }

        public static Result<TResult> CreateSuccessResult(TResult result)
        {
            return new Result<TResult> { Value = result, IsSuccess = true };
        }

        public static Result<TResult> CreateFailureResult(ApiError apiError)
        {
            string error = null;
            if (apiError != null && !apiError.Errors.IsNullOrEmpty())
                error = apiError.Errors[0].Message; //Todo: update with codes
            else if (apiError != null && !string.IsNullOrEmpty(apiError.ErrorDescription))
                error = apiError.ErrorDescription;
            return new Result<TResult> { ApiError = apiError, ErrorMessage = error, IsSuccess = false, StatusCode = apiError?.Status ?? 0 };
        }

        public static Result<TResult> CreateFailureResult(string errorMessage = null, int statusCode = 0)
        {
            return new Result<TResult> { ErrorMessage = errorMessage, IsSuccess = false, UIVisible = !string.IsNullOrEmpty(errorMessage), StatusCode = statusCode };
        }

        public bool ValidateResponse(bool displayAlert = true, string customMessage = null, Func<bool> additionalverificationFunc = null)
        {
            var success = IsSuccess && (additionalverificationFunc != null ? additionalverificationFunc() : true);
            if (!success && displayAlert)
            {
                if (string.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = customMessage ?? AppResources.ServerCannotBeReachedError;

                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.Alert(ErrorMessage, AppResources.Error, AppResources.OK));
            }

            return success;
        }
    }

    public class Result<T> : AbstractResult<T>, IResult<T>
    {

    }
}
