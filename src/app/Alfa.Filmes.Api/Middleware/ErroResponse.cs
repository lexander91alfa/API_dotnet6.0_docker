namespace Alfa.Filmes.Api.Middleware;

public class ErroResponse
{
    public readonly string TraceId;
    private readonly List<ErrorDetail> _errors;

    public ErroResponse()
    {
        TraceId = Guid.NewGuid().ToString();
        _errors = new List<ErrorDetail>();
    }

    public record ErrorDetail(string Message);

    public void addError(string message) => _errors.Add(new ErrorDetail(message));

    public IReadOnlyCollection<ErrorDetail> GetErrors() => _errors.AsReadOnly();
}