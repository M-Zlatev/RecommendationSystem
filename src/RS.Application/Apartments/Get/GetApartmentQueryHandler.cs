namespace RS.Application.Apartments.Get;

using System.Linq;

using MediatR;

using Data;
using Domain;

public sealed class GetApartmentQueryHandler : IRequestHandler<GetApartmentQuery, ApartmentResponse>
{
    private readonly IApplicationDbContext _context;

    public GetApartmentQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ApartmentResponse> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
    {
        var apartment = _context
            .Apartments
            .Where(a => a.Id == request.ApartmentId)
            .Select(a => new ApartmentResponse(
                a.Id.Value,
                a.ApartmentStatus,
                a.PropertyType,
                a.Price.Currency,
                a.Price.Amount,
                a.PricePerSqM.Currency,
                a.PricePerSqM.Amount,
                a.Quadrature,
                a.Floor,
                a.ConstructionType,
                a.YearOfConstruction,
                a.Location,
                a.BrokerCommission,
                a.PermissionForUse,
                a.Notes))
            .FirstOrDefault();

        if(apartment is null)
        {
            throw new ApartmentNotFoundException(request.ApartmentId);
        }

        return apartment;
    }
}
