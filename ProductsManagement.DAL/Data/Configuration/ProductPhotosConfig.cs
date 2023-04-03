using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductPhotosConfig : IEntityTypeConfiguration<ProductPhotos>
{
    public void Configure(EntityTypeBuilder<ProductPhotos> builder)
    {
        builder.ToTable("productphotos");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Photourl)
            .HasMaxLength(255)
            .HasColumnName("photourl");

        builder.Property(e => e.Trackedproductsid).HasColumnName("trackedproductsid");

        builder.HasOne(d => d.TrackedProduct)
            .WithMany(p => p.ProductPhotos)
            .HasForeignKey(d => d.Trackedproductsid)
            .HasConstraintName("productphotos_trackedproductsid_fkey");
    }
}