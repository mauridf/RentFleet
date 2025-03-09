using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class ReservaProfile : Profile
    {
        public ReservaProfile()
        {
            CreateMap<Reserva, ReservaDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.DataReserva, opt => opt.MapFrom(src => src.DataReserva))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.DataFim))
                .ForMember(dest => dest.StatusReserva, opt => opt.MapFrom(src => src.StatusReserva));
        }
    }
}
