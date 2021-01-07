using AutoMapper;
using BE.API.Dtos.Usuarios;
using BE.Domain.Entities;

namespace BE.API.AutoMapper.EnderecoMapping
{
    public class EnderecoMappingProfile : Profile
    {
        public EnderecoMappingProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>()
            .ConstructUsing(p => new Endereco(p.usuarioId, p.Cep, p.Estado, p.Cidade, p.Bairro, p.Logradouro, p.Numero, p.Complemento));
        }
    }
}