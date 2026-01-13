namespace Contracts.ApiWrapper;
public abstract class ApiBaseResponse
{
    public bool Success { get; set; }
    public string TraceId { get; set; } = "";
}
