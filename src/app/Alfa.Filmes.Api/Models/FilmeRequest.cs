using System.ComponentModel;

using Alfa.Filmes.Api.Validators;

namespace Alfa.Filmes.Api.Models;

public class FilmeRequest
{
    // [Required(ErrorMessage = "O Titulo do Filme é obrigatorio")]
    // [MaxLength(255)]
    // [DefaultValue("Carros")]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "O Genero é Obrigatorio")]
    [MaxLength(255)]
    [DefaultValue("Desenho")]
    public string Genero { get; set; } = null!;

    [IfNotNullValidateIfIsDigit]
    [Range(30, 300, ErrorMessage = "Duração deve ser entre 30 e 600 min")]
    [DefaultValue(120)]
    public int Duracao { get; set; }
}