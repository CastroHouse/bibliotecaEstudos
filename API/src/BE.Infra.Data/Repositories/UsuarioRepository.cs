using BE.Infra.Data.Contexts;
using BE.Domain.Entities;
using BE.Domain.Interfaces.Repositories;

namespace BE.Infra.Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BibliotecaDBContext context) : base(context)
        {
            
        }
    }
}