namespace RS.Application.Apartaments.Create;

using MediatR;

using Application.Data;
using Domain;
using Domain.ValueObjects;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand>
{
    private readonly IApartmentRepository _apartamentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateApartmentCommandHandler(IApartmentRepository apartamentRepository, IUnitOfWork unitOfWork)
    {
        _apartamentRepository = apartamentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
    {
        Apartment apartament = new Apartment(
          new ApartmentId(Guid.NewGuid()),
          request.ApartmentStatus,
          request.PropertyType,
          new Money(request.PriceCurrency, request.PriceAmount),
          new Money(request.PricePerSqMCurrency, request.PricePerSqMAmount),
          request.Quadrature,
          request.Floor,
          request.ConstructionType,
          request.YearOfConstruction,
          request.Location,
          request.BrokerCommission,
          request.PermissionForUse,
          request.Notes);

        _apartamentRepository.Add(apartament);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
