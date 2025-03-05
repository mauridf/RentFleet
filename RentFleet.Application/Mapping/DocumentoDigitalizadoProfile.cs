using AutoMapper;
using RentFleet.Application.DTOs;
using RentFleet.Domain.Entities;

namespace RentFleet.Application.Mapping
{
    public class DocumentoDigitalizadoProfile : Profile
    {
        public DocumentoDigitalizadoProfile()
        {
            CreateMap<DocumentoDigitalizado, DocumentoDigitalizadoDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VeiculoId, opt => opt.MapFrom(src => src.VeiculoId))
                .ForMember(dest => dest.Descricao, opt => opt.MapFrom(src => src.Descricao))
                .ForMember(dest => dest.UrlDocumento, opt => opt.MapFrom(src => src.UrlDocumento));
        }
    }
}
