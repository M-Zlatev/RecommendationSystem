namespace RS.Application.Apartments.Update;

using MediatR;

using Application.Data;
using Domain;
using Domain.ValueObjects;

public class UpdateApartmentCommandHandler : IRequestHandler<UpdateApartmentCommand>
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateApartmentCommandHandler(IApartmentRepository apartamentRepository, IUnitOfWork unitOfWork)
    {
        _apartmentRepository = apartamentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateApartmentCommand request, CancellationToken cancellationToken)
    {
        Apartment? apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);

        if(apartment is null)
        {
            throw new ApartmentNotFoundException(request.ApartmentId);
        }

        apartment.Id = request.ApartmentId;
        apartment.ApartmentStatus = request.ApartmentStatus;
        apartment.PropertyType = request.PropertyType;
        apartment.Price = new Money(request.PriceCurrency, request.PriceAmount);
        apartment.PricePerSqM = new Money(request.PricePerSqMCurrency, request.PricePerSqMAmount);
        apartment.Quadrature = request.Quadrature;
        apartment.Floor = request.Floor;
        apartment.ConstructionType = request.ConstructionType;
        apartment.YearOfConstruction = request.YearOfConstruction;
        apartment.Location = request.Location;
        apartment.BrokerCommission = request.BrokerCommission;
        apartment.PermissionForUse = request.PermissionForUse;
        apartment.Notes = request.Notes;

        _apartmentRepository.Update(apartment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
