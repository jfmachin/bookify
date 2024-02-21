using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;

internal sealed class ApartmentConfiguration : IEntityTypeConfiguration<Apartment> {
    public void Configure(EntityTypeBuilder<Apartment> builder) {
        builder.ToTable("apartments");

        builder.HasKey(x => x.Id);

        builder.OwnsOne(x => x.Address);
        
        builder.Property(x => x.Name)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, x => new Name(x));

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasConversion(x => x.Value, x => new Description(x));

        builder.OwnsOne(x => x.Price,
            x =>
            {
                x.Property(money => money.Currency)
                    .HasConversion(ccy => ccy.Code, code => Currency.FromCode(code));
            });

        builder.OwnsOne(x => x.CleaningFee,
            x =>
            {
                x.Property(money => money.Currency)
                    .HasConversion(ccy => ccy.Code, code => Currency.FromCode(code));
            });

        builder.Property<uint>("Version").IsRowVersion();
    }
}