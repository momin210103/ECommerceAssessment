using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Amount)
            .HasPrecision(18, 2);

        builder.Property(x => x.TransactionId)
            .HasMaxLength(200);

        builder.HasIndex(x => x.TransactionId)
            .IsUnique();

        builder.HasOne(x => x.Order)
            .WithOne(x => x.Payment)
            .HasForeignKey<Payment>(x => x.OrderId);
    }
}