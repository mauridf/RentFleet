using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace RentFleet.Application.Handlers.User
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDTO>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("UserId", request); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando todos os usuários.", request);

                var users = await _userRepository.GetAllAsync();
                if (users == null)
                {
                    log.Warning("Nenhum Usuário foi encontrado.", request);
                    throw new Exception("Nenhum usuário encontrado.");
                }
                log.Information("Todos Usuários cadastrados encontrados.", request);
                return _mapper.Map<IEnumerable<UserDTO>>(users);
            }
            catch (Exception ex) 
            {
                log.Error(ex, "Erro ao buscar todos usuários.", request);
                throw;
            }
        }
    }
}