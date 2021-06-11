using Microsoft.Extensions.Configuration;
using RestSharp;
using System.Threading.Tasks;

namespace ParksLookupApi.Models
{
  class GeocodeApiHelper
  {
    public static async Task<string> GetGeocodeData(string location)
    {
      string apiKey = Startup.StaticConfig.GetValue<string>("GEOCODE_API_KEY");
      RestClient client = new RestClient("http://www.mapquestapi.com/geocoding/v1");
      RestRequest request = new RestRequest($"address?key={apiKey}&location={location}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}