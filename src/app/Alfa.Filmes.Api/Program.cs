using Alfa.Filmes.Api.Middleware;

using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Filmes",
        Description = "API para lista e gravar filmes em um json."
    });

    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "Alfa.Filmes.Api.xml"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Filmes API");
    });
}

app.UseAuthorization();

app.MapControllers();

app.UseErrorMiddleware();

app.UseCors();

app.Run();
