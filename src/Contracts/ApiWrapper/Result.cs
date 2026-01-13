    namespace Contracts.ApiWrapper;

    public class Result<T>
    {
        public bool Success { get; init; }
        public T? Data { get; init; }
        public ErrorDetails? Error { get; init; }

        public static Result<T> Ok(T data)
            => new() { Success = true, Data = data };

        public static Result<T> Fail(string code, string message)
            => new()
            {
                Success = false,
                Error = new ErrorDetails
                {
                    Code = code,
                    Message = message
                }
            };

        public static Result<T> NotFound(string message)
            => Fail("NOT_FOUND", message);
    }

