using Contas.Application.Dto;

namespace Contas.Application.Contracts;

public interface IContaApplicationService
{
    IEnumerable<ResumoContaDto> GetResumoContas();
    void CreateConta(CreateContaDto contaDto);
}