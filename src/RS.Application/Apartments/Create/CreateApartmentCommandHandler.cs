namespace RS.Application.Apartaments.Create;

using MediatR;

using Domain;
using Domain.ValueObjects;
using RS.Application.Common.Interfaces;

public class CreateApartmentCommandHandler : IRequestHandler<CreateApartmentCommand>
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateApartmentCommandHandler(IApartmentRepository apartamentRepository, IUnitOfWork unitOfWork)
    {
        _apartmentRepository = apartamentRepository;
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

        _apartmentRepository.Add(apartament);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
