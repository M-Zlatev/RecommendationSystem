namespace RS.Domain;

using ValueObjects;

public sealed class ApartmentNotFoundException : Exception
{
    public ApartmentNotFoundException(ApartmentId id)
        : base($"The apartment with the ID = {id.Value} was not found")
    {
    }
}
