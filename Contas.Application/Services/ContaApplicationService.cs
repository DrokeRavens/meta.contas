using System.Xml.Schema;
using Contas.Application.Contracts;
using Contas.Application.Dto;
using Contas.Domain.Contracts;
using Contas.Domain.Entities;
using Mapster;

namespace Contas.Application.Services;

public class ContaApplicationService : IContaApplicationService
{
    private readonly IContaRepository _contaRepository;
    
    public ContaApplicationService(IContaRepository contaRepository)
    {
        _contaRepository = contaRepository;
    }
    
    public IEnumerable<ResumoContaDto> GetResumoContas()
    {
        var contasDb = _contaRepository.GetContas();
        
        var contasDbOrdenadasPorDataVencimento = contasDb.OrderByDescending(x => x.DataVencimento);
        
        return contasDbOrdenadasPorDataVencimento.Adapt<IEnumerable<ResumoContaDto>>();
    }

    public void CreateConta(CreateContaDto contaDto)
    {
        var contaDb = new Conta(contaDto.Nome, contaDto.DataVencimento, contaDto.DataPagamento, contaDto.ValorOriginal);

        _contaRepository.CreateConta(contaDb);
    }
}