using FinalApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalApp.DAL.Configurations;

public class CategoryConfigurations : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(c => c.Title)
            .HasMaxLength(30)
            .IsRequired();
        
        builder.Property(c => c.Description)
            .HasMaxLength(255)
            .IsRequired();
    }
}