using GestaoRecebiveisAPI.Domain.Entidades;
using GestaoRecebiveisAPI.Infra.ConfiguracoesTabelas;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Infra
{
    public class GestaoRecebiveisAPIContext : DbContext
    {
        public GestaoRecebiveisAPIContext(DbContextOptions<GestaoRecebiveisAPIContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<RamoDeAtividade> RamosDeAtividade { get; set; }
        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpresaConfiguration());
            modelBuilder.ApplyConfiguration(new RamoDeAtividadeConfiguration());
            modelBuilder.ApplyConfiguration(new NotaFiscalConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
