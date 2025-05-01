namespace HotelListing.Api.Data;

public class Hotel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }
    
    // Foreign key
    public int CountryId { get; set; }
    // Navigation property
    public Country? Country { get; set; }
}