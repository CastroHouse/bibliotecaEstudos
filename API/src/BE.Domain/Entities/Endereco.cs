using System;

namespace BE.Domain.Entities
{
    public class Endereco 
    {
        public string Cep { get; protected set; }
        public string Estado { get; protected set; }
        public string Cidade { get; protected set; }
        public string Bairro { get; protected set; }
        public string Logradouro { get; protected set; }
        public string Numero { get; protected set; }
        public string Complemento { get; protected set; }
        public Guid UsuarioId {get; protected set;}
        public Usuario Usuario {get; protected set;}

        public Endereco(Guid usuarioId, string cep, string estado, string cidade, string bairro, string logradouro, string numero, string complemento)
        {
            UsuarioId = usuarioId;
            Cep = cep;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
        }
    }
}