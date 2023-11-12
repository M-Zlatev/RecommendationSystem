namespace RS.Domain;

using Enums;
using Seedwork;
using ValueObjects;

public class Apartment : AggregateRoot
{
    public Apartment(
         ApartmentId id,
         ApartmentStatus apartmentStatus,
         PropertyType propertyType,
         Money price,
         Money pricePerSqM,
         int quadrature,
         Floor floor,
         ConstructionType constructionType,
         int yearOfConstruction,
         Location location,
         bool brokerCommission,
         bool permissionForUse,
         string notes)
    {
        Id = id;
        ApartmentStatus = apartmentStatus;
        PropertyType = propertyType;
        Price = price;
        PricePerSqM = pricePerSqM;
        Quadrature = quadrature;
        Floor = floor;
        ConstructionType = constructionType;
        YearOfConstruction = yearOfConstruction;
        Location = location;
        BrokerCommission = brokerCommission;
        PermissionForUse = permissionForUse;
        Notes = notes;
    }

    public ApartmentId Id { get; set; }

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
