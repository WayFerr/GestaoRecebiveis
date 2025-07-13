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
    public class ItemCarrinhoConfiguration : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.HasKey(x => x.ItemCarrinhoId);

            builder.HasOne(x => x.NotaFiscal)
                .WithMany()
                .HasForeignKey(x => x.NotaFiscalId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new { x.CarrinhoId, x.NotaFiscalId })
                .IsUnique();
        }
    }
}
