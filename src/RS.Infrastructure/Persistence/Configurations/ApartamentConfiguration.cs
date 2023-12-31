﻿namespace RS.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Apartment;

public class ApartamentConfiguration : IEntityTypeConfiguration<Apartment>
{
    public void Configure(EntityTypeBuilder<Apartment> apartament)
    {
        apartament.HasKey(a => a.Id);

        apartament
            .Property(a => a.ApartmentStatus)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        apartament
            .Property(a => a.PropertyType)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        apartament.OwnsOne(a => a.Price, priceBuilder =>
        {
            priceBuilder
                .Property(m => m.Currency)
                .HasMaxLength(3);

            priceBuilder
                .Property(m => m.Amount)
                .HasPrecision(18, 2);
        });

        apartament.OwnsOne(a => a.PricePerSqM, priceBuilder =>
        {
            priceBuilder
                .Property(m => m.Currency)
                .HasMaxLength(3);

            priceBuilder
                .Property(m => m.Amount)
                .HasPrecision(18, 2);
        });

        apartament
            .Property(a => a.Quadrature)
            .IsRequired();

        apartament
            .HasOne(a => a.Floor)
            .WithOne(f => f.Apartament)
            .HasForeignKey<Floor>(f => f.ApartamentId)
            .IsRequired();

        apartament
            .Property(a => a.ConstructionType)
            .HasConversion<string>()
            .HasMaxLength(20)
            .IsRequired();

        apartament
            .Property(a => a.YearOfConstruction)
            .IsRequired();

        apartament
            .HasOne(a => a.Location)
            .WithOne(l => l.Apartament)
            .HasForeignKey<Location>(l => l.ApartamentId)
            .IsRequired();

        apartament
            .Property(a => a.BrokerCommission)
            .IsRequired();

        apartament
            .Property(a => a.PermissionForUse)
            .IsRequired();
    }
}
