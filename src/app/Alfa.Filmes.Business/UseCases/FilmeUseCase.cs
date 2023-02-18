using Alfa.Filmes.Business.Mapper;
using Alfa.Filmes.Infra.Contracts.Repository;
using Alfa.Filmes.Infra.Repository;

namespace Alfa.Filmes.Business.UseCases;

public class FilmeUseCase
{

    private readonly IFilmeRepository _filmeRepository;

    public FilmeUseCase()
    {
        _filmeRepository = new FilmeJsonRepository();
    }

    public void AdicionaFilme(Filme filme)
    {
        _filmeRepository.SalvarFilme(filme.ToTable());
    }

    public IEnumerable<Filme> ObterFilmes() => _filmeRepository.ObterFilmes().ToListFilmes();

    public Filme ObterFilmeById(int id) => _filmeRepository.ObterFilmes().ToListFilmes().First(f => f.Id == id);

    public int GerarId() => _filmeRepository.ObterFilmes().Count + 1;
}