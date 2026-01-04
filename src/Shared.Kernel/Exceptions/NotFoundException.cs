namespace Shared.Kernel.Exceptions;

public class NotFoundException : DomainException
{
    public NotFoundException(string key, string objectName)
        : base($"Queried object {objectName} was not found, Key: {key}") { }

    public NotFoundException(string key, string objectName, Exception innerException)
        : base($"Queried object {objectName} was not found, Key: {key}", innerException) { }
}
