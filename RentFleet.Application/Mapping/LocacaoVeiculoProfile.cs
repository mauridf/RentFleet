using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class LocacaoVeiculoProfile : Profile
    {
        public LocacaoVeiculoProfile()
        {
            CreateMap<LocacaoVeiculo, LocacaoVeiculoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.ClienteId, opt => opt.MapFrom(src => src.ClienteId))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio))
                .ForMember(dest => dest.DataFim, opt => opt.MapFrom(src => src.DataFim))
                .ForMember(dest => dest.ValorBase, opt => opt.MapFrom(src => src.ValorBase))
                .ForMember(dest => dest.Desconto, opt => opt.MapFrom(src => src.Desconto))
                .ForMember(dest => dest.Juros, opt => opt.MapFrom(src => src.Juros))
                .ForMember(dest => dest.ValorTotal, opt => opt.MapFrom(src => src.ValorTotal))
                .ForMember(dest => dest.StatusLocacao, opt => opt.MapFrom(src => src.StatusLocacao))
                .ForMember(dest => dest.QuilometragemInicial, opt => opt.MapFrom(src => src.QuilometragemInicial))
                .ForMember(dest => dest.QuilometragemFinal, opt => opt.MapFrom(src => src.QuilometragemFinal))
                .ForMember(dest => dest.DataDevolucao, opt => opt.MapFrom(src => src.DataDevolucao))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes));
        }
    }
}
