using System.Text;
using System.Text.Json;

using Alfa.Filmes.Infra.Constants;
using Alfa.Filmes.Infra.Models;

namespace Alfa.Filmes.Infra.service;

public static class JsonFile
{
    public static List<FilmeTable> ReadJson()
    {
        List<FilmeTable> json;

        if (File.Exists(Constantes.FilePath))
        {
            string jsonFile = File.ReadAllText(Constantes.FilePath, Encoding.UTF8);

            if (string.IsNullOrEmpty(jsonFile))
                jsonFile = "[]";

            json = JsonSerializer.Deserialize<List<FilmeTable>>(jsonFile)
                            ?? throw new ArgumentNullException(nameof(FilmeTable));
        }
        else
            json = new List<FilmeTable>();

        return json;
    }

    public static void WriteJson(List<FilmeTable> json)
    {
        string novoJson = JsonSerializer.Serialize(json);

        using var sw = new StreamWriter(path: Constantes.FilePath, append: false, encoding: Encoding.UTF8);

        sw.Write(novoJson);

    }
}