using System;
using System.ComponentModel.DataAnnotations;
using BE.Core.DomainObjects;

namespace BE.API.Dtos.Usuarios
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage="O campo {0} é requerido.")]
        public string Nome { get;  set; }
        [Required(ErrorMessage="O campo {0} é requerido.")]
        public string SegundoNome { get;  set; }
        
        [Required(ErrorMessage="O campo {0} é requerido.")]
        [EmailAddress(ErrorMessage="O campo {0} não é um email válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage="O campo {0} é requerido.")]
        public string Senha {get;set;}
        [Compare("Senha", ErrorMessage="As Senhas não conferem")]
        public string ConfirmaSenha {get; set;}
        [Required(ErrorMessage="O campo {0} é requerido.")]
        public string Cpf { get;  set; }
        public CreateEnderecoDto Endereco {get;set;}
    }
}