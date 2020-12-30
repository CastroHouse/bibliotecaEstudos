using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BE.Core.DomainObjects;

namespace BE.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        Task<T> ObterPorId(Guid id);
        Task<IList<T>> ObterPorIds(Guid[] ids);
        Task<IList<T>> ObterTodos();
        Task Adicionar(T t);
        void Atualizar(T t);
        void Remover(T t);

        IUnitOfWork UnitOfWork { get; }
    }
}