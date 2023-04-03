using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductReviewsConfig : IEntityTypeConfiguration<ProductReviews>
{
    public void Configure(EntityTypeBuilder<ProductReviews> builder)
    {
        builder.ToTable("reviewproducts");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Rating).HasColumnName("rating");

        builder.Property(e => e.Reviewcontent)
            .HasColumnType("character varying")
            .HasColumnName("reviewcontent");
    }
}