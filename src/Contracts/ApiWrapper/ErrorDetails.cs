namespace Contracts.ApiWrapper;
public class ErrorDetails
{
    public string Code { get; set; } = "";
    public string Message { get; set; } = "";
    public List<InvalidParam>? InvalidParams { get; set; }
}
