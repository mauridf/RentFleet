using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries
{
    public class GetUserByEmailQuery : IRequest<UserDTO>
    {
        public string Email { get; set; }
    }
}