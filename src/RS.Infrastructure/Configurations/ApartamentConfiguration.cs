namespace RS.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

public class ApartamentConfiguration : IEntityTypeConfiguration<Apartament>
{
    public void Configure(EntityTypeBuilder<Apartament> apartament)
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

        apartament
            .Property(a => a.Price)
            .HasPrecision(18, 2)
            .IsRequired();

        apartament
            .Property(a => a.PricePerSqM)
            .HasPrecision(18, 2)
            .IsRequired();

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
