namespace RS.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Domain.ValueObjects;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> city)
    {
        city.HasKey(c => c.Id);

        city.Property(c => c.Id).HasConversion(
            cityId => cityId.Value,
            value => new CityId(value));

        city
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        city
            .Property(c => c.Country)
            .HasMaxLength(100)
            .IsRequired();
    }
}
