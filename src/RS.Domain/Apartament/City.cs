namespace RS.Domain;

public class City
{
    public long Id { get; set; }

    #region Required one-to-one relationship
    public long LocationId { get; set; } // Required foreign key property
    public Location Location { get; set; } // Required reference navigation to principal
    #endregion

    public string Name { get; set; }

    public string Country { get; set; }
}
