using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectFlow.Api.Entities;

namespace ProjectFlow.Api.Database.Configurations;

public sealed class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id).HasMaxLength(500);
        builder.Property(p => p.Name).HasMaxLength(100);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.ClientName).HasMaxLength(100);
        builder.OwnsOne(p => p.Target, targetBuilder =>
        {
            targetBuilder.Property(t => t.Unit).HasMaxLength(100);
        });
        builder.OwnsOne(p => p.Milestone);
    }
}
