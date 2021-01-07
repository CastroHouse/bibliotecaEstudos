using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using BE.Core.DomainObjects;
using System.Threading.Tasks;
using BE.Data.Maps;
using BE.Domain.Entities;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;

namespace BE.Data.Contexts
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>, IUnitOfWork
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Endereco> Enderecos {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Entity>().HasQueryFilter(p => !p.Ativo);
            modelBuilder.ApplyConfiguration(new ApplicationUserMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }
        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}