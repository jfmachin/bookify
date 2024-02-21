using Bookify.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookify.Infrastructure.Configurations;

internal sealed class UserConfiguration: IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder.ToTable("users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, x => new FirstName(x));

        builder.Property(x => x.LastName)
            .HasMaxLength(200)
            .HasConversion(x => x.Value, x => new LastName(x));

        builder.Property(x => x.Email)
            .HasMaxLength(400)
            .HasConversion(x => x.Value, x => new Domain.Users.Email(x));

        builder.HasIndex(x => x.Email).IsUnique();
    }
}