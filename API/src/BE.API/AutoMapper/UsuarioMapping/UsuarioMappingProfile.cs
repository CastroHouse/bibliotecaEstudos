using AutoMapper;
using BE.API.AutoMapper.EnderecoMapping;
using BE.API.Dtos.Usuarios;
using BE.Domain.Entities;

namespace BE.API.AutoMapper.UsuarioMapping
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