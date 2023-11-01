namespace RS.Domain;

using Enums;
using ValueObjects;

public class Apartament
{
    public Apartament(ApartamentId id, ApartmentStatus apartmentStatus, PropertyType propertyType, Money price)
    {
        Id = id;
        ApartmentStatus = apartmentStatus;
        PropertyType = propertyType;
        Price = price;
    }

    public ApartamentId Id { get; set; }

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
