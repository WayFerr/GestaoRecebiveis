using GestaoRecebiveisAPI.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GestaoRecebiveisAPI.CrossCutting
{
    public static class IoCContainer
    {
        public static IServiceCollection AdicionarServicos(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AdicionarBancoDeDados(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<GestaoRecebiveisAPIContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
