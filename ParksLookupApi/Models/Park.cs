namespace ParksLookupApi.Models
{
  public class Park
  {
    public int ParkId { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public int CategoryId { get; set; }
  }
}