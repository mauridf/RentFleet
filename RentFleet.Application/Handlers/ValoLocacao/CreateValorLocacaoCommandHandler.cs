using MediatR;
using RentFleet.Application.Commands.ValorLocacao;
using RentFleet.Domain.Interfaces;
using Serilog;

namespace RentFleet.Application.Handlers.ValoLocacao
{
    public class CreateValorLocacaoCommandHandler : IRequestHandler<CreateValorLocacaoCommand, int>
    {
        private readonly IValorLocacaoRepository _valorLocacaoRepository;

        public CreateValorLocacaoCommandHandler(IValorLocacaoRepository valorLocacaoRepository)
        {
            _valorLocacaoRepository = valorLocacaoRepository;
        }

        public async Task<int> Handle(CreateValorLocacaoCommand request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("ValorLocacao", request.TipoVeiculo); // Adiciona contexto ao log

            try
            {
                log.Information("Registrando Valor Locação para o Tipo de Veiculo: {TipoVeiculo}.", request.TipoVeiculo);

                var valor = new RentFleet.Domain.Entities.ValorLocacao
                {
                    TipoVeiculo = request.TipoVeiculo,
                    Categoria = request.Categoria,
                    ValorDiaria = request.ValorDiaria
                };

                await _valorLocacaoRepository.AddAsync(valor);

                log.Information("Valor Locação para Tipo Veículo {TipoVeiculo} inserido com sucesso. ID: {Id}.", request.TipoVeiculo, valor.Id);
                return valor.Id;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao inserir valor de locação para o tipo de veículo: {TipoVeiculo}.", request.TipoVeiculo);
                throw;
            }
        }
    }
}
