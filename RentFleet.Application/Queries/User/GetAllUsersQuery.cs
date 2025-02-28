using MediatR;
using RentFleet.Application.DTOs;
using System.Collections.Generic;

namespace RentFleet.Application.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<UserDTO>>
    {
        // Esta query não precisa de propriedades, pois retorna todos os usuários
    }
}