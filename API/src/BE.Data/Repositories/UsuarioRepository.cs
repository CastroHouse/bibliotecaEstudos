using BE.Data.Contexts;
using BE.Domain.Entities;
using BE.Domain.Interfaces.Repositories;

namespace BE.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            
        }
    }
}