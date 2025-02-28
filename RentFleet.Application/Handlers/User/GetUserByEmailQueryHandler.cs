using MediatR;
using RentFleet.Application.DTOs;
using RentFleet.Application.Queries;
using RentFleet.Domain.Entities;
using RentFleet.Domain.Interfaces;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;

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
            var user = await _userRepository.GetByEmailAsync(request.Email);
            if (user == null)
                throw new Exception("Usuário não encontrado.");

            return _mapper.Map<UserDTO>(user);
        }
    }
}