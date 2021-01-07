using BE.Core.DomainObjects;
using System;

namespace BE.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Nome { get;  private set; }
        public string SegundoNome { get;  private set; }
        public Guid UserId {get; private set;}
        public string Cpf { get;  private set; }
        public Endereco Endereco { get; private set; }
        public virtual ApplicationUser User {get; private set;}
        public override void Validar()
        {
           Console.WriteLine("Validação na criação de objeto não implementado.");
        }

        protected Usuario()
        {
            
        }
        public Usuario(string nome, string segundoNome, Cpf cpf, ApplicationUser user, Guid userId)
        {
            Nome = nome;
            SegundoNome = segundoNome;
            Cpf = cpf.ToString();
            User = user;
            UserId = userId;
            Validar();
        }


        public Usuario(string nome, string segundoNome, string cpf)
        {
            Nome = nome;
            SegundoNome = segundoNome;
            Cpf = cpf.ToString();
            Validar();
        }

        public void AddUser(ApplicationUser user)
        {
            User = user;
            UserId = user.Id;
        }
    }
}