using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductOffersConfig : IEntityTypeConfiguration<ProductOffers>
{
    public void Configure(EntityTypeBuilder<ProductOffers> builder)
    {
        builder.ToTable("productoffers");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Instock).HasColumnName("instock");

        builder.Property(e => e.Offerurl)
            .HasMaxLength(255)
            .HasColumnName("offerurl");

        builder.Property(e => e.Price).HasColumnName("price");

        builder.Property(e => e.Productid).HasColumnName("productid");

        builder.Property(e => e.Shippingcost).HasColumnName("shippingcost");

        builder.Property(e => e.Shop)
            .HasMaxLength(50)
            .HasColumnName("shop");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.ProductOffers)
            .HasForeignKey(d => d.Productid)
            .HasConstraintName("productoffers_productid_fkey");
    }
}