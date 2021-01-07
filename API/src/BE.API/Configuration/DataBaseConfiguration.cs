using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BE.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Logging;
using BE.Core.Constants;

namespace BE.API.Configuration
{
    public static class DataBaseConfiguration
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddDbContext<AppDbContext>(opt => opt
            .UseSqlServer($"Server={Environment.GetEnvironmentVariable(ApplicationEnvironment.Server)};"+
                                 $"Database={Environment.GetEnvironmentVariable(ApplicationEnvironment.NomeBD)};"+
                                 $"User Id={Environment.GetEnvironmentVariable(ApplicationEnvironment.Usuario)};"+
                                 $"Password={Environment.GetEnvironmentVariable(ApplicationEnvironment.Senha)};"+
                                 $"Pooling=true;",
                                 l => l.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)) 
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information));

            return services;
        }
    }
}