using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class DadosSegurancaConformidadeProfile : Profile
    {
        public DadosSegurancaConformidadeProfile()
        {
            CreateMap<DadosSegurancaConformidade, DadosSegurancaConformidadeDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.DataUltimaInspecao, opt => opt.MapFrom(src => src.DataUltimaInspecao))
                .ForMember(dest => dest.StatusInspecao, opt => opt.MapFrom(src => src.StatusInspecao))
                .ForMember(dest => dest.NumeroSeguro, opt => opt.MapFrom(src => src.NumeroSeguro))
                .ForMember(dest => dest.Seguradora, opt => opt.MapFrom(src => src.Seguradora))
                .ForMember(dest => dest.ValidadeSeguro, opt => opt.MapFrom(src => src.ValidadeSeguro))
                .ForMember(dest => dest.DataUltimaManutencao, opt => opt.MapFrom(src => src.DataUltimaManutencao))
                .ForMember(dest => dest.ProximaManutencao, opt => opt.MapFrom(src => src.ProximaManutencao))
                .ForMember(dest => dest.StatusVeiculo, opt => opt.MapFrom(src => src.StatusVeiculo));
        }
    }
}
