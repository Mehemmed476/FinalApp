using FinalApp.Core.Entities.Characteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalApp.DAL.Configurations;

public class ColorConfigurations : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.Property(c => c.Title)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(c => c.HexCode)
            .HasMaxLength(7)
            .IsRequired();
        
        builder
            .HasOne(c => c.Product)
            .WithMany(c => c.Colors)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}