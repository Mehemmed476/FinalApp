using FinalApp.Core.Entities.Characteristics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalApp.DAL.Configurations;

public class SizeConfigurations : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.Property(s => s.Title)
            .HasMaxLength(30)
            .IsRequired();
        
        builder
            .HasOne(c => c.Product)
            .WithMany(c => c.Sizes)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}