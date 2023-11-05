namespace RS.Application.Apartments.Get;

using MediatR;

using Data;
using RS.Domain.Enums;
using RS.Domain;

public sealed class GetApartmentQueryHandler : IRequestHandler<GetApartmentQuery, ApartmentResponse>
{
    private readonly IApplicationDbContext _context;
    public Task<ApartmentResponse> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
    {
        var apartment = await _context
            .Apartments
            .Where(a => a.Id == request.ApartmentId)
            .Select(a => new ApartmentResponse(
                a.Id.Value,
                Guid id,
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
                string Notes))
            .FirstOrDefault(cancellationToken);

        if(apartment is null)
        {
            throw new ApartmentNotFoundException(request.ApartmentId);
        }

        return apartment;
    }
}
