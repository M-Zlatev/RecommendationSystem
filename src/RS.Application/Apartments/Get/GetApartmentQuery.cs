namespace RS.Application.Apartments.Get;

using MediatR;

using Domain.Enums;
using Domain;
using Domain.ValueObjects;

public record GetApartmentQuery(ApartmentId ApartmentId) : IRequest<ApartmentResponse>;

public record ApartmentResponse(
    Guid Id,
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
    string Notes);
