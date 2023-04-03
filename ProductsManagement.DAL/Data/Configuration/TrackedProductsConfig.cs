using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class TrackedProductsConfig : IEntityTypeConfiguration<TrackedProducts>
{
    public void Configure(EntityTypeBuilder<TrackedProducts> builder)
    {
        builder.ToTable("trackedproducts");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.HasIndex(e => e.Producturl, "trackedproducts_producturl_key")
            .IsUnique();

        builder.Property(e => e.Aproximateprofit).HasColumnName("aproximateprofit");

        builder.Property(e => e.Description).HasColumnName("description");

        builder.Property(e => e.Maxprice).HasColumnName("maxprice");

        builder.Property(e => e.Minprice).HasColumnName("minprice");

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .HasColumnName("name");

        builder.Property(e => e.Producturl)
            .HasMaxLength(255)
            .HasColumnName("producturl");

        builder.Property(e => e.Ratingbyreviews).HasColumnName("ratingbyreviews");
    }
}