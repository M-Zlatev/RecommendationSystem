namespace RS.Domain.Entities.Apartment;

using ValueObjects;

public class City
{
    public int Id { get; set; }

    #region Required one-to-one relationship
    public int LocationId { get; set; } // Required foreign key property
    public Location Location { get; set; } // Required reference navigation to principal
    #endregion

    public string Name { get; set; }

    public string Country { get; set; }
}
