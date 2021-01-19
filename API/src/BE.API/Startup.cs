using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BE.API.Configuration;
using BE.Infra.IoC;

namespace BE.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Configurações do Banco de Dados
            services.AddDatabaseConfiguration();

            //Configurações do Identity
            services.AddIdentityConfiguration(Configuration);

            //Configurações do AutoMapper
            services.AddAutoMapperConfiguration();

            //Configurações da API
            services.AddApiConfiguration();

            //Configurações do Swagger
            services.AddSwaggerConfiguration();

            //Configurações da injeção de dependencia
            
            services.AddDependencyInjectionConfiguration();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwaggerConfiguration();
            }

            app.UseApiConfiguration(env);
        }
    }
}
