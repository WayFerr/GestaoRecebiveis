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
    public class NotaFiscalConfiguration : IEntityTypeConfiguration<NotaFiscal>
    {
        public void Configure(EntityTypeBuilder<NotaFiscal> builder)
        {
            builder.HasKey(x => x.NotaFiscalId);

            builder.Property(x => x.Numero)
                .IsRequired();

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(16,2)");

            builder.Property(x => x.DtVencimento)
                .IsRequired();

            builder.HasOne(x => x.Empresa)
                .WithMany(x => x.NotasFiscais)
                .HasForeignKey(x => x.EmpresaId);
        }
    }
}
