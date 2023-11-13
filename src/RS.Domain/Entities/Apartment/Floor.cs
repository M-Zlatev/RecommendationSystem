namespace RS.Domain.Entities.Apartment;

public class Floor
{
    public int Id { get; set; }

    #region Required one-to-one relationship
    public int ApartamentId { get; set; } // Required foreign key property
    public Apartment Apartament { get; set; } // Required reference navigation to principal
    #endregion

    public int ApartmentFloor { get; set; }

    public int TotalFloorsInBuilding { get; set; }
}
