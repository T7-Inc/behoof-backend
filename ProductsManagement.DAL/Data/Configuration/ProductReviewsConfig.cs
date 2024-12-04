using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductReviewsConfig : IEntityTypeConfiguration<ProductReviews>
{
    public void Configure(EntityTypeBuilder<ProductReviews> builder)
    {
        builder.ToTable("reviewproducts");

        builder.HasKey(e => e.Id);

        builder.Property(e => e.ReviewContent)
            .HasColumnType("character varying")
            .HasColumnName("ReviewContent");
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.Property(e => e.Rating).HasColumnName("rating");
    }
}