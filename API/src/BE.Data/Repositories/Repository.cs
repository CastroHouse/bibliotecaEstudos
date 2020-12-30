using System;
using System.Threading.Tasks;
using BE.Core.Data;
using BE.Core.DomainObjects;
using BE.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;

namespace BE.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext DbContext;
        protected readonly DbSet<T> DbSet;
        public IUnitOfWork UnitOfWork => DbContext;
        public Repository(AppDbContext context)
        {
            DbContext = context;
            DbSet = DbContext.Set<T>();
        }
        public async Task Adicionar(T t) => await DbSet.AddAsync(t);
        public void Atualizar(T t)
        {
            DbSet.Attach(t);
            DbContext.Entry(t).State = EntityState.Modified;
        }
        public virtual void Remover(T t) => DbSet.Remove(t);
        public virtual void Dispose() => DbContext?.Dispose();
        public virtual async Task<T> ObterPorId(Guid id) => await DbSet.SingleOrDefaultAsync(x => x.Id == id);
        public virtual async Task<IList<T>> ObterPorIds(Guid[] ids) => await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
        public virtual async Task<IList<T>> ObterTodos() => await DbSet.ToListAsync();

    }
}