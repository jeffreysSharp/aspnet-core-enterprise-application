using JSE.Catalogo.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSE.Catalogo.API.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(x => x.Imagem)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.ToTable("Produtos");
        }
    }
}
