using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace RentFleet.Application.Handlers.User
{
    public class GetUserByNomeQueryHandler : IRequestHandler<GetUserByNomeQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByNomeQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByNomeQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Nome", request.Nome); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando usuário por Nome: {Nome}.", request.Nome);

                var user = await _userRepository.GetByNomeAsync(request.Nome);
                if (user == null)
                {
                    log.Warning("Usuário com Nome {Nome} não encontrado.", request.Nome);
                    throw new Exception("Usuário não encontrado.");
                }

                log.Information("Usuário {Nome} encontrado com sucesso.", request.Nome);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar usuário por Nome: {Nome}.", request.Nome);
                throw;
            }
        }
    }
}