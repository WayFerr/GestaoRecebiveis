using GestaoRecebiveisAPI.Application.Interfaces;
using GestaoRecebiveisAPI.Application.Mappings;
using GestaoRecebiveisAPI.Application.Services;
using GestaoRecebiveisAPI.Domain.Interfaces;
using GestaoRecebiveisAPI.Infra;
using GestaoRecebiveisAPI.Infra.Repositorios;
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
            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IRamoDeAtividadeService, RamoDeAtividadeService>();

            return services;
        }

        public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IRamoDeAtividadeRepository, RamoDeAtividadeRepository>();

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
