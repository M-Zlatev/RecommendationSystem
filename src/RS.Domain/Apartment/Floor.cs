namespace RS.Domain;

using ValueObjects;

public class Floor
{
    public FloorId Id { get; set; }

    #region Required one-to-one relationship
    public ApartmentId ApartamentId { get; set; } // Required foreign key property
    public Apartment Apartament { get; set; } // Required reference navigation to principal
    #endregion

    public int ApartmentFloor { get; set; }

    public int TotalFloorsInBuilding { get; set; }
}
