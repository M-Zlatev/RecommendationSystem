namespace RS.Domain.Entities.Apartment;

public class Location
{
    public int Id { get; set; }

    #region Required one-to-one relationship
    public int ApartamentId { get; set; } // Required foreign key property
    public Apartment Apartament { get; set; } // Required reference navigation to principal
    #endregion

    public string StreetAddress { get; set; }

    public string PostalCode { get; set; }

    public City City { get; set; }
}
