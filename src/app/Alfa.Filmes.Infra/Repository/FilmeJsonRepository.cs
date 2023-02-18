using Alfa.Filmes.Infra.Contracts.Repository;
using Alfa.Filmes.Infra.Models;
using Alfa.Filmes.Infra.service;

namespace Alfa.Filmes.Infra.Repository;

public class FilmeJsonRepository : IFilmeRepository
{
    public List<FilmeTable> ObterFilmes()
    {
        return JsonFile.ReadJson();
    }

    public void SalvarFilme(FilmeTable filme)
    {
        var json = JsonFile.ReadJson();

        json.Add(filme);

        JsonFile.WriteJson(json);
    }

    public void SalvarFilmes(IEnumerable<FilmeTable> filmes)
    {
        var json = JsonFile.ReadJson();

        json.AddRange(filmes);

        JsonFile.WriteJson(json);
    }
}