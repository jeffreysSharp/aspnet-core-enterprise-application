using JSE.Client.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSE.Client.API.Data.Mappings
{
    public class ClientPurchaseHistoryMapping : IEntityTypeConfiguration<ClientPurchaseHistory>
    {
        public void Configure(EntityTypeBuilder<ClientPurchaseHistory> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.OrderId)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.ToTable("ClientPurchaseHistories");
        }
    }
}
