namespace DSRNetSchool.Common.Extensions;

using DSRNetSchool.Common.Exceptions;
using DSRNetSchool.Common.Responses;
using FluentValidation.Results;

public static class ErrorResponseExtensions
{
    /// <summary>
    /// Make error response from ValidationResult
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ErrorResponse ToErrorResponse(this ValidationResult data)
    {
        var res = new ErrorResponse()
        {
            Message = "",
            FieldErrors = data.Errors.Select(x =>
            {
                var elems = x.ErrorMessage.Split('&');
                var errorName = elems[0];
                var errorMessage = elems.Length > 0 ? elems[1] : errorName;
                return new ErrorResponseFieldInfo()
                {
                    FieldName = x.PropertyName,
                    Message = errorMessage,
                };
            })
        };

        return res;
    }

    /// <summary>
    /// Convert process exception to ErrorResponse
    /// </summary>
    /// <param name="data">Process exception</param>
    /// <returns></returns>
    public static ErrorResponse ToErrorResponse(this ProcessException data)
    {
        var res = new ErrorResponse()
        {
            Message = data.Message
        };

        return res;
    }

    /// <summary>
    /// Convert exception to ErrorResponse
    /// </summary>
    /// <param name="data">Exception</param>
    /// <returns></returns>
    public static ErrorResponse ToErrorResponse(this Exception data)
    {
        var res = new ErrorResponse()
        {
            ErrorCode = -1,
            Message = data.Message
        };

        return res;
    }
}
