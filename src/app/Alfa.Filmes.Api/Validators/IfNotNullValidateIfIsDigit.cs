namespace Alfa.Filmes.Api.Validators;

public class IfNotNullValidateIfIsDigit : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return value switch
        {
            (null) or ("") => ValidationResult.Success,
            string v when v.Any(c => !char.IsNumber(c)) => new ValidationResult("Valore não Númerico"),
            _ => ValidationResult.Success
        };
    }
}