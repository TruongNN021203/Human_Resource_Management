namespace Contracts.ApiWrapper;
public class ApiResponse<T> : ApiBaseResponse
{
    public T? Data { get; set; }
    public ErrorDetails? Error { get; set; }
}
