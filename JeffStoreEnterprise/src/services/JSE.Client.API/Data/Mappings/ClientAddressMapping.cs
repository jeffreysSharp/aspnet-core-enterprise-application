using JSE.Client.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSE.Client.API.Data.Mappings
{
    public class ClientAddressMapping : IEntityTypeConfiguration<ClientAddress>
    {
        public void Configure(EntityTypeBuilder<ClientAddress> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.AddressType)
                    .HasColumnType("int");

            builder.Property(c => c.IsDefaultAddress)
                    .HasColumnType("int");

            builder.Property(c => c.Addresss)
                    .IsRequired()
                    .HasColumnType("varchar(100)");

            builder.Property(c => c.Number)
                    .IsRequired()
                    .HasColumnType("varchar(15)");


            builder.Property(c => c.Complement)
                    .HasColumnType("varchar(30)");

            builder.Property(c => c.ZipCode)
                    .IsRequired()
                    .HasColumnType("varchar(15)");


            builder.Property(c => c.Country)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(c => c.Country)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(c => c.City)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(c => c.State)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.Property(c => c.Reference)                    
                    .HasColumnType("varchar(100)");

            builder.ToTable("ClientAddresses");
        }
    }
}
