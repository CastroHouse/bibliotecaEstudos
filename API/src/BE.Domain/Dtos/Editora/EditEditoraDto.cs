using System;

namespace BE.Domain.Dtos.Editora
{
    public class EditEditoraDto
    {
        public Guid Id {get;set;}
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public DateTime AnoFundacao { get; set; }
        public string Logo { get; set; }
    }
}