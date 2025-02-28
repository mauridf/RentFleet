using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries
{
    public class GetUserByNomeQuery : IRequest<UserDTO>
    {
        public string Nome { get; set; }
    }
}