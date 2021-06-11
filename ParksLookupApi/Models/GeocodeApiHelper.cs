using System.Threading.Tasks;
using RestSharp;

namespace ParksLookupApi.Models
{
  class GeocodeApiHelper
  {
    public static async Task<string> GetGeocodeData(string key, string location)
    {
      RestClient client = new RestClient("http://www.mapquestapi.com/geocoding/v1");
      RestRequest request = new RestRequest($"address?key={key}&location={location}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}