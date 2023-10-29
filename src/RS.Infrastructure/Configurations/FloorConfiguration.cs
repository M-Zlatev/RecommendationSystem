namespace RS.Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Domain;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> modelBuilder)
    {
        modelBuilder.HasKey(f => f.Id);

        modelBuilder
            .Property(f => f.ApartmentFloor)
            .IsRequired();

        modelBuilder
            .Property(f => f.TotalFloorsInBuilding)
            .IsRequired();
    }
}
