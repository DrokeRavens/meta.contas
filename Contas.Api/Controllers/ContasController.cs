using Contas.Application.Contracts;
using Contas.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Contas.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly ILogger<ContasController> _logger;
    private readonly IContaApplicationService _contaApplicationService;

    public ContasController(ILogger<ContasController> logger, IContaApplicationService contaApplicationService)
    {
        _logger = logger;
        _contaApplicationService = contaApplicationService;
    }

    [HttpGet(Name = "GetContas")]
    public IEnumerable<ResumoContaDto> GetContas()
    {
        return _contaApplicationService.GetResumoContas();
    }

    [HttpPost(Name = "CreateConta")]
    public IActionResult CreateConta([FromBody] CreateContaDto contaDto)
    {
        _contaApplicationService.CreateConta(contaDto);

        return Ok();
    }
}