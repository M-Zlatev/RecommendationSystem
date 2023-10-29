namespace RS.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> location)
    {
        location.HasKey(l => l.Id);

        location
            .Property(l => l.StreetAddress)
            .HasMaxLength(100)
            .IsRequired();

        location
            .Property(l => l.PostalCode)
            .HasMaxLength(10)
            .IsRequired();

        location
            .HasOne(l => l.City)
            .WithOne(c => c.Location)
            .HasForeignKey<City>(c => c.LocationId)
            .IsRequired();
    }
}
