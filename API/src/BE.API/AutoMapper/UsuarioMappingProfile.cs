using AutoMapper;
using BE.Domain.Dtos.Usuarios;
using BE.Domain.Entities;

namespace BE.API.AutoMapper
{
    public class UsuarioMappingProfile : Profile
    {
        public UsuarioMappingProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>()
            .ConstructUsing(p => new Usuario(p.Nome, p.SegundoNome, p.Cpf));
        }
    }
}