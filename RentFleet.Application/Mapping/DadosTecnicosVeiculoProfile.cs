using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class DadosTecnicosVeiculoProfile : Profile
    {
        public DadosTecnicosVeiculoProfile()
        {
            CreateMap<DadosTecnicosVeiculo, DadosTecnicosVeiculoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.PotenciaMotor, opt => opt.MapFrom(src => src.PotenciaMotor))
                .ForMember(dest => dest.Cilindrada, opt => opt.MapFrom(src => src.Cilindrada))
                .ForMember(dest => dest.Transmissao, opt => opt.MapFrom(src => src.Transmissao))
                .ForMember(dest => dest.NumeroMarchas, opt => opt.MapFrom(src => src.NumeroMarchas))
                .ForMember(dest => dest.Tracao, opt => opt.MapFrom(src => src.Tracao))
                .ForMember(dest => dest.PesoBrutoTotal, opt => opt.MapFrom(src => src.PesoBrutoTotal))
                .ForMember(dest => dest.CapacidadeCarga, opt => opt.MapFrom(src => src.CapacidadeCarga))
                .ForMember(dest => dest.NumeroEixos, opt => opt.MapFrom(src => src.NumeroEixos));
        }
    }
}
