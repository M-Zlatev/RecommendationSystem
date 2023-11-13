namespace RS.Infrastructure.Persistence.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain.Entities.Apartment;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> floor)
    {
        floor.HasKey(f => f.Id);

        floor
            .Property(f => f.ApartmentFloor)
            .IsRequired();

        floor
            .Property(f => f.TotalFloorsInBuilding)
            .IsRequired();
    }
}
