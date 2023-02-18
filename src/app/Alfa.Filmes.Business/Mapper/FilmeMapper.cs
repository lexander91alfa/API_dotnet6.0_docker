namespace Alfa.Filmes.Business.Mapper;

public static class FilmeMapper
{
    public static FilmeTable ToTable(this Filme value)
    {
        return new FilmeTable(value.Id, value.Titulo, value.Genero, value.Duracao);
    }

    public static IEnumerable<Filme> ToListFilmes(this List<FilmeTable> value)
    {
        var filmes = new List<Filme>();

        value.ForEach(f => filmes.Add(new Filme(f.Id, f.Titulo, f.Genero, f.Duracao)));

        return filmes;
    }
}