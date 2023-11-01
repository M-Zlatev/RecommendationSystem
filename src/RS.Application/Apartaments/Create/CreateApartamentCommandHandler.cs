namespace RS.Application.Apartaments.Create;

using MediatR;

using Application.Data;
using Domain;
using Domain.ValueObjects;

public class CreateApartamentCommandHandler : IRequestHandler<CreateApartamentCommand>
{
    private readonly IApartamentRepository _apartamentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateApartamentCommandHandler(IApartamentRepository apartamentRepository, IUnitOfWork unitOfWork)
    {
        _apartamentRepository = apartamentRepository;
        _unitOfWork = unitOfWork;

    }

    public async Task Handle(CreateApartamentCommand request, CancellationToken cancellationToken)
    {
        Apartament apartament = new Apartament(
            new ApartamentId(Guid.NewGuid()),
            request.ApartmentStatus,
            request.PropertyType,
            new Money(request.PriceCurrency, request.PriceAmount)
        );

        _apartamentRepository.Add(apartament);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
