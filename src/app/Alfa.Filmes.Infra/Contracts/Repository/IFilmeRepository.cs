using Alfa.Filmes.Infra.Models;

namespace Alfa.Filmes.Infra.Contracts.Repository;
public interface IFilmeRepository
{
    void SalvarFilme(FilmeTable filme);
    void SalvarFilmes(IEnumerable<FilmeTable> filmes);
    List<FilmeTable> ObterFilmes();
}