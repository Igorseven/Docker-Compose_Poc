using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CustomerBase.API.Business.Insfrastructure.ORM.EntitiesMapping;
public sealed class CustomerMapping : BaseMapping, IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable(nameof(Customer), Schema);
        builder.HasKey(c => c.CustomerId);

        builder.Property(c => c.CustomerId).HasColumnName("id_customer");

        builder.Property(c => c.FullName).HasColumnType("varchar(150)").IsUnicode(true)
               .HasColumnName("full_name").IsRequired(true);

        builder.HasMany(c => c.Telephones)
               .WithOne()
               .HasForeignKey(t => t.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Addresses)
               .WithOne()
               .HasForeignKey(t => t.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(c => c.Emails)
               .WithOne()
               .HasForeignKey(t => t.CustomerId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
