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
            //services.AddDbContext<GestaoRecebiveisContext>(options =>
            //    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
