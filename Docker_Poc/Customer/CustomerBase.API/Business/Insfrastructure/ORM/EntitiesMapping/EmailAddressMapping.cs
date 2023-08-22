using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class EmailAddressMapping : BaseMapping, IEntityTypeConfiguration<EmailAddress>
{
    public void Configure(EntityTypeBuilder<EmailAddress> builder)
    {
        builder.ToTable(nameof(EmailAddress), Schema);
        builder.HasKey(e => e.EmailAddressId);

        builder.Property(e => e.EmailAddressId).HasColumnName("id_emailAddress");

        builder.Property(e => e.CustomerId).HasColumnName("customer_id");

        builder.Property(e => e.EmailType).HasColumnType("tinyint")
               .HasColumnName("email_type").IsRequired(true);

        builder.Property(e => e.Email).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("email").IsRequired(true);

    }
}
