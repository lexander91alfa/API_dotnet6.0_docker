namespace Alfa.Filmes.Business.Contracts;

public interface IUseCase<out TResponse, in TRequest>
{
    public TResponse Execute(TRequest request);
}