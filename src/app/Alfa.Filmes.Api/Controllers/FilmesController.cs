using Alfa.Filmes.Api.Models;
using Alfa.Filmes.Business.Entities;
using Alfa.Filmes.Business.UseCases;

using Microsoft.AspNetCore.Mvc;

namespace Alfa.Filmes.Api.Controllers;

[ApiController]
[Route("api/v1/filmes/")]
public class FilmesController : ControllerBase
{

    private readonly FilmeUseCase _filmeUseCase;
    private readonly ILogger<FilmesController> _logger;

    public FilmesController(ILogger<FilmesController> logger)
    {
        _filmeUseCase = new FilmeUseCase();
        _logger = logger;
    }


    /// <summary>
    /// Adiciona filme na base
    /// </summary>
    /// <param name="filme"></param>
    /// <returns>Filme inserido na base</returns>
    /// <remarks>
    /// AdicionaFilme request:
    ///
    ///     POST /novo
    ///     {
    ///        "Titulo": Carros,
    ///        "Genero": "Desenho",
    ///        "Duracao": 120
    ///     }
    ///
    /// </remarks>
    /// <response code="200">retorna novo filme criado na base</response>
    [Route("novo"), HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult AdicionaFilme([FromBody] FilmeRequest filme)
    {
        int id = _filmeUseCase.GerarId();

        var newFilme = new Filme(id, filme.Titulo, filme.Genero, filme.Duracao);

        _filmeUseCase.AdicionaFilme(newFilme);

        return Ok(newFilme);
    }

    [Route("todos/titulo"), HttpGet]
    public IActionResult ObterFilmesPorNome()
    {
        _logger.LogInformation("Obtendo filmes");

        var filmes = _filmeUseCase.ObterFilmes();

        _logger.LogInformation($"Quantidade de filmes retornados {filmes.Count()}");

        var nomeFilmes =
                from filme in filmes
                where filme.Id > 2
                orderby filme.Id descending
                select filme.Titulo;

        return Ok(nomeFilmes);
    }

    [Route("todos"), HttpGet]
    public IActionResult ObterFilmes()
    {
        _logger.LogInformation("Obtendo filmes");

        var filmes = _filmeUseCase.ObterFilmes();

        _logger.LogInformation($"Quantidade de filmes retornados {filmes.Count()}");

        return Ok(filmes);
    }

    [Route("filme/{id}"), HttpGet]
    public IActionResult Obter(int id)
    {
        _logger.LogInformation($"Obtendo filme {id}");

        var filme = _filmeUseCase.ObterFilmes().FirstOrDefault(f => f.Id == id);

        if (filme != null)
            return Ok(filme);

        return NotFound("Filme não encontrado.");
    }

    [Route("todos/pag"), HttpGet]
    public IActionResult ObterFilmesPaginado([FromQuery(Name = "inicio")] int inicio, [FromQuery(Name = "fim")] int fim)
    {
        _logger.LogInformation("Obtendo filmes");

        var filmes = _filmeUseCase.ObterFilmes();

        var quantidadeFilmes = filmes.Count();

        if (quantidadeFilmes < fim)
            return BadRequest("Quantidade filmes maior que paginação fim");

        _logger.LogInformation($"Quantidade de filmes retornados {quantidadeFilmes}");

        return Ok(filmes.ToArray()[inicio..fim]);
    }
}