using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class ManutencaoVeiculoProfile : Profile
    {
        public ManutencaoVeiculoProfile()
        {
            CreateMap<ManutencaoVeiculo, ManutencaoVeiculoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.DataManutencao, opt => opt.MapFrom(src => src.DataManutencao))
                .ForMember(dest => dest.TipoManutencao, opt => opt.MapFrom(src => src.TipoManutencao))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.Custo, opt => opt.MapFrom(src => src.Custo))
                .ForMember(dest => dest.Quilometragem, opt => opt.MapFrom(src => src.Quilometragem));
        }
    }
}
