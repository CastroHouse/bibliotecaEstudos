using System;
using AutoMapper;
using BE.API.AutoMapper.EnderecoMapping;
using BE.API.AutoMapper.UsuarioMapping;
using Microsoft.Extensions.DependencyInjection;

namespace BE.API.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddAutoMapper(typeof(UsuarioMappingProfile));
            services.AddAutoMapper(typeof(EnderecoMappingProfile));
            
            return services;
        }
    }
}