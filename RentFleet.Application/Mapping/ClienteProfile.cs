using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile() 
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Telefone, opt => opt.MapFrom(src => src.Telefone))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CpfCnpj, opt => opt.MapFrom(src => src.CpfCnpj))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Endereco, opt => opt.MapFrom(src => src.Endereco))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.UF, opt => opt.MapFrom(src => src.UF))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ForMember(dest => dest.DataAlteracao, opt => opt.MapFrom(src => src.DataAlteracao));
        }
    }
}
