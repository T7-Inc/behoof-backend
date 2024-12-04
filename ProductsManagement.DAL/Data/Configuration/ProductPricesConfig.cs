using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

/// <summary>
/// Configuration class for the ProductPrices entity.
/// Maps the entity to the database table and configures its relationships and properties.
/// </summary>
public class ProductPricesConfig : IEntityTypeConfiguration<ProductPrices>
{
    public void Configure(EntityTypeBuilder<ProductPrices> builder)
    {
        // Set table name
        builder.ToTable("productprices");

        // Configure columns
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");
        
        // Configure primary key
        builder.HasKey(e => e.Id)
            .HasName("PK_ProductPrices");
        
        builder.Property(e => e.Created)
            .HasColumnType("timestamp without time zone")
            .HasColumnName("created");

        builder.Property(e => e.Price)
            .HasColumnName("price")
            .HasPrecision(18, 2); // Ensure price has a defined precision

        builder.Property(e => e.TrackedProductsId)
            .HasColumnName("trackedproductsid");

        // Configure relationships
        builder.HasOne(d => d.TrackedProduct)
            .WithMany(p => p.ProductPrices)
            .HasForeignKey(d => d.TrackedProductsId)
            .OnDelete(DeleteBehavior.Cascade) // Add explicit cascade delete behavior
            .HasConstraintName("FK_ProductPrices_TrackedProducts");
    }
}