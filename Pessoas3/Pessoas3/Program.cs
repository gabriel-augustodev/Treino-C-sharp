using Pessoas3.Repositories;
using Pessoas3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPessoaRepositoy, PessoaRepository>();
builder.Services.AddScoped<IPessoaService, PessoaService>();

// 1. Mantenha o OpenApi e ADICIONE o SwaggerGen
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // 2. Mantenha o MapOpenApi e ADICIONE o Swagger UI
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
