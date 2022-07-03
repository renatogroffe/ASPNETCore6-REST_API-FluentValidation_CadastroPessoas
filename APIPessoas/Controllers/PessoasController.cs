using Microsoft.AspNetCore.Mvc;
using APIPessoas.Models;
using APIPessoas.Data;

namespace APIPessoas.Controllers;

[ApiController]
[Route("[controller]")]
public class PessoasController : ControllerBase
{
    private readonly ILogger<PessoasController> _logger;
    private readonly PessoasRepository _repository;

    public PessoasController(ILogger<PessoasController> logger,
        PessoasRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public IEnumerable<Pessoa> Get()
    {
        var pessoas = _repository.ListarTodos();
        _logger.LogInformation($"No. de pessoas cadastradas = {pessoas.Count()}");
        return pessoas;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post(DadosPessoa pessoa)
    {
        _repository.Incluir(pessoa);
        _logger.LogInformation(
            $"Novo cadastro realizado com sucesso: {pessoa.Nome} {pessoa.Sobrenome} - {pessoa.Empresa}");
        return Ok();
    }
}