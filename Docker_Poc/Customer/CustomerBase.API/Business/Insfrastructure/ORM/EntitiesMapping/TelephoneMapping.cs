using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class TelephoneMapping : BaseMapping, IEntityTypeConfiguration<Telephone>
{
    public void Configure(EntityTypeBuilder<Telephone> builder)
    {
        builder.ToTable(nameof(Telephone), Schema);
        builder.HasKey(t => t.TelephoneId);

        builder.Property(t => t.TelephoneId).HasColumnName("id_telephone");

        builder.Property(t => t.CustomerId).HasColumnName("customer_id");

        builder.Property(t => t.TelephoneType).HasColumnType("tinyint")
               .HasColumnName("telephone_type").IsRequired(true);

        builder.Property(t => t.Ddi).HasColumnType("varchar(6)").IsUnicode(true)
               .HasColumnName("ddi").IsRequired(true);

        builder.Property(t => t.Ddd).HasColumnType("varchar(3)").IsUnicode(true)
               .HasColumnName("ddd").IsRequired(false);

        builder.Property(t => t.PhoneNumber).HasColumnType("varchar(11)").IsUnicode(true)
               .HasColumnName("phone_number").IsRequired(true);

    }
}
