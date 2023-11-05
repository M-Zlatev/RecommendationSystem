namespace RS.Application.Apartaments.Create;

using MediatR;

using Domain;
using Domain.Enums;

public record CreateApartmentCommand(
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

