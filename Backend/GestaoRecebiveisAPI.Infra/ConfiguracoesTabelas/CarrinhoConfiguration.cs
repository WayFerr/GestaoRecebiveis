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
    public class CarrinhoConfiguration : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(x => x.CarrinhoId);

            builder.HasOne(x => x.Empresa)
                .WithOne()
                .HasForeignKey<Carrinho>(x => x.EmpresaId);

            builder.HasMany(x => x.Itens)
                .WithOne(x => x.Carrinho)
                .HasForeignKey(x => x.CarrinhoId);
        }
    }
}
