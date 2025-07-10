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
    public class RamoDeAtividadeConfiguration : IEntityTypeConfiguration<RamoDeAtividade>
    {
        public void Configure(EntityTypeBuilder<RamoDeAtividade> builder)
        {
            builder.HasKey(x => x.RamoAtividadeId);

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasData(
                new RamoDeAtividade { RamoAtividadeId = 1, Descricao = "Produtos" },
                new RamoDeAtividade { RamoAtividadeId = 2, Descricao = "Serviços" }
                );
        }
    }
}
