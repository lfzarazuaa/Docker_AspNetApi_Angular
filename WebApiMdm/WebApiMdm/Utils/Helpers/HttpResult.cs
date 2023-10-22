using Microsoft.AspNetCore.Mvc;

namespace WebApiMdm.Utils.Helpers;
public class HttpResult<T>
{
    public T? Data { get; private set; }
    public bool IsSuccess { get; private set; }
    public string? Message { get; private set; }
    public int StatusCode { get; private set; }

    private HttpResult() // Private constructor
    {
    }

    public ActionResult<T> ToActionResult()
    {
        if (IsSuccess)
            return new ObjectResult(Data) { StatusCode = StatusCode};
        else
            return new ObjectResult(new { Message, StatusCode }) { StatusCode = StatusCode };
    }

    public class Builder
    {
        private readonly HttpResult<T> _result = new HttpResult<T>();

        public Builder WithData(T data)
        {
            _result.Data = data;
            return this;
        }

        public Builder WithMessage(string message)
        {
            _result.Message = message;
            return this;
        }

        public Builder WithStatusCode(int statusCode)
        {
            _result.StatusCode = statusCode;
            return this;
        }

        public Builder Success(T data, string message = "Operation successful.", int statusCode = 200)
        {
            _result.Data = data;
            _result.Message = message;
            _result.StatusCode = statusCode;
            _result.IsSuccess = true;
            return this;
        }

        public Builder Failure(string message, int statusCode)
        {
            _result.Data = default;
            _result.Message = message;
            _result.StatusCode = statusCode;
            _result.IsSuccess = false;
            return this;
        }

        public HttpResult<T> Build()
        {
            return _result;
        }
    }
}

