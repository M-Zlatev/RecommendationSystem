namespace RS.Application.Apartments.Update;

using MediatR;

using Domain;
using Domain.Enums;
using Domain.ValueObjects;

public record UpdateApartmentCommand(
    ApartmentId ApartmentId,
    ApartmentStatus ApartmentStatus,
    PropertyType PropertyType,
    string PriceCurrency,
    decimal PriceAmount,
    string PricePerSqMCurrency,
    decimal PricePerSqMAmount,
    int Quadrature,
    Floor Floor,
    ConstructionType ConstructionType,
    int YearOfConstruction,
    Location Location,
    bool BrokerCommission,
    bool PermissionForUse,
    string Notes
    ) : IRequest;

// without Id
public record UpdateApartmentRequest(
    ApartmentStatus ApartmentStatus,
    PropertyType PropertyType,
    string PriceCurrency,
    decimal PriceAmount,
    string PricePerSqMCurrency,
    decimal PricePerSqMAmount,
    int Quadrature,
    Floor Floor,
    ConstructionType ConstructionType,
    int YearOfConstruction,
    Location Location,
    bool BrokerCommission,
    bool PermissionForUse,
    string Notes
    ) : IRequest;
