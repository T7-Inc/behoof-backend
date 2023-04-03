using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductPricesConfig : IEntityTypeConfiguration<ProductPrices>
{
    public void Configure(EntityTypeBuilder<ProductPrices> builder)
    {
        builder.ToTable("productprices");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.Property(e => e.Created)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created");

        builder.Property(e => e.Price).HasColumnName("price");

        builder.Property(e => e.TrackedProductsId).HasColumnName("trackedproductsid");

        builder.HasOne(d => d.TrackedProduct)
            .WithMany(p => p.ProductPrices)
            .HasForeignKey(d => d.TrackedProductsId)
            .HasConstraintName("productprices_trackedproductsid_fkey");
    }
}