using MediatR;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Queries
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }
}