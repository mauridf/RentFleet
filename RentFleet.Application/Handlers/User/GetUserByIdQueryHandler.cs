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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("UserId", request.Id); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando usuário por ID: {UserId}.", request.Id);

                var user = await _userRepository.GetByIdAsync(request.Id);
                if (user == null)
                {
                    log.Warning("Usuário com ID {UserId} não encontrado.", request.Id);
                    throw new Exception("Usuário não encontrado.");
                }

                log.Information("Usuário {UserId} encontrado com sucesso.", request.Id);
                return _mapper.Map<UserDTO>(user);
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar usuário por ID: {UserId}.", request.Id);
                throw;
            }
        }
    }
}