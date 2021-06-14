using System.Collections.Generic;
using System.Linq;

namespace ParksLookupApi.Models
{
  public class ParkListResponse
  {
    public Location InputLocation { get; set; }
    public List<ParkDistance> ParksList { get; set; }

    public ParkListResponse() { }
    public ParkListResponse(Location inputLocation)
    {
      this.InputLocation = inputLocation;
    }

    public void GenerateParksListWithDistance(List<Park> parks, int listLimit)
    {
      List<ParkDistance> parksWithDistanceList = new List<ParkDistance>();
      foreach (Park park in parks)
      {
        ParkDistance newEntry = new ParkDistance(park, this.InputLocation);
        parksWithDistanceList.Add(newEntry);
      }

      List<ParkDistance> orderedList = parksWithDistanceList.OrderBy(entry => entry.DistanceFromInMiles).ToList();
      ParkDistance[] limitedArray = new ParkDistance[listLimit];
      orderedList.CopyTo(0, limitedArray, 0, listLimit);

      this.ParksList = limitedArray.ToList();
    }

    public void GenerateParksListOnly(List<Park> parks, int listLimit)
    {
      List<ParkDistance> parksOnly = new List<ParkDistance>();
      foreach (Park park in parks)
      {
        ParkDistance newEntry = new ParkDistance(park);
        parksOnly.Add(newEntry);
      }

      ParkDistance[] limitedArray = new ParkDistance[listLimit];
      parksOnly.CopyTo(0, limitedArray, 0, listLimit);
      this.ParksList = limitedArray.ToList();
    }
  }
}