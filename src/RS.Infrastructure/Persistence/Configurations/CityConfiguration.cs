﻿namespace RS.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Apartment;

public class CityConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> city)
    {
        city.HasKey(c => c.Id);

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
