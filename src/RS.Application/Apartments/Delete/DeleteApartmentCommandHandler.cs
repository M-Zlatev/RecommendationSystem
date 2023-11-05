namespace RS.Application.Apartments.Delete;

using MediatR;

using Application.Data;
using Domain;

public class DeleteApartmentCommandHandler : IRequestHandler<DeleteApartmentCommand>
{
    private readonly IApartmentRepository _apartmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteApartmentCommandHandler(IApartmentRepository apartamentRepository, IUnitOfWork unitOfWork)
    {
        _apartmentRepository = apartamentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteApartmentCommand request, CancellationToken cancellationToken)
    {
        Apartment? apartment = await _apartmentRepository.GetByIdAsync(request.ApartmentId);

        if(apartment is null)
        {
            throw new ApartmentNotFoundException(request.ApartmentId);
        }

        _apartmentRepository.Remove(apartment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
