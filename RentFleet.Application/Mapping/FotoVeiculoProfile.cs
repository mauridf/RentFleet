using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class FotoVeiculoProfile : Profile
    {
        public FotoVeiculoProfile()
        {
            CreateMap<FotoVeiculo, FotoVeiculoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.UrlImagem, opt => opt.MapFrom(src => src.UrlImagem));
        }
    }
}
