using KebabStore.Core.Models;
using KebabStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KebabStore.DataAccess.Configurations;

public class KebabConfiguration : IEntityTypeConfiguration<KebabEntity>
{
    public void Configure(EntityTypeBuilder<KebabEntity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(k => k.Name)
            .HasMaxLength(Kebab.MAX_NAME_LENGTH)
            .IsRequired();

        builder.Property(k => k.Description)
            .HasMaxLength(Kebab.MAX_DESCRIPTION_LENGTH)
            .IsRequired();

        builder.Property(k => k.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");
    }
}
