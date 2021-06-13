using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

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

    public void SetGeocodeData()
    {
      string location = this.Address + ", " + this.City + ", " + this.State;

      var apiCallTask = GeocodeApiHelper.GetGeocodeData(location);
      var result = apiCallTask.Result;
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      var locationResponse = jsonResponse["results"][0]["locations"][0];
      this.Latitude = (decimal)locationResponse["latLng"]["lat"];
      this.Longitude = (decimal)locationResponse["latLng"]["lng"];
      this.State = (string)locationResponse["adminArea3"];
    }
  }
}