using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class UserTrackedProductsConfig : IEntityTypeConfiguration<UserTrackedProducts>
{
    public void Configure(EntityTypeBuilder<UserTrackedProducts> builder)
    {
        builder.ToTable("usertrackedproducts");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");
        
        builder.Property(e => e.UserId)
            .HasMaxLength(255)
            .HasColumnName("userid");

        builder.Property(e => e.TrackedproductsId).HasColumnName("trackedproductsid");

        builder.Property(e => e.RulesetId).HasColumnName("rulesetid");

        builder.HasOne(d => d.RuleSet)
            .WithMany(p => p.UserTrackedProducts)
            .HasForeignKey(d => d.RulesetId)
            .HasConstraintName("usertrackedproducts_rulesetid_fkey");

        builder.HasOne(d => d.TrackedProduct)
            .WithMany(p => p.UserTrackedProducts)
            .HasForeignKey(d => d.TrackedproductsId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usertrackedproducts_trackedproductsid_fkey");
    }
}