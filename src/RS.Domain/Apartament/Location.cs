namespace RS.Domain;

using ValueObjects;

public class Location
{
    public LocationId Id { get; set; }

    #region Required one-to-one relationship
    public ApartamentId ApartamentId { get; set; } // Required foreign key property
    public Apartament Apartament { get; set; } // Required reference navigation to principal
    #endregion

    public string StreetAddress { get; set; }

    public string PostalCode { get; set; }

    public City City { get; set; }
}
