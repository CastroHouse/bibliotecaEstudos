using System;
using System.Collections.Generic;

namespace BE.API.Dtos.Auth
{
    public class UsuarioTokenDto
    {
        public Guid Id {get;set;}
        public string Email { get; set; }
        public IEnumerable<UsuarioClaimDto> Claims { get; set; }
    }
}