using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class RegraDescontoJurosProfile : Profile
    {
        public RegraDescontoJurosProfile()
        {
            CreateMap<RegraDescontoJuros, RegraDescontoJurosDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TipoVeiculo, opt => opt.MapFrom(src => src.TipoVeiculo))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.TipoRegra, opt => opt.MapFrom(src => src.TipoRegra))
                .ForMember(dest => dest.Percentual, opt => opt.MapFrom(src => src.Percentual))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao));
        }
    }
}
