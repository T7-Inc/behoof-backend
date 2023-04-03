using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class UserTrackedProductsConfig : IEntityTypeConfiguration<UserTrackedProducts>
{
    public void Configure(EntityTypeBuilder<UserTrackedProducts> builder)
    {
        builder.HasKey(e => new { e.Userid, e.Trackedproductsid })
            .HasName("usertrackedproducts_pkey");

        builder.ToTable("usertrackedproducts");

        builder.Property(e => e.Userid)
            .HasMaxLength(255)
            .HasColumnName("userid");

        builder.Property(e => e.Trackedproductsid).HasColumnName("trackedproductsid");

        builder.Property(e => e.Rulesetid).HasColumnName("rulesetid");

        builder.HasOne(d => d.RuleSet)
            .WithMany(p => p.UserTrackedProducts)
            .HasForeignKey(d => d.Rulesetid)
            .HasConstraintName("usertrackedproducts_rulesetid_fkey");

        builder.HasOne(d => d.TrackedProduct)
            .WithMany(p => p.UserTrackedProducts)
            .HasForeignKey(d => d.Trackedproductsid)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("usertrackedproducts_trackedproductsid_fkey");
    }
}