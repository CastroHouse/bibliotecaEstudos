using System;
using BE.Data.Repositories;
using BE.Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BE.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddHttpContextAccessor();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }
    }
}