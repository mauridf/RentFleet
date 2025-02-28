using MediatR;

namespace RentFleet.Application.Commands
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
    }
}