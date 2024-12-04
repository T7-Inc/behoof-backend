using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class UserLikedProductsConfig : IEntityTypeConfiguration<UserLikedProducts>
{
    public void Configure(EntityTypeBuilder<UserLikedProducts> builder)
    {
        builder.HasKey(e => e.Id);

        builder.Property(e => e.ProductId).HasColumnName("productid");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.UserLikedProducts)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("userlikedproducts_productid_fkey");
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.ToTable("userlikedproducts");

        builder.Property(e => e.UserId)
            .HasMaxLength(255)
            .HasColumnName("userid");
    }
}