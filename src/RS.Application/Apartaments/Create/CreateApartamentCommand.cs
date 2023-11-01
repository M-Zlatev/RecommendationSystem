namespace RS.Application.Apartaments.Create;

using MediatR;

using Domain.Enums;

public record CreateApartamentCommand(
    ApartmentStatus ApartmentStatus, PropertyType PropertyType, string PriceCurrency, decimal PriceAmount
    ) : IRequest;

