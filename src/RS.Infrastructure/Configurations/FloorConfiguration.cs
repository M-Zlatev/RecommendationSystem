namespace RS.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;
using Domain.ValueObjects;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> floor)
    {
        floor.HasKey(f => f.Id);

        floor.Property(c => c.Id).HasConversion(
            floorId => floorId.Value,
            value => new FloorId(value));

        floor
            .Property(f => f.ApartmentFloor)
            .IsRequired();

        floor
            .Property(f => f.TotalFloorsInBuilding)
            .IsRequired();
    }
}
