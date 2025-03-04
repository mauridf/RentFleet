using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class DadosCaminhaoProfile : Profile
    {
        public DadosCaminhaoProfile()
        {
            CreateMap<DadosCaminhao, DadosCaminhaoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.TipoCaminhao, opt => opt.MapFrom(src => src.TipoCaminhao))
                .ForMember(dest => dest.ComprimentoCarroceria, opt => opt.MapFrom(src => src.ComprimentoCarroceria))
                .ForMember(dest => dest.AlturaCarroceria, opt => opt.MapFrom(src => src.AlturaCarroceria))
                .ForMember(dest => dest.LarguraCarroceria, opt => opt.MapFrom(src => src.LarguraCarroceria))
                .ForMember(dest => dest.TipoCarroceria, opt => opt.MapFrom(src => src.TipoCarroceria));
        }
    }
}
