using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductPhotosConfig : IEntityTypeConfiguration<ProductPhotos>
{
    public void Configure(EntityTypeBuilder<ProductPhotos> builder)
    {
        builder.ToTable("productphotos");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.Property(e => e.PhotoUrl)
            .HasMaxLength(255)
            .HasColumnName("photourl");

        builder.Property(e => e.TrackedProductsId).HasColumnName("trackedproductsid");

        builder.HasOne(d => d.TrackedProduct)
            .WithMany(p => p.ProductPhotos)
            .HasForeignKey(d => d.TrackedProductsId)
            .HasConstraintName("productphotos_trackedproductsid_fkey");
    }
}