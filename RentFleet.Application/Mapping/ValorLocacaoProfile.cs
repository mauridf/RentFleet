using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class ValorLocacaoProfile : Profile
    {
        public ValorLocacaoProfile()
        {
            CreateMap<ValorLocacao, ValorLocacaoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoVeiculo, opt => opt.MapFrom(src => src.TipoVeiculo))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.ValorDiaria, opt => opt.MapFrom(src => src.ValorDiaria));
        }
    }
}
