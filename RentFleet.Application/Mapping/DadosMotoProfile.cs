using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class DadosMotoProfile : Profile
    {
        public DadosMotoProfile()
        {
            CreateMap<DadosMoto, DadosMotoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.TipoMoto, opt => opt.MapFrom(src => src.TipoMoto))
                .ForMember(dest => dest.CapacidadeBagageiro, opt => opt.MapFrom(src => src.CapacidadeBagageiro));
        }
    }
}
