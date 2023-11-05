namespace RS.Application.Apartments.Delete;

using MediatR;

using Domain.ValueObjects;

public record DeleteApartmentCommand(ApartmentId ApartmentId) : IRequest;
