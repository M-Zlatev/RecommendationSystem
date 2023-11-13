namespace RS.Domain.Entities.Apartment;

using Enums;
using Seedwork;
using ValueObjects;

public class Apartment : AggregateRoot
{
    public ApartmentStatus ApartmentStatus { get; set; }

    public PropertyType PropertyType { get; set; }

    public Money Price { get; set; }

    public Money PricePerSqM { get; set; }

    public int Quadrature { get; set; }

    public Floor Floor { get; set; }

    public ConstructionType ConstructionType { get; set; }

    public int YearOfConstruction { get; set; }

    public Location Location { get; set; }

    public bool BrokerCommission { get; set; }

    public bool PermissionForUse { get; set; }

    public string Notes { get; set; }
}
