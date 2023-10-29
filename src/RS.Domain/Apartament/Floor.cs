namespace RS.Domain;

public class Floor
{
    public long Id { get; set; }

    #region Required one-to-one relationship
    public long ApartamentId { get; set; } // Required foreign key property
    public Apartament Apartament { get; set; } // Required reference navigation to principal
    #endregion

    public int ApartmentFloor { get; set; }

    public int TotalFloorsInBuilding { get; set; }
}
