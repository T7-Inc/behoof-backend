using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class UserLikedProductsConfig : IEntityTypeConfiguration<UserLikedProducts>
{
    public void Configure(EntityTypeBuilder<UserLikedProducts> builder)
    {
        builder.HasKey(e => e.Userid)
            .HasName("userlikedproducts_pkey");

        builder.ToTable("userlikedproducts");

        builder.Property(e => e.Userid)
            .HasMaxLength(255)
            .HasColumnName("userid");

        builder.Property(e => e.Productid).HasColumnName("productid");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.UserLikedProducts)
            .HasForeignKey(d => d.Productid)
            .HasConstraintName("userlikedproducts_productid_fkey");
    }
}