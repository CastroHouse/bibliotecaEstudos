using BE.Domain.Objects;
using System;

namespace BE.Domain.Entities
{
    public class Editora : Entity
    {

        public string Nome { get; private set; }
        public string CNPJ { get; private set; }
        public DateTime AnoFundacao { get; private set; }
        public string Logo { get; private set; }

        protected Editora()
        {
            
        }

        public Editora(string nome, string cnpj, DateTime anoFundacao, string logo)
        {
            Nome = nome;
            CNPJ = cnpj;
            AnoFundacao = anoFundacao;
            Logo = logo;
            Validar();
        }

        public void EditaLogo(string logo)
        {
            Logo = logo;
            EntidadeAlterada();
        }

        public void EditaEditora(string nome, string cnpj, DateTime anoFundacao, string logo)
        {
            Nome = nome;
            CNPJ = cnpj;
            AnoFundacao = anoFundacao;
            Logo = logo;
            Validar();
        }

        
        public override void Validar()
        {
           Console.WriteLine("Validação na criação de objeto não implementado.");
        }
    }
}