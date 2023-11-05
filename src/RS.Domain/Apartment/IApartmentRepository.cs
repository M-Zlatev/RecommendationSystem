namespace RS.Domain;

using ValueObjects;

public interface IApartmentRepository
{
    Task<Apartment?> GetByIdAsync(ApartmentId id);

    void Add(Apartment apartament);

    void Update(Apartment apartament);

    void Remove(Apartment apartament);
}
