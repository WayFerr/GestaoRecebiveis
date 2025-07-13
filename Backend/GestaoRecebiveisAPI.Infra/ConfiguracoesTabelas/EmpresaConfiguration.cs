using GestaoRecebiveisAPI.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoRecebiveisAPI.Infra.ConfiguracoesTabelas
{
    public class EmpresaConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(x => x.EmpresaId);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Cnpj)
                .IsRequired()
                .HasMaxLength(14);

            builder.HasIndex(x => x.Cnpj)
            .IsUnique();

            builder.Property(x => x.FaturamentoMensal)
                .IsRequired()
                .HasColumnType("decimal(16,2)");

            builder.HasOne(x => x.RamoDeAtividade)
                .WithMany(x => x.Empresas)
                .HasForeignKey(x => x.RamoAtividadeId);

            builder.HasMany(x => x.NotasFiscais)
                .WithOne(x => x.Empresa)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
