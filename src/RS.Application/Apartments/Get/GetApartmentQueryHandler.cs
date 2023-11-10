﻿namespace RS.Application.Apartments.Get;

using System.Linq;

using Microsoft.EntityFrameworkCore;
using MediatR;

using Data;
using Domain;

public sealed class GetApartmentQueryHandler : IRequestHandler<GetApartmentQuery, ApartmentResponse>
{
    private readonly IDbContext _context;

    public GetApartmentQueryHandler(IDbContext context)
    {
        _context = context;
    }

    public async Task<ApartmentResponse> Handle(GetApartmentQuery request, CancellationToken cancellationToken)
    {
        var apartment = await _context
            .DbSet<Apartment>()
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
            .FirstOrDefaultAsync(cancellationToken);

        if(apartment is null)
        {
            throw new ApartmentNotFoundException(request.ApartmentId);
        }

        return apartment;
    }
}
