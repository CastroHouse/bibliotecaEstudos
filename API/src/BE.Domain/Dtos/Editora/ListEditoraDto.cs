using System;

namespace BE.Domain.Dtos.Editora
{
    public class ListEditoraDto
    {
        public Guid Id {get;set;}
        public string Nome { get; set; }
        public bool Ativo {get;set;}
    }
}