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
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserDTO>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var log = Log.ForContext("Email", request.Email); // Adiciona contexto ao log

            try
            {
                log.Information("Buscando usuário por E-mail: {Email}.", request.Email);

                var user = await _userRepository.GetByEmailAsync(request.Email);
                if (user == null)
                {
                    log.Warning("Usuário com E-mail {Email} não encontrado.", request.Email);
                    throw new Exception("Usuário não encontrado.");
                }

                log.Information("Usuário {E-mail} encontrado com sucesso.", request.Email);

                var userDto = _mapper.Map<UserDTO>(user);
                log.Information("Mapeamento concluído com sucesso para o usuário {Email}.", request.Email);

                return userDto;
            }
            catch (Exception ex)
            {
                log.Error(ex, "Erro ao buscar usuário por E-mail: {Email}.", request.Email);
                throw;
            }
        }
    }
}