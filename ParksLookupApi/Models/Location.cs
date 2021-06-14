using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ParksLookupApi.Models
{
  public class Location
  {
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }

    public Location(string location)
    {
      this.SetGeocodeData(location);
    }

    public void SetGeocodeData(string location)
    {
      var apiCallTask = GeocodeApiHelper.GetGeocodeData(location);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      var locationResponse = jsonResponse["results"][0]["locations"][0];
      this.Address = (string)locationResponse["street"];
      this.City = (string)locationResponse["adminArea5"];
      this.State = (string)locationResponse["adminArea3"];
      this.Latitude = (decimal)locationResponse["latLng"]["lat"];
      this.Longitude = (decimal)locationResponse["latLng"]["lng"];
    }
  }
}