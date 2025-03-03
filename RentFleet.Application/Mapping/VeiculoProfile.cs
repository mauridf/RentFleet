using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class VeiculoProfile : Profile
    {
        public VeiculoProfile() 
        {
            CreateMap<Veiculo, VeiculoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(src => src.Categoria))
                .ForMember(dest => dest.Marca, opt => opt.MapFrom(src => src.Marca))
                .ForMember(dest => dest.Modelo, opt => opt.MapFrom(src => src.Modelo))
                .ForMember(dest => dest.AnoFabricacao, opt => opt.MapFrom(src => src.AnoFabricacao))
                .ForMember(dest => dest.AnoModelo, opt => opt.MapFrom(src => src.AnoModelo))
                .ForMember(dest => dest.Cor, opt => opt.MapFrom(src => src.Cor))
                .ForMember(dest => dest.Placa, opt => opt.MapFrom(src => src.Placa))
                .ForMember(dest => dest.Chassi, opt => opt.MapFrom(src => src.Chassi))
                .ForMember(dest => dest.QuilometragemInicial, opt => opt.MapFrom(src => src.QuilometragemInicial))
                .ForMember(dest => dest.QuilometragemAtual, opt => opt.MapFrom(src => src.QuilometragemAtual))
                .ForMember(dest => dest.NumeroPortas, opt => opt.MapFrom(src => src.NumeroPortas))
                .ForMember(dest => dest.CapacidadeTanque, opt => opt.MapFrom(src => src.CapacidadeTanque))
                .ForMember(dest => dest.Combustivel, opt => opt.MapFrom(src => src.Combustivel))
                .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
                .ForMember(dest => dest.DataAlteracao, opt => opt.MapFrom(src => src.DataAlteracao));
        }
    }
}
