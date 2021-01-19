using System;
using BE.Domain.Data;
using BE.Domain.Interfaces.Repositories;
using BE.Infra.Data.Contexts;
using BE.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BE.Infra.IoC.Constants;

namespace BE.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {
            services.AddDbContext<BibliotecaDBContext>(opt => {
                opt.UseLazyLoadingProxies();
                opt.UseSqlServer($"Server={Environment.GetEnvironmentVariable(ApplicationEnvironment.Server)};" +
                                $" Database={Environment.GetEnvironmentVariable(ApplicationEnvironment.NomeBD)};" +
                                $" User={Environment.GetEnvironmentVariable(ApplicationEnvironment.Usuario)};" +
                                $" Password={Environment.GetEnvironmentVariable(ApplicationEnvironment.Senha)};" +
                                $" Pooling=true;", p => p.EnableRetryOnFailure())

               .EnableSensitiveDataLogging()
               .LogTo(Console.WriteLine, LogLevel.Information);} );

            return services;
        }

        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddHttpContextAccessor();
            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}