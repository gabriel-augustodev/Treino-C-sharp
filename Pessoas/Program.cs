

using Pessoas.Repositories;
using Pessoas.Services;

var builder = WebApplication.CreateBuilder(args);

//Serviços da API
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaRespository, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();