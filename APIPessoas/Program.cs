using FluentValidation;
using FluentValidation.AspNetCore;
using APIPessoas.Data;
using APIPessoas.Models;
using APIPessoas.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddFluentValidation();

builder.Services.AddTransient<IValidator<DadosPessoa>, DadosPessoaValidator>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<PessoasRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();