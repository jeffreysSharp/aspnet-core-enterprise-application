using JSE.Client.API.Models;
using JSE.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSE.Client.API.Data.Mappings
{
    public class ClientMapping : IEntityTypeConfiguration<Clients>
    {
        public void Configure(EntityTypeBuilder<Clients> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasColumnType("varchar(15)");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(c => c.Surname)
                .IsRequired()
                .HasColumnType("varchar(10)");

            builder.Property(c => c.GenderId)                
                   .IsRequired()
                   .HasColumnType("uniqueidentifier");

            builder.OwnsOne(c => c.Email, tf =>
            {
                tf.Property(c => c.EmailAddress)
                  .IsRequired()
                  .HasColumnName("EmailAddress")
                  .HasColumnType($"varchar({Email.EmailMaxLength})");
            });

            builder.Property(c => c.Phone)
                   .IsRequired()
                   .HasColumnType("varchar(10)");

            builder.Property(c => c.BirthdayDate)
                   .IsRequired()
                   .HasColumnType("Date");

            builder.OwnsOne(c => c.DocumentNumber, tf =>
            {
                tf.Property(c => c.DocumentNumber)
                .IsRequired()
                .HasMaxLength(ClientDocument.DocumentMaxLength)
                .HasColumnName("DocumentNumber")
                .HasColumnType($"varchar({ClientDocument.DocumentMaxLength})");
            });

            builder.Property(c => c.IsRemoved)
                    .HasDefaultValue(0)
                    .HasColumnType("int");

            builder.HasMany(c => c.Addresses)
                .WithOne(c => c.Client);

            builder.HasMany(c => c.PurchaseHistories)
                .WithOne(c => c.Client);

            builder.ToTable("Clients");
        }
    }
}
