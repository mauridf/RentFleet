using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class DadosLocalizacaoOperacaoProfile : Profile
    {
        public DadosLocalizacaoOperacaoProfile()
        {
            CreateMap<DadosLocalizacaoOperacao, DadosLocalizacaoOperacaoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.FilialRegistro, opt => opt.MapFrom(src => src.FilialRegistro))
                .ForMember(dest => dest.StatusLocacao, opt => opt.MapFrom(src => src.StatusLocacao))
                .ForMember(dest => dest.DataAquisicao, opt => opt.MapFrom(src => src.DataAquisicao))
                .ForMember(dest => dest.ValorAquisicao, opt => opt.MapFrom(src => src.ValorAquisicao))
                .ForMember(dest => dest.ValorLocacaoDiaria, opt => opt.MapFrom(src => src.ValorLocacaoDiaria))
                .ForMember(dest => dest.Observacoes, opt => opt.MapFrom(src => src.Observacoes));

        }
    }
}
