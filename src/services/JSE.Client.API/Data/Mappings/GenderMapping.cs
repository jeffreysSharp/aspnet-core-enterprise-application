using JSE.Client.API.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace JSE.Client.API.Data.Mappings
{
    public class GenderMapping: IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.GenderName)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            builder.ToTable("Genders");
        }
    }
}
