using System;

namespace BE.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }
        public DateTime CriadoEm { get; protected set; }
        public DateTime AlteradoEm { get; protected set; }
        public bool Ativo { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CriadoEm = DateTime.Now;
            AlteradoEm = DateTime.Now;
            Ativo = true;
        }

        public virtual void Ativar()
        {
            Ativo = true;
            EntidadeAlterada();
        }
        public virtual void Desativar()
        {
            Ativo = false;
            EntidadeAlterada();
        }
        public virtual void EntidadeAlterada() => AlteradoEm = DateTime.Now;
        public abstract void Validar();

    }
}