namespace RS.Domain;

public class Location
{
    public long Id { get; set; }

    #region Required one-to-one relationship
    public long ApartamentId { get; set; } // Required foreign key property
    public Apartament Apartament { get; set; } // Required reference navigation to principal
    #endregion

    public string StreetAddress { get; set; }

    public string PostalCode { get; set; }

    public City City { get; set; }
}
