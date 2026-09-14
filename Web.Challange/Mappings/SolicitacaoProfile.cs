using Application.Service.Challenge.Dtos;
using AutoMapper;
using Domain.Challenge.Entitys;

namespace Web.Challange.Mappings
{
    public class SolicitacaoProfile : Profile
    {
        public SolicitacaoProfile()
        {
         
        // DTO → Model
            CreateMap<SolicitacaoUpdateDto, SolicitacaoModels>();

            // Se quiser também o inverso (Model → DTO)
            CreateMap<SolicitacaoModels, SolicitacaoUpdateDto>();
        }
    }
}
