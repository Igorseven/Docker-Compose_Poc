using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class AddressMapping : BaseMapping, IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.ToTable(nameof(Address), Schema);
        builder.HasKey(a => a.AddressId);

        builder.Property(a => a.AddressId).HasColumnName("id_address");

        builder.Property(a => a.CustomerId).HasColumnName("customer_id");

        builder.Property(a => a.AddressType).HasColumnType("tinyint")
               .HasColumnName("address_type").IsRequired(true);

        builder.Property(a => a.Localization).HasColumnType("varchar(100)").IsUnicode(true)
               .HasColumnName("localization").IsRequired(true);

        builder.Property(a => a.State).HasColumnType("varchar(50)").IsUnicode(true)
               .HasColumnName("state").IsRequired(true);

        builder.Property(a => a.City).HasColumnType("varchar(70)").IsUnicode(true)
               .HasColumnName("city").IsRequired(true);

        builder.Property(a => a.District).HasColumnType("varchar(70)").IsUnicode(true)
               .HasColumnName("district").IsRequired(true);

        builder.Property(a => a.Complement).HasColumnType("varchar(100)").IsUnicode(true)
               .HasColumnName("complement").IsRequired(false);

        builder.Property(a => a.Country).HasColumnType("varchar(70)").IsUnicode(true)
               .HasColumnName("country").IsRequired(true);

        builder.Property(a => a.ZipCode).HasColumnType("varchar(20)")
               .HasColumnName("zip_code").IsRequired(true);

        builder.Property(a => a.Number).HasColumnType("varchar(15)").IsUnicode(true)
               .HasColumnName("number").IsRequired(true);
    }
}
