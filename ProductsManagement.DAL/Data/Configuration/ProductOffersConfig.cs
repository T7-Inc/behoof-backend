using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class ProductOffersConfig : IEntityTypeConfiguration<ProductOffers>
{
    public void Configure(EntityTypeBuilder<ProductOffers> builder)
    {
        builder.ToTable("productoffers");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .UseIdentityColumn()
            .HasColumnName("id");

        builder.Property(e => e.Instock).HasColumnName("instock");

        builder.Property(e => e.OfferUrl)
            .HasMaxLength(255)
            .HasColumnName("offerurl");

        builder.Property(e => e.Price).HasColumnName("price");

        builder.Property(e => e.ProductId).HasColumnName("productid");

        builder.Property(e => e.ShippingCost).HasColumnName("shippingcost");

        builder.Property(e => e.Shop)
            .HasMaxLength(50)
            .HasColumnName("shop");

        builder.HasOne(d => d.Product)
            .WithMany(p => p.ProductOffers)
            .HasForeignKey(d => d.ProductId)
            .HasConstraintName("productoffers_productid_fkey");
    }
}