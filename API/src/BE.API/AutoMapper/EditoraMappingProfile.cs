using AutoMapper;
using BE.Domain.Dtos.Editora;
using BE.Domain.Entities;

namespace BE.API.AutoMapper
{
    public class EditoraMappingProfile : Profile
    {
        public EditoraMappingProfile()
        {
            CreateMap<Editora, ListEditoraDto>();

            CreateMap<CreateEditoraDto, Editora>()
            .ConstructUsing(l => new Editora(l.Nome, l.CNPJ, l.AnoFundacao, l.Logo));

            CreateMap<EditEditoraDto, Editora>()
            .ConstructUsing(l => new Editora(l.Nome, l.CNPJ, l.AnoFundacao, l.Logo));
        }
    }
}