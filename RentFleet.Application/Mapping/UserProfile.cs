using AutoMapper;
using RentFleet.Domain.Entities;
using RentFleet.Application.DTOs;

namespace RentFleet.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.NomeAtendente, opt => opt.MapFrom(src => src.NomeAtendente))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativo))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ForMember(dest => dest.DataAlteracao, opt => opt.MapFrom(src => src.DataAlteracao));
        }
    }
}