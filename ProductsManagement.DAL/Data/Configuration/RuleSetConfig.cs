using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsManagement.DAL.Entities;

namespace ProductsManagement.DAL.Data.Configuration;

public class RuleSetConfig : IEntityTypeConfiguration<RuleSet>
{
    public void Configure(EntityTypeBuilder<RuleSet> builder)
    {
        builder.ToTable("rulesets");

        builder.Property(e => e.Id).HasColumnName("id");

        builder.Property(e => e.Instock).HasColumnName("instock");

        builder.Property(e => e.Maxvalue).HasColumnName("maxvalue");

        builder.Property(e => e.Minvalue).HasColumnName("minvalue");

        builder.Property(e => e.Outstock).HasColumnName("outstock");
    }
}