using AutoMapper;
using RentFleet.Application.Commands;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>();
        }
    }
}